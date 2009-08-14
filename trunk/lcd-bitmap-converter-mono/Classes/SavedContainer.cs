using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.Xml;

namespace lcd_bitmap_converter_mono
{
    /// <summary>
    /// Сохранялка и считывалка классов в статическом виде
    /// </summary>
    /// <typeparam name="T">Класс для управления</typeparam>
    public static class SavedContainer<T>
    {
        private static T mInstance;
        private static object mLock = new object();

        private static string FileNameForType(Type type)
        {
            string fileName = type.FullName + ".xml";
            fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), fileName);
            return fileName;
        }
        public static string FileName
        {
            get
            {
                string fileName = typeof(T).FullName + ".xml";
                fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), fileName);
                return fileName;
            }
        }

        public static T Instance
        {
            get
            {
                lock (mLock)
                {
                    if (mInstance == null)
                    {
                        mInstance = Load(FileName);
                    }
                }
                return mInstance;
            }
        }

        public static T Load(string fileName)
        {
            T opts = default(T);
            try
            {
                if (File.Exists(fileName))
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Open))
                    {
                        using (XmlReader xr = new XmlTextReader(fs))
                        {
                            XmlSerializer ser = new XmlSerializer(typeof(T));
                            if (ser.CanDeserialize(xr))
                            {
                                opts = (T)ser.Deserialize(xr);
                            }
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
            }
            catch (XmlException)
            {
            }
            if (opts == null)
                opts = (T)Activator.CreateInstance(typeof(T));
            return opts;
        }
        public static void Save(string fileName)
        {
            lock (mLock)
            {
                Save(mInstance, fileName);
            }
        }
        public static void Save()
        {
            Save(FileName);
        }
        private static void ReloadFrom(string fileName)
        {
            lock (mLock)
            {
                mInstance = Load(fileName);
            }
        }

        public static void Save(T instance, string fileName)
        {
            if (instance != null)
            {
                //создание каталога, если его ещё нет
                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }
                //если файл уже существует, сделать backup
                string backup = Path.ChangeExtension(fileName, "back");
                FileInfo fi = new FileInfo(fileName);
                if (fi.Exists)
                {
                    if (File.Exists(backup))
                        File.Delete(backup);
                    fi.MoveTo(backup);
                }
                TextWriter fs = null;
                try
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    fs = new StreamWriter(fileName);
                    ser.Serialize(fs, instance);
                    fs.Close();
                    fs = null;
                }
                catch// если ошибка при записи, вернуть предыдущий файл обратно
                {
                    if (fi != null && fi.Exists)
                        fi.MoveTo(fileName);
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
            }
        }
    }

}
