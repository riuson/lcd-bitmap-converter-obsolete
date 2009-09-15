namespace lcd_bitmap_converter_mono
{
    public interface IConvertorPart
    {
        void LoadData(string filename);
        void SaveData();
        void SaveDataAs();
        void RotateFlip(bool horizontalFlip, bool verticalFlip, RotateAngle angle);
        void Inverse();
        void ConvertData();
        void Close();
    }
}
