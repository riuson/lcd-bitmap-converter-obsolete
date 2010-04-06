﻿//data type: image
//filename:  E:\Documents\Projects\lcd-bitmap-converter\lcd-bitmap-converter-mono\Samples\cat.xml
//name:      cat
// typedef struct {
//     const unsigned char *data;
//     const int width;
//     const int height;
//     } tImage;
// binary to hex definitions
#define b_00000000 0x00
#define b_00000001 0x01
#define b_00000010 0x02
#define b_00000011 0x03
#define b_00000100 0x04
#define b_00000101 0x05
#define b_00000110 0x06
#define b_00000111 0x07
#define b_00001000 0x08
#define b_00001001 0x09
#define b_00001010 0x0A
#define b_00001011 0x0B
#define b_00001100 0x0C
#define b_00001101 0x0D
#define b_00001110 0x0E
#define b_00001111 0x0F
#define b_00010000 0x10
#define b_00010001 0x11
#define b_00010010 0x12
#define b_00010011 0x13
#define b_00010100 0x14
#define b_00010101 0x15
#define b_00010110 0x16
#define b_00010111 0x17
#define b_00011000 0x18
#define b_00011001 0x19
#define b_00011010 0x1A
#define b_00011011 0x1B
#define b_00011100 0x1C
#define b_00011101 0x1D
#define b_00011110 0x1E
#define b_00011111 0x1F
#define b_00100000 0x20
#define b_00100001 0x21
#define b_00100010 0x22
#define b_00100011 0x23
#define b_00100100 0x24
#define b_00100101 0x25
#define b_00100110 0x26
#define b_00100111 0x27
#define b_00101000 0x28
#define b_00101001 0x29
#define b_00101010 0x2A
#define b_00101011 0x2B
#define b_00101100 0x2C
#define b_00101101 0x2D
#define b_00101110 0x2E
#define b_00101111 0x2F
#define b_00110000 0x30
#define b_00110001 0x31
#define b_00110010 0x32
#define b_00110011 0x33
#define b_00110100 0x34
#define b_00110101 0x35
#define b_00110110 0x36
#define b_00110111 0x37
#define b_00111000 0x38
#define b_00111001 0x39
#define b_00111010 0x3A
#define b_00111011 0x3B
#define b_00111100 0x3C
#define b_00111101 0x3D
#define b_00111110 0x3E
#define b_00111111 0x3F
#define b_01000000 0x40
#define b_01000001 0x41
#define b_01000010 0x42
#define b_01000011 0x43
#define b_01000100 0x44
#define b_01000101 0x45
#define b_01000110 0x46
#define b_01000111 0x47
#define b_01001000 0x48
#define b_01001001 0x49
#define b_01001010 0x4A
#define b_01001011 0x4B
#define b_01001100 0x4C
#define b_01001101 0x4D
#define b_01001110 0x4E
#define b_01001111 0x4F
#define b_01010000 0x50
#define b_01010001 0x51
#define b_01010010 0x52
#define b_01010011 0x53
#define b_01010100 0x54
#define b_01010101 0x55
#define b_01010110 0x56
#define b_01010111 0x57
#define b_01011000 0x58
#define b_01011001 0x59
#define b_01011010 0x5A
#define b_01011011 0x5B
#define b_01011100 0x5C
#define b_01011101 0x5D
#define b_01011110 0x5E
#define b_01011111 0x5F
#define b_01100000 0x60
#define b_01100001 0x61
#define b_01100010 0x62
#define b_01100011 0x63
#define b_01100100 0x64
#define b_01100101 0x65
#define b_01100110 0x66
#define b_01100111 0x67
#define b_01101000 0x68
#define b_01101001 0x69
#define b_01101010 0x6A
#define b_01101011 0x6B
#define b_01101100 0x6C
#define b_01101101 0x6D
#define b_01101110 0x6E
#define b_01101111 0x6F
#define b_01110000 0x70
#define b_01110001 0x71
#define b_01110010 0x72
#define b_01110011 0x73
#define b_01110100 0x74
#define b_01110101 0x75
#define b_01110110 0x76
#define b_01110111 0x77
#define b_01111000 0x78
#define b_01111001 0x79
#define b_01111010 0x7A
#define b_01111011 0x7B
#define b_01111100 0x7C
#define b_01111101 0x7D
#define b_01111110 0x7E
#define b_01111111 0x7F
#define b_10000000 0x80
#define b_10000001 0x81
#define b_10000010 0x82
#define b_10000011 0x83
#define b_10000100 0x84
#define b_10000101 0x85
#define b_10000110 0x86
#define b_10000111 0x87
#define b_10001000 0x88
#define b_10001001 0x89
#define b_10001010 0x8A
#define b_10001011 0x8B
#define b_10001100 0x8C
#define b_10001101 0x8D
#define b_10001110 0x8E
#define b_10001111 0x8F
#define b_10010000 0x90
#define b_10010001 0x91
#define b_10010010 0x92
#define b_10010011 0x93
#define b_10010100 0x94
#define b_10010101 0x95
#define b_10010110 0x96
#define b_10010111 0x97
#define b_10011000 0x98
#define b_10011001 0x99
#define b_10011010 0x9A
#define b_10011011 0x9B
#define b_10011100 0x9C
#define b_10011101 0x9D
#define b_10011110 0x9E
#define b_10011111 0x9F
#define b_10100000 0xA0
#define b_10100001 0xA1
#define b_10100010 0xA2
#define b_10100011 0xA3
#define b_10100100 0xA4
#define b_10100101 0xA5
#define b_10100110 0xA6
#define b_10100111 0xA7
#define b_10101000 0xA8
#define b_10101001 0xA9
#define b_10101010 0xAA
#define b_10101011 0xAB
#define b_10101100 0xAC
#define b_10101101 0xAD
#define b_10101110 0xAE
#define b_10101111 0xAF
#define b_10110000 0xB0
#define b_10110001 0xB1
#define b_10110010 0xB2
#define b_10110011 0xB3
#define b_10110100 0xB4
#define b_10110101 0xB5
#define b_10110110 0xB6
#define b_10110111 0xB7
#define b_10111000 0xB8
#define b_10111001 0xB9
#define b_10111010 0xBA
#define b_10111011 0xBB
#define b_10111100 0xBC
#define b_10111101 0xBD
#define b_10111110 0xBE
#define b_10111111 0xBF
#define b_11000000 0xC0
#define b_11000001 0xC1
#define b_11000010 0xC2
#define b_11000011 0xC3
#define b_11000100 0xC4
#define b_11000101 0xC5
#define b_11000110 0xC6
#define b_11000111 0xC7
#define b_11001000 0xC8
#define b_11001001 0xC9
#define b_11001010 0xCA
#define b_11001011 0xCB
#define b_11001100 0xCC
#define b_11001101 0xCD
#define b_11001110 0xCE
#define b_11001111 0xCF
#define b_11010000 0xD0
#define b_11010001 0xD1
#define b_11010010 0xD2
#define b_11010011 0xD3
#define b_11010100 0xD4
#define b_11010101 0xD5
#define b_11010110 0xD6
#define b_11010111 0xD7
#define b_11011000 0xD8
#define b_11011001 0xD9
#define b_11011010 0xDA
#define b_11011011 0xDB
#define b_11011100 0xDC
#define b_11011101 0xDD
#define b_11011110 0xDE
#define b_11011111 0xDF
#define b_11100000 0xE0
#define b_11100001 0xE1
#define b_11100010 0xE2
#define b_11100011 0xE3
#define b_11100100 0xE4
#define b_11100101 0xE5
#define b_11100110 0xE6
#define b_11100111 0xE7
#define b_11101000 0xE8
#define b_11101001 0xE9
#define b_11101010 0xEA
#define b_11101011 0xEB
#define b_11101100 0xEC
#define b_11101101 0xED
#define b_11101110 0xEE
#define b_11101111 0xEF
#define b_11110000 0xF0
#define b_11110001 0xF1
#define b_11110010 0xF2
#define b_11110011 0xF3
#define b_11110100 0xF4
#define b_11110101 0xF5
#define b_11110110 0xF6
#define b_11110111 0xF7
#define b_11111000 0xF8
#define b_11111001 0xF9
#define b_11111010 0xFA
#define b_11111011 0xFB
#define b_11111100 0xFC
#define b_11111101 0xFD
#define b_11111110 0xFE
#define b_11111111 0xFF

const unsigned char image_data_cat[512] = {
//preview data:
//    ################################################################
//    ################################################################
//    ################################################################
//    ################################################################
//    ################################################################
//    #####################____#######################################
//    ###################_______######################################
//    ##################___#__########################################
//    ################____##_#########################################
//    ################______##########################################
//    ###############___##__##########################################
//    ###############__##__#########_#################################
//    ##############______##########_#######________##################
//    #############_______###########_#####__________#################
//    #############__##__############_####__##_##_#___################
//    #####_#######______#############_##___##_##_##__________########
//    ####___######_____###############_#_#_#_#_#__#_____________#####
//    ####____#####__#_______#####__###___##__#_#__#_########______###
//    ####_____####__#________######_###__##_##__##__############___##
//    ####__#__####______####__######_#___######_##_#############___##
//    ####__##_####_________##__######____######################___###
//    ####__##_###___##_#_##_#__#######____#####____#########____#####
//    ####__##__##___##_#__#__#__######_###_###_####_####_______######
//    ####__##_____##_#____#_##__#####____#####_##__#_##_____#########
//    ####__##_____##__#__#__##__#####__######_##___##_#__############
//    ####__#####__###_##_##_##__#####_#######_###__##_____###########
//    ####________####_#########_______#######_#######_##__###########
//    ####________###############______####_____#####___#__###########
//    ##########__####################_##_#_##_#_###__##___###########
//    ####_________###_##_##_#########_##___##_##_##____#__###########
//    ####_________###_##_##_#########_##_#____#_####__##__###########
//    ####__#####__##_#_#__#__##_______##_#####_##__#_#____###########
//    ####__##_____##_#_#__#__##_______#__#####_#___##_##__###########
//    ####__##_______##__#____#__#####_#_#####_###__##_____###########
//    ####__##__###___##_##_##__######_#######_#######_##____#########
//    ####__##__###____#_##_##__######__#######_#####_######___#######
//    ####__##_######_______##__######__#######_####_#########__######
//    ####__#__########_____##__######__########____###########__#####
//    ####__#__###########__##__######__#_#_####################__####
//    ####__#__###########__##__#######_#_#_#_##_###_############__###
//    ####____############__##__#######__##_#_#_#_##_#############__##
//    ####____############__##__#######__##___#_#_#__##_____######__##
//    #####__#############__##__######_#____##_##_#_#_______________##
//    ####################__##__######_##__###_##__##___####________##
//    ####################__##__#####_###____#_##______###############
//    ####################__##__###__####_#___________################
//    ##################____##__########_####_______##################
//    ################___#####__########_#############################
//    ###############__###__###____#####_#############################
//    ###############___#____#_____####_##############################
//    ###############___#____###___####_##############################
//    #################_##___##____###################################
//    #################__#####__######################################
//    ################____###__#######################################
//    ################________########################################
//    #################__#____########################################
//    ####################____########################################
//    #####################__#########################################
//    ################################################################
//    ################################################################
//    ################################################################
//    ################################################################
//    ################################################################
//    ################################################################
b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_00011111,  b_11111110,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_00000111,  b_11111100,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_00100011,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_10110000,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11000000,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_01111111,  b_11001100,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_01111111,  b_11100110,  b_10111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_00111111,  b_11110000,  b_10111111,  b_00111111,  b_11000000,  b_11111111,  b_11111111,  
b_11111111,  b_00011111,  b_11110000,  b_01111111,  b_00011111,  b_10000000,  b_11111111,  b_11111111,  
b_11111111,  b_10011111,  b_11111001,  b_01111111,  b_11001111,  b_00010110,  b_11111111,  b_11111111,  
b_11011111,  b_00011111,  b_11111000,  b_11111111,  b_11000110,  b_00110110,  b_00000000,  b_11111111,  
b_10001111,  b_00011111,  b_11111100,  b_11111111,  b_01010101,  b_00100101,  b_00000000,  b_11111000,  
b_00001111,  b_10011111,  b_10000000,  b_11001111,  b_00110001,  b_10100101,  b_01111111,  b_11100000,  
b_00001111,  b_10011110,  b_00000000,  b_10111111,  b_10110011,  b_10011001,  b_11111111,  b_11000111,  
b_01001111,  b_00011110,  b_01111000,  b_01111110,  b_11110001,  b_11011011,  b_11111111,  b_11000111,  
b_11001111,  b_00011110,  b_11000000,  b_11111100,  b_11110000,  b_11111111,  b_11111111,  b_11100011,  
b_11001111,  b_10001110,  b_10110101,  b_11111100,  b_11100001,  b_11000011,  b_01111111,  b_11111000,  
b_11001111,  b_10001100,  b_00100101,  b_11111001,  b_11011101,  b_10111101,  b_00000111,  b_11111100,  
b_11001111,  b_01100000,  b_10100001,  b_11111001,  b_11110000,  b_01001101,  b_10000011,  b_11111111,  
b_11001111,  b_01100000,  b_10010010,  b_11111001,  b_11111100,  b_11000110,  b_11110010,  b_11111111,  
b_11001111,  b_11100111,  b_10110110,  b_11111001,  b_11111110,  b_11001110,  b_11100000,  b_11111111,  
b_00001111,  b_11110000,  b_11111110,  b_00000011,  b_11111110,  b_11111110,  b_11100110,  b_11111111,  
b_00001111,  b_11110000,  b_11111111,  b_00000111,  b_00011110,  b_01111100,  b_11100100,  b_11111111,  
b_11111111,  b_11110011,  b_11111111,  b_11111111,  b_11010110,  b_00111010,  b_11100011,  b_11111111,  
b_00001111,  b_11100000,  b_10110110,  b_11111111,  b_11000110,  b_00110110,  b_11100100,  b_11111111,  
b_00001111,  b_11100000,  b_10110110,  b_11111111,  b_00010110,  b_01111010,  b_11100110,  b_11111111,  
b_11001111,  b_01100111,  b_00100101,  b_00000011,  b_11110110,  b_01001101,  b_11100001,  b_11111111,  
b_11001111,  b_01100000,  b_00100101,  b_00000011,  b_11110010,  b_11000101,  b_11100110,  b_11111111,  
b_11001111,  b_10000000,  b_00001001,  b_11111001,  b_11111010,  b_11001110,  b_11100000,  b_11111111,  
b_11001111,  b_00011100,  b_11011011,  b_11111100,  b_11111110,  b_11111110,  b_10000110,  b_11111111,  
b_11001111,  b_00011100,  b_11011010,  b_11111100,  b_11111100,  b_01111101,  b_00111111,  b_11111110,  
b_11001111,  b_01111110,  b_11000000,  b_11111100,  b_11111100,  b_10111101,  b_11111111,  b_11111100,  
b_01001111,  b_11111110,  b_11000001,  b_11111100,  b_11111100,  b_11000011,  b_11111111,  b_11111001,  
b_01001111,  b_11111110,  b_11001111,  b_11111100,  b_11010100,  b_11111111,  b_11111111,  b_11110011,  
b_01001111,  b_11111110,  b_11001111,  b_11111100,  b_01010101,  b_10111011,  b_11111111,  b_11100111,  
b_00001111,  b_11111111,  b_11001111,  b_11111100,  b_01011001,  b_10110101,  b_11111111,  b_11001111,  
b_00001111,  b_11111111,  b_11001111,  b_11111100,  b_00011001,  b_10010101,  b_11000001,  b_11001111,  
b_10011111,  b_11111111,  b_11001111,  b_11111100,  b_11000010,  b_01010110,  b_00000000,  b_11000000,  
b_11111111,  b_11111111,  b_11001111,  b_11111100,  b_11100110,  b_01100110,  b_00111100,  b_11000000,  
b_11111111,  b_11111111,  b_11001111,  b_01111100,  b_10000111,  b_00000110,  b_11111110,  b_11111111,  
b_11111111,  b_11111111,  b_11001111,  b_10011100,  b_00010111,  b_00000000,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11000011,  b_11111100,  b_01111011,  b_11000000,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111000,  b_11111100,  b_11111011,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_01111111,  b_11001110,  b_11100001,  b_11111011,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_01111111,  b_10000100,  b_11100000,  b_11111101,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_01111111,  b_10000100,  b_11100011,  b_11111101,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_10001101,  b_11100001,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111001,  b_11111100,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_01110000,  b_11111110,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_00000000,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_00001001,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_00001111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_10011111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  
b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111,  b_11111111  

};
tImage cat { &image_data_cat[0], 64, 64};