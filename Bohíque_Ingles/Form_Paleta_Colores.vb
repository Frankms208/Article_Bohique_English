Public Class Form_Paleta_Colores
    Public Bandera_Nuevo_Caracter As Boolean = False
    Public Paleta_Colores(,,) As Integer = {
                                                {{249, 235, 234}, {253, 237, 236}, {245, 238, 248}, {244, 236, 247}, {234, 242, 248}, {235, 245, 251}, {232, 248, 245}, {232, 246, 243}, {233, 247, 239}, {234, 250, 241}, {254, 249, 231}, {254, 245, 231}, {253, 242, 233}, {251, 238, 230}, {253, 254, 254}, {248, 249, 249}, {244, 246, 246}, {242, 244, 244}, {235, 237, 239}, {234, 236, 238}},
                                                {{242, 215, 213}, {250, 219, 216}, {235, 222, 240}, {232, 218, 239}, {212, 230, 241}, {214, 234, 248}, {209, 242, 235}, {208, 236, 231}, {212, 239, 223}, {213, 245, 227}, {252, 243, 207}, {253, 235, 208}, {250, 229, 211}, {246, 221, 204}, {251, 252, 252}, {242, 243, 244}, {234, 237, 237}, {229, 232, 232}, {214, 219, 223}, {213, 216, 220}},
                                                {{230, 176, 170}, {245, 183, 177}, {215, 189, 226}, {210, 180, 222}, {169, 204, 227}, {174, 214, 241}, {163, 228, 215}, {162, 217, 206}, {169, 223, 191}, {171, 235, 198}, {249, 231, 159}, {250, 215, 160}, {245, 203, 167}, {237, 187, 153}, {247, 249, 249}, {229, 231, 233}, {213, 219, 219}, {204, 209, 209}, {174, 182, 191}, {171, 178, 185}},
                                                {{217, 136, 128}, {241, 148, 138}, {195, 155, 211}, {187, 143, 206}, {127, 179, 213}, {133, 193, 233}, {118, 215, 196}, {115, 198, 182}, {125, 206, 160}, {130, 224, 170}, {247, 220, 111}, {248, 196, 113}, {240, 178, 122}, {229, 152, 102}, {244, 246, 247}, {215, 219, 221}, {191, 201, 202}, {178, 186, 187}, {133, 146, 158}, {128, 139, 150}},
                                                {{205, 97, 85}, {236, 112, 99}, {175, 122, 197}, {165, 105, 189}, {84, 153, 199}, {93, 173, 226}, {72, 201, 176}, {69, 179, 157}, {82, 190, 128}, {88, 214, 141}, {244, 208, 63}, {245, 176, 65}, {235, 152, 78}, {220, 118, 51}, {240, 243, 244}, {202, 207, 210}, {170, 183, 184}, {153, 163, 164}, {93, 109, 126}, {86, 101, 115}},
                                                {{192, 57, 43}, {231, 76, 60}, {155, 89, 182}, {142, 68, 173}, {41, 128, 185}, {52, 152, 219}, {26, 188, 156}, {22, 160, 133}, {39, 174, 96}, {46, 204, 113}, {241, 196, 15}, {243, 156, 18}, {230, 126, 34}, {211, 84, 0}, {236, 240, 241}, {189, 195, 199}, {149, 165, 166}, {127, 140, 141}, {52, 73, 94}, {44, 62, 80}},
                                                {{169, 50, 38}, {203, 67, 53}, {136, 78, 160}, {125, 60, 152}, {36, 113, 163}, {46, 134, 193}, {23, 165, 137}, {19, 141, 117}, {34, 153, 84}, {40, 180, 99}, {212, 172, 13}, {214, 137, 16}, {202, 111, 30}, {186, 74, 0}, {208, 211, 212}, {166, 172, 175}, {131, 145, 146}, {112, 123, 124}, {46, 64, 83}, {39, 55, 70}},
                                                {{146, 43, 33}, {176, 58, 46}, {118, 68, 138}, {108, 52, 131}, {31, 97, 141}, {40, 116, 166}, {20, 143, 119}, {17, 122, 101}, {30, 132, 73}, {35, 155, 86}, {183, 149, 11}, {185, 119, 14}, {175, 96, 26}, {160, 64, 0}, {179, 182, 183}, {144, 148, 151}, {113, 125, 126}, {97, 106, 107}, {40, 55, 71}, {33, 47, 61}},
                                                {{123, 36, 28}, {148, 49, 38}, {99, 57, 116}, {91, 44, 111}, {26, 82, 118}, {33, 97, 140}, {17, 120, 100}, {14, 102, 85}, {25, 111, 61}, {29, 131, 72}, {154, 125, 10}, {156, 100, 12}, {147, 81, 22}, {135, 54, 0}, {151, 154, 154}, {121, 125, 127}, {95, 106, 106}, {81, 90, 90}, {33, 47, 60}, {28, 40, 51}},
                                                {{100, 30, 22}, {120, 40, 31}, {81, 46, 95}, {74, 35, 90}, {21, 67, 96}, {27, 79, 114}, {14, 98, 81}, {11, 83, 69}, {20, 90, 50}, {24, 106, 59}, {125, 102, 8}, {126, 81, 9}, {120, 66, 18}, {110, 44, 0}, {123, 125, 125}, {98, 101, 103}, {77, 86, 86}, {66, 73, 73}, {27, 38, 49}, {23, 32, 42}}}
    Public UserControl_Modulo_Graficar_Invocador As UserControl_Modulo_Graficar
    Public Sub Form_Activar_Paleta(UserControl_Modulo_Graficar_Invocador_Form_Invocador_1 As UserControl_Modulo_Graficar)
        UserControl_Modulo_Graficar_Invocador = UserControl_Modulo_Graficar_Invocador_Form_Invocador_1
        Me.Show()
    End Sub

    Public Function Color_Registro(Selecion_Color_Fila As Int16, Selecion_Color_Columna As Int16)
        Panel_Muestra.BackColor = Color.FromArgb(255, Paleta_Colores(Selecion_Color_Columna, Selecion_Color_Fila, 0), Paleta_Colores(Selecion_Color_Columna, Selecion_Color_Fila, 1), Paleta_Colores(Selecion_Color_Columna, Selecion_Color_Fila, 2))
        TextBox_Color_Rojo.Text = Convert.ToString(Panel_Muestra.BackColor.R)
        TextBox_Color_Verde.Text = Convert.ToString(Panel_Muestra.BackColor.G)
        TextBox_Color_Azul.Text = Convert.ToString(Panel_Muestra.BackColor.B)
        Return 0
    End Function

    Private Sub Form_Paleta_Colores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel_Muestra.BackColor = Color.FromArgb(255, 255, 255)
        TextBox_Color_Rojo.Text = Convert.ToString(Panel_Muestra.BackColor.R)
        TextBox_Color_Verde.Text = Convert.ToString(Panel_Muestra.BackColor.G)
        TextBox_Color_Azul.Text = Convert.ToString(Panel_Muestra.BackColor.B)

        Panel_1_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 0, 0), Paleta_Colores(0, 0, 1), Paleta_Colores(0, 0, 2))
        Panel_1_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 0, 0), Paleta_Colores(1, 0, 1), Paleta_Colores(1, 0, 2))
        Panel_1_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 0, 0), Paleta_Colores(2, 0, 1), Paleta_Colores(2, 0, 2))
        Panel_1_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 0, 0), Paleta_Colores(3, 0, 1), Paleta_Colores(3, 0, 2))
        Panel_1_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 0, 0), Paleta_Colores(4, 0, 1), Paleta_Colores(4, 0, 2))
        Panel_1_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 0, 0), Paleta_Colores(5, 0, 1), Paleta_Colores(5, 0, 2))
        Panel_1_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 0, 0), Paleta_Colores(6, 0, 1), Paleta_Colores(6, 0, 2))
        Panel_1_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 0, 0), Paleta_Colores(7, 0, 1), Paleta_Colores(7, 0, 2))
        Panel_1_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 0, 0), Paleta_Colores(8, 0, 1), Paleta_Colores(8, 0, 2))
        Panel_1_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 0, 0), Paleta_Colores(9, 0, 1), Paleta_Colores(9, 0, 2))

        Panel_2_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 1, 0), Paleta_Colores(0, 1, 1), Paleta_Colores(0, 1, 2))
        Panel_2_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 1, 0), Paleta_Colores(1, 1, 1), Paleta_Colores(1, 1, 2))
        Panel_2_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 1, 0), Paleta_Colores(2, 1, 1), Paleta_Colores(2, 1, 2))
        Panel_2_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 1, 0), Paleta_Colores(3, 1, 1), Paleta_Colores(3, 1, 2))
        Panel_2_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 1, 0), Paleta_Colores(4, 1, 1), Paleta_Colores(4, 1, 2))
        Panel_2_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 1, 0), Paleta_Colores(5, 1, 1), Paleta_Colores(5, 1, 2))
        Panel_2_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 1, 0), Paleta_Colores(6, 1, 1), Paleta_Colores(6, 1, 2))
        Panel_2_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 1, 0), Paleta_Colores(7, 1, 1), Paleta_Colores(7, 1, 2))
        Panel_2_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 1, 0), Paleta_Colores(8, 1, 1), Paleta_Colores(8, 1, 2))
        Panel_2_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 1, 0), Paleta_Colores(9, 1, 1), Paleta_Colores(9, 1, 2))

        Panel_3_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 2, 0), Paleta_Colores(0, 2, 1), Paleta_Colores(0, 2, 2))
        Panel_3_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 2, 0), Paleta_Colores(1, 2, 1), Paleta_Colores(1, 2, 2))
        Panel_3_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 2, 0), Paleta_Colores(2, 2, 1), Paleta_Colores(2, 2, 2))
        Panel_3_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 2, 0), Paleta_Colores(3, 2, 1), Paleta_Colores(3, 2, 2))
        Panel_3_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 2, 0), Paleta_Colores(4, 2, 1), Paleta_Colores(4, 2, 2))
        Panel_3_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 2, 0), Paleta_Colores(5, 2, 1), Paleta_Colores(5, 2, 2))
        Panel_3_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 2, 0), Paleta_Colores(6, 2, 1), Paleta_Colores(6, 2, 2))
        Panel_3_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 2, 0), Paleta_Colores(7, 2, 1), Paleta_Colores(7, 2, 2))
        Panel_3_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 2, 0), Paleta_Colores(8, 2, 1), Paleta_Colores(8, 2, 2))
        Panel_3_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 2, 0), Paleta_Colores(9, 2, 1), Paleta_Colores(9, 2, 2))

        Panel_4_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 3, 0), Paleta_Colores(0, 3, 1), Paleta_Colores(0, 3, 2))
        Panel_4_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 3, 0), Paleta_Colores(1, 3, 1), Paleta_Colores(1, 3, 2))
        Panel_4_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 3, 0), Paleta_Colores(2, 3, 1), Paleta_Colores(2, 3, 2))
        Panel_4_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 3, 0), Paleta_Colores(3, 3, 1), Paleta_Colores(3, 3, 2))
        Panel_4_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 3, 0), Paleta_Colores(4, 3, 1), Paleta_Colores(4, 3, 2))
        Panel_4_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 3, 0), Paleta_Colores(5, 3, 1), Paleta_Colores(5, 3, 2))
        Panel_4_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 3, 0), Paleta_Colores(6, 3, 1), Paleta_Colores(6, 3, 2))
        Panel_4_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 3, 0), Paleta_Colores(7, 3, 1), Paleta_Colores(7, 3, 2))
        Panel_4_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 3, 0), Paleta_Colores(8, 3, 1), Paleta_Colores(8, 3, 2))
        Panel_4_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 3, 0), Paleta_Colores(9, 3, 1), Paleta_Colores(9, 3, 2))

        Panel_5_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 4, 0), Paleta_Colores(0, 4, 1), Paleta_Colores(0, 4, 2))
        Panel_5_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 4, 0), Paleta_Colores(1, 4, 1), Paleta_Colores(1, 4, 2))
        Panel_5_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 4, 0), Paleta_Colores(2, 4, 1), Paleta_Colores(2, 4, 2))
        Panel_5_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 4, 0), Paleta_Colores(3, 4, 1), Paleta_Colores(3, 4, 2))
        Panel_5_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 4, 0), Paleta_Colores(4, 4, 1), Paleta_Colores(4, 4, 2))
        Panel_5_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 4, 0), Paleta_Colores(5, 4, 1), Paleta_Colores(5, 4, 2))
        Panel_5_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 4, 0), Paleta_Colores(6, 4, 1), Paleta_Colores(6, 4, 2))
        Panel_5_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 4, 0), Paleta_Colores(7, 4, 1), Paleta_Colores(7, 4, 2))
        Panel_5_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 4, 0), Paleta_Colores(8, 4, 1), Paleta_Colores(8, 4, 2))
        Panel_5_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 4, 0), Paleta_Colores(9, 4, 1), Paleta_Colores(9, 4, 2))

        Panel_6_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 5, 0), Paleta_Colores(0, 5, 1), Paleta_Colores(0, 5, 2))
        Panel_6_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 5, 0), Paleta_Colores(1, 5, 1), Paleta_Colores(1, 5, 2))
        Panel_6_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 5, 0), Paleta_Colores(2, 5, 1), Paleta_Colores(2, 5, 2))
        Panel_6_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 5, 0), Paleta_Colores(3, 5, 1), Paleta_Colores(3, 5, 2))
        Panel_6_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 5, 0), Paleta_Colores(4, 5, 1), Paleta_Colores(4, 5, 2))
        Panel_6_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 5, 0), Paleta_Colores(5, 5, 1), Paleta_Colores(5, 5, 2))
        Panel_6_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 5, 0), Paleta_Colores(6, 5, 1), Paleta_Colores(6, 5, 2))
        Panel_6_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 5, 0), Paleta_Colores(7, 5, 1), Paleta_Colores(7, 5, 2))
        Panel_6_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 5, 0), Paleta_Colores(8, 5, 1), Paleta_Colores(8, 5, 2))
        Panel_6_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 5, 0), Paleta_Colores(9, 5, 1), Paleta_Colores(9, 5, 2))

        Panel_7_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 6, 0), Paleta_Colores(0, 6, 1), Paleta_Colores(0, 6, 2))
        Panel_7_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 6, 0), Paleta_Colores(1, 6, 1), Paleta_Colores(1, 6, 2))
        Panel_7_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 6, 0), Paleta_Colores(2, 6, 1), Paleta_Colores(2, 6, 2))
        Panel_7_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 6, 0), Paleta_Colores(3, 6, 1), Paleta_Colores(3, 6, 2))
        Panel_7_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 6, 0), Paleta_Colores(4, 6, 1), Paleta_Colores(4, 6, 2))
        Panel_7_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 6, 0), Paleta_Colores(5, 6, 1), Paleta_Colores(5, 6, 2))
        Panel_7_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 6, 0), Paleta_Colores(6, 6, 1), Paleta_Colores(6, 6, 2))
        Panel_7_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 6, 0), Paleta_Colores(7, 6, 1), Paleta_Colores(7, 6, 2))
        Panel_7_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 6, 0), Paleta_Colores(8, 6, 1), Paleta_Colores(8, 6, 2))
        Panel_7_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 6, 0), Paleta_Colores(9, 6, 1), Paleta_Colores(9, 6, 2))

        Panel_8_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 7, 0), Paleta_Colores(0, 7, 1), Paleta_Colores(0, 7, 2))
        Panel_8_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 7, 0), Paleta_Colores(1, 7, 1), Paleta_Colores(1, 7, 2))
        Panel_8_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 7, 0), Paleta_Colores(2, 7, 1), Paleta_Colores(2, 7, 2))
        Panel_8_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 7, 0), Paleta_Colores(3, 7, 1), Paleta_Colores(3, 7, 2))
        Panel_8_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 7, 0), Paleta_Colores(4, 7, 1), Paleta_Colores(4, 7, 2))
        Panel_8_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 7, 0), Paleta_Colores(5, 7, 1), Paleta_Colores(5, 7, 2))
        Panel_8_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 7, 0), Paleta_Colores(6, 7, 1), Paleta_Colores(6, 7, 2))
        Panel_8_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 7, 0), Paleta_Colores(7, 7, 1), Paleta_Colores(7, 7, 2))
        Panel_8_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 7, 0), Paleta_Colores(8, 7, 1), Paleta_Colores(8, 7, 2))
        Panel_8_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 7, 0), Paleta_Colores(9, 7, 1), Paleta_Colores(9, 7, 2))

        Panel_9_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 8, 0), Paleta_Colores(0, 8, 1), Paleta_Colores(0, 8, 2))
        Panel_9_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 8, 0), Paleta_Colores(1, 8, 1), Paleta_Colores(1, 8, 2))
        Panel_9_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 8, 0), Paleta_Colores(2, 8, 1), Paleta_Colores(2, 8, 2))
        Panel_9_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 8, 0), Paleta_Colores(3, 8, 1), Paleta_Colores(3, 8, 2))
        Panel_9_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 8, 0), Paleta_Colores(4, 8, 1), Paleta_Colores(4, 8, 2))
        Panel_9_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 8, 0), Paleta_Colores(5, 8, 1), Paleta_Colores(5, 8, 2))
        Panel_9_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 8, 0), Paleta_Colores(6, 8, 1), Paleta_Colores(6, 8, 2))
        Panel_9_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 8, 0), Paleta_Colores(7, 8, 1), Paleta_Colores(7, 8, 2))
        Panel_9_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 8, 0), Paleta_Colores(8, 8, 1), Paleta_Colores(8, 8, 2))
        Panel_9_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 8, 0), Paleta_Colores(9, 8, 1), Paleta_Colores(9, 8, 2))

        Panel_10_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 9, 0), Paleta_Colores(0, 9, 1), Paleta_Colores(0, 9, 2))
        Panel_10_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 9, 0), Paleta_Colores(1, 9, 1), Paleta_Colores(1, 9, 2))
        Panel_10_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 9, 0), Paleta_Colores(2, 9, 1), Paleta_Colores(2, 9, 2))
        Panel_10_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 9, 0), Paleta_Colores(3, 9, 1), Paleta_Colores(3, 9, 2))
        Panel_10_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 9, 0), Paleta_Colores(4, 9, 1), Paleta_Colores(4, 9, 2))
        Panel_10_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 9, 0), Paleta_Colores(5, 9, 1), Paleta_Colores(5, 9, 2))
        Panel_10_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 9, 0), Paleta_Colores(6, 9, 1), Paleta_Colores(6, 9, 2))
        Panel_10_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 9, 0), Paleta_Colores(7, 9, 1), Paleta_Colores(7, 9, 2))
        Panel_10_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 9, 0), Paleta_Colores(8, 9, 1), Paleta_Colores(8, 9, 2))
        Panel_10_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 9, 0), Paleta_Colores(9, 9, 1), Paleta_Colores(9, 9, 2))

        Panel_11_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 10, 0), Paleta_Colores(0, 10, 1), Paleta_Colores(0, 10, 2))
        Panel_11_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 10, 0), Paleta_Colores(1, 10, 1), Paleta_Colores(1, 10, 2))
        Panel_11_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 10, 0), Paleta_Colores(2, 10, 1), Paleta_Colores(2, 10, 2))
        Panel_11_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 10, 0), Paleta_Colores(3, 10, 1), Paleta_Colores(3, 10, 2))
        Panel_11_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 10, 0), Paleta_Colores(4, 10, 1), Paleta_Colores(4, 10, 2))
        Panel_11_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 10, 0), Paleta_Colores(5, 10, 1), Paleta_Colores(5, 10, 2))
        Panel_11_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 10, 0), Paleta_Colores(6, 10, 1), Paleta_Colores(6, 10, 2))
        Panel_11_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 10, 0), Paleta_Colores(7, 10, 1), Paleta_Colores(7, 10, 2))
        Panel_11_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 10, 0), Paleta_Colores(8, 10, 1), Paleta_Colores(8, 10, 2))
        Panel_11_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 10, 0), Paleta_Colores(9, 10, 1), Paleta_Colores(9, 10, 2))

        Panel_12_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 11, 0), Paleta_Colores(0, 11, 1), Paleta_Colores(0, 11, 2))
        Panel_12_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 11, 0), Paleta_Colores(1, 11, 1), Paleta_Colores(1, 11, 2))
        Panel_12_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 11, 0), Paleta_Colores(2, 11, 1), Paleta_Colores(2, 11, 2))
        Panel_12_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 11, 0), Paleta_Colores(3, 11, 1), Paleta_Colores(3, 11, 2))
        Panel_12_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 11, 0), Paleta_Colores(4, 11, 1), Paleta_Colores(4, 11, 2))
        Panel_12_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 11, 0), Paleta_Colores(5, 11, 1), Paleta_Colores(5, 11, 2))
        Panel_12_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 11, 0), Paleta_Colores(6, 11, 1), Paleta_Colores(6, 11, 2))
        Panel_12_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 11, 0), Paleta_Colores(7, 11, 1), Paleta_Colores(7, 11, 2))
        Panel_12_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 11, 0), Paleta_Colores(8, 11, 1), Paleta_Colores(8, 11, 2))
        Panel_12_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 11, 0), Paleta_Colores(9, 11, 1), Paleta_Colores(9, 11, 2))

        Panel_13_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 12, 0), Paleta_Colores(0, 12, 1), Paleta_Colores(0, 12, 2))
        Panel_13_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 12, 0), Paleta_Colores(1, 12, 1), Paleta_Colores(1, 12, 2))
        Panel_13_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 12, 0), Paleta_Colores(2, 12, 1), Paleta_Colores(2, 12, 2))
        Panel_13_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 12, 0), Paleta_Colores(3, 12, 1), Paleta_Colores(3, 12, 2))
        Panel_13_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 12, 0), Paleta_Colores(4, 12, 1), Paleta_Colores(4, 12, 2))
        Panel_13_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 12, 0), Paleta_Colores(5, 12, 1), Paleta_Colores(5, 12, 2))
        Panel_13_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 12, 0), Paleta_Colores(6, 12, 1), Paleta_Colores(6, 12, 2))
        Panel_13_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 12, 0), Paleta_Colores(7, 12, 1), Paleta_Colores(7, 12, 2))
        Panel_13_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 12, 0), Paleta_Colores(8, 12, 1), Paleta_Colores(8, 12, 2))
        Panel_13_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 12, 0), Paleta_Colores(9, 12, 1), Paleta_Colores(9, 12, 2))

        Panel_14_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 13, 0), Paleta_Colores(0, 13, 1), Paleta_Colores(0, 13, 2))
        Panel_14_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 13, 0), Paleta_Colores(1, 13, 1), Paleta_Colores(1, 13, 2))
        Panel_14_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 13, 0), Paleta_Colores(2, 13, 1), Paleta_Colores(2, 13, 2))
        Panel_14_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 13, 0), Paleta_Colores(3, 13, 1), Paleta_Colores(3, 13, 2))
        Panel_14_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 13, 0), Paleta_Colores(4, 13, 1), Paleta_Colores(4, 13, 2))
        Panel_14_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 13, 0), Paleta_Colores(5, 13, 1), Paleta_Colores(5, 13, 2))
        Panel_14_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 13, 0), Paleta_Colores(6, 13, 1), Paleta_Colores(6, 13, 2))
        Panel_14_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 13, 0), Paleta_Colores(7, 13, 1), Paleta_Colores(7, 13, 2))
        Panel_14_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 13, 0), Paleta_Colores(8, 13, 1), Paleta_Colores(8, 13, 2))
        Panel_14_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 13, 0), Paleta_Colores(9, 13, 1), Paleta_Colores(9, 13, 2))


        Panel_15_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 14, 0), Paleta_Colores(0, 14, 1), Paleta_Colores(0, 14, 2))
        Panel_15_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 14, 0), Paleta_Colores(1, 14, 1), Paleta_Colores(1, 14, 2))
        Panel_15_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 14, 0), Paleta_Colores(2, 14, 1), Paleta_Colores(2, 14, 2))
        Panel_15_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 14, 0), Paleta_Colores(3, 14, 1), Paleta_Colores(3, 14, 2))
        Panel_15_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 14, 0), Paleta_Colores(4, 14, 1), Paleta_Colores(4, 14, 2))
        Panel_15_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 14, 0), Paleta_Colores(5, 14, 1), Paleta_Colores(5, 14, 2))
        Panel_15_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 14, 0), Paleta_Colores(6, 14, 1), Paleta_Colores(6, 14, 2))
        Panel_15_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 14, 0), Paleta_Colores(7, 14, 1), Paleta_Colores(7, 14, 2))
        Panel_15_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 14, 0), Paleta_Colores(8, 14, 1), Paleta_Colores(8, 14, 2))
        Panel_15_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 14, 0), Paleta_Colores(9, 14, 1), Paleta_Colores(9, 14, 2))

        Panel_16_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 15, 0), Paleta_Colores(0, 15, 1), Paleta_Colores(0, 15, 2))
        Panel_16_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 15, 0), Paleta_Colores(1, 15, 1), Paleta_Colores(1, 15, 2))
        Panel_16_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 15, 0), Paleta_Colores(2, 15, 1), Paleta_Colores(2, 15, 2))
        Panel_16_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 15, 0), Paleta_Colores(3, 15, 1), Paleta_Colores(3, 15, 2))
        Panel_16_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 15, 0), Paleta_Colores(4, 15, 1), Paleta_Colores(4, 15, 2))
        Panel_16_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 15, 0), Paleta_Colores(5, 15, 1), Paleta_Colores(5, 15, 2))
        Panel_16_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 15, 0), Paleta_Colores(6, 15, 1), Paleta_Colores(6, 15, 2))
        Panel_16_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 15, 0), Paleta_Colores(7, 15, 1), Paleta_Colores(7, 15, 2))
        Panel_16_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 15, 0), Paleta_Colores(8, 15, 1), Paleta_Colores(8, 15, 2))
        Panel_16_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 15, 0), Paleta_Colores(9, 15, 1), Paleta_Colores(9, 15, 2))

        Panel_17_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 16, 0), Paleta_Colores(0, 16, 1), Paleta_Colores(0, 16, 2))
        Panel_17_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 16, 0), Paleta_Colores(1, 16, 1), Paleta_Colores(1, 16, 2))
        Panel_17_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 16, 0), Paleta_Colores(2, 16, 1), Paleta_Colores(2, 16, 2))
        Panel_17_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 16, 0), Paleta_Colores(3, 16, 1), Paleta_Colores(3, 16, 2))
        Panel_17_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 16, 0), Paleta_Colores(4, 16, 1), Paleta_Colores(4, 16, 2))
        Panel_17_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 16, 0), Paleta_Colores(5, 16, 1), Paleta_Colores(5, 16, 2))
        Panel_17_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 16, 0), Paleta_Colores(6, 16, 1), Paleta_Colores(6, 16, 2))
        Panel_17_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 16, 0), Paleta_Colores(7, 16, 1), Paleta_Colores(7, 16, 2))
        Panel_17_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 16, 0), Paleta_Colores(8, 16, 1), Paleta_Colores(8, 16, 2))
        Panel_17_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 16, 0), Paleta_Colores(9, 16, 1), Paleta_Colores(9, 16, 2))

        Panel_18_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 17, 0), Paleta_Colores(0, 17, 1), Paleta_Colores(0, 17, 2))
        Panel_18_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 17, 0), Paleta_Colores(1, 17, 1), Paleta_Colores(1, 17, 2))
        Panel_18_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 17, 0), Paleta_Colores(2, 17, 1), Paleta_Colores(2, 17, 2))
        Panel_18_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 17, 0), Paleta_Colores(3, 17, 1), Paleta_Colores(3, 17, 2))
        Panel_18_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 17, 0), Paleta_Colores(4, 17, 1), Paleta_Colores(4, 17, 2))
        Panel_18_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 17, 0), Paleta_Colores(5, 17, 1), Paleta_Colores(5, 17, 2))
        Panel_18_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 17, 0), Paleta_Colores(6, 17, 1), Paleta_Colores(6, 17, 2))
        Panel_18_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 17, 0), Paleta_Colores(7, 17, 1), Paleta_Colores(7, 17, 2))
        Panel_18_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 17, 0), Paleta_Colores(8, 17, 1), Paleta_Colores(8, 17, 2))
        Panel_18_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 17, 0), Paleta_Colores(9, 17, 1), Paleta_Colores(9, 17, 2))

        Panel_19_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 18, 0), Paleta_Colores(0, 18, 1), Paleta_Colores(0, 18, 2))
        Panel_19_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 18, 0), Paleta_Colores(1, 18, 1), Paleta_Colores(1, 18, 2))
        Panel_19_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 18, 0), Paleta_Colores(2, 18, 1), Paleta_Colores(2, 18, 2))
        Panel_19_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 18, 0), Paleta_Colores(3, 18, 1), Paleta_Colores(3, 18, 2))
        Panel_19_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 18, 0), Paleta_Colores(4, 18, 1), Paleta_Colores(4, 18, 2))
        Panel_19_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 18, 0), Paleta_Colores(5, 18, 1), Paleta_Colores(5, 18, 2))
        Panel_19_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 18, 0), Paleta_Colores(6, 18, 1), Paleta_Colores(6, 18, 2))
        Panel_19_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 18, 0), Paleta_Colores(7, 18, 1), Paleta_Colores(7, 18, 2))
        Panel_19_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 18, 0), Paleta_Colores(8, 18, 1), Paleta_Colores(8, 18, 2))
        Panel_19_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 18, 0), Paleta_Colores(9, 18, 1), Paleta_Colores(9, 18, 2))

        Panel_20_1.BackColor = Color.FromArgb(255, Paleta_Colores(0, 19, 0), Paleta_Colores(0, 19, 1), Paleta_Colores(0, 19, 2))
        Panel_20_2.BackColor = Color.FromArgb(255, Paleta_Colores(1, 19, 0), Paleta_Colores(1, 19, 1), Paleta_Colores(1, 19, 2))
        Panel_20_3.BackColor = Color.FromArgb(255, Paleta_Colores(2, 19, 0), Paleta_Colores(2, 19, 1), Paleta_Colores(2, 19, 2))
        Panel_20_4.BackColor = Color.FromArgb(255, Paleta_Colores(3, 19, 0), Paleta_Colores(3, 19, 1), Paleta_Colores(3, 19, 2))
        Panel_20_5.BackColor = Color.FromArgb(255, Paleta_Colores(4, 19, 0), Paleta_Colores(4, 19, 1), Paleta_Colores(4, 19, 2))
        Panel_20_6.BackColor = Color.FromArgb(255, Paleta_Colores(5, 19, 0), Paleta_Colores(5, 19, 1), Paleta_Colores(5, 19, 2))
        Panel_20_7.BackColor = Color.FromArgb(255, Paleta_Colores(6, 19, 0), Paleta_Colores(6, 19, 1), Paleta_Colores(6, 19, 2))
        Panel_20_8.BackColor = Color.FromArgb(255, Paleta_Colores(7, 19, 0), Paleta_Colores(7, 19, 1), Paleta_Colores(7, 19, 2))
        Panel_20_9.BackColor = Color.FromArgb(255, Paleta_Colores(8, 19, 0), Paleta_Colores(8, 19, 1), Paleta_Colores(8, 19, 2))
        Panel_20_10.BackColor = Color.FromArgb(255, Paleta_Colores(9, 19, 0), Paleta_Colores(9, 19, 1), Paleta_Colores(9, 19, 2))


    End Sub



    Private Sub Panel_1_1_Click(sender As Object, e As EventArgs) Handles Panel_1_1.Click
        Color_Registro(0, 0)
    End Sub

    Private Sub Panel_1_2_Click(sender As Object, e As EventArgs) Handles Panel_1_2.Click
        Color_Registro(0, 1)
    End Sub

    Private Sub Panel_1_3_Click(sender As Object, e As EventArgs) Handles Panel_1_3.Click
        Color_Registro(0, 2)
    End Sub

    Private Sub Panel_1_4_Click(sender As Object, e As EventArgs) Handles Panel_1_4.Click
        Color_Registro(0, 3)
    End Sub

    Private Sub Panel_1_5_Click(sender As Object, e As EventArgs) Handles Panel_1_5.Click
        Color_Registro(0, 4)
    End Sub

    Private Sub Panel_1_6_Click(sender As Object, e As EventArgs) Handles Panel_1_6.Click
        Color_Registro(0, 5)
    End Sub

    Private Sub Panel_1_7_Click(sender As Object, e As EventArgs) Handles Panel_1_7.Click
        Color_Registro(0, 6)
    End Sub

    Private Sub Panel_1_8_Click(sender As Object, e As EventArgs) Handles Panel_1_8.Click
        Color_Registro(0, 7)
    End Sub

    Private Sub Panel_1_9_Click(sender As Object, e As EventArgs) Handles Panel_1_9.Click
        Color_Registro(0, 8)
    End Sub

    Private Sub Panel_1_10_Click(sender As Object, e As EventArgs) Handles Panel_1_10.Click
        Color_Registro(0, 9)
    End Sub




    Private Sub Panel_2_3_Click(sender As Object, e As EventArgs) Handles Panel_2_3.Click
        Color_Registro(1, 2)
    End Sub

    Private Sub Panel_2_4_Click(sender As Object, e As EventArgs) Handles Panel_2_4.Click
        Color_Registro(1, 3)
    End Sub

    Private Sub Panel_2_5_Click(sender As Object, e As EventArgs) Handles Panel_2_5.Click
        Color_Registro(1, 4)
    End Sub

    Private Sub Panel_2_6_Click(sender As Object, e As EventArgs) Handles Panel_2_6.Click
        Color_Registro(1, 5)
    End Sub

    Private Sub Panel_2_7_Click(sender As Object, e As EventArgs) Handles Panel_2_7.Click
        Color_Registro(1, 6)
    End Sub

    Private Sub Panel_2_8_Click(sender As Object, e As EventArgs) Handles Panel_2_8.Click
        Color_Registro(1, 7)
    End Sub

    Private Sub Panel_2_9_Click(sender As Object, e As EventArgs) Handles Panel_2_9.Click
        Color_Registro(1, 8)
    End Sub

    Private Sub Panel_2_10_Click(sender As Object, e As EventArgs) Handles Panel_2_10.Click
        Color_Registro(1, 9)
    End Sub

    Private Sub Panel_3_1_Click(sender As Object, e As EventArgs) Handles Panel_3_1.Click
        Color_Registro(2, 0)
    End Sub

    Private Sub Panel_3_2_Click(sender As Object, e As EventArgs) Handles Panel_3_2.Click
        Color_Registro(2, 1)
    End Sub

    Private Sub Panel_3_3_Click(sender As Object, e As EventArgs) Handles Panel_3_3.Click
        Color_Registro(2, 2)
    End Sub

    Private Sub Panel_3_4_Click(sender As Object, e As EventArgs) Handles Panel_3_4.Click
        Color_Registro(2, 3)
    End Sub

    Private Sub Panel_3_5_Click(sender As Object, e As EventArgs) Handles Panel_3_5.Click
        Color_Registro(2, 4)
    End Sub

    Private Sub Panel_3_6_Click(sender As Object, e As EventArgs) Handles Panel_3_6.Click
        Color_Registro(2, 5)
    End Sub

    Private Sub Panel_3_7_Click(sender As Object, e As EventArgs) Handles Panel_3_7.Click
        Color_Registro(2, 6)
    End Sub

    Private Sub Panel_3_8_Click(sender As Object, e As EventArgs) Handles Panel_3_8.Click
        Color_Registro(2, 7)
    End Sub

    Private Sub Panel_3_9_Click(sender As Object, e As EventArgs) Handles Panel_3_9.Click
        Color_Registro(2, 8)
    End Sub

    Private Sub Panel_3_10_Click(sender As Object, e As EventArgs) Handles Panel_3_10.Click
        Color_Registro(2, 9)
    End Sub

    Private Sub Panel_4_1_Click(sender As Object, e As EventArgs) Handles Panel_4_1.Click
        Color_Registro(3, 0)
    End Sub

    Private Sub Panel_4_2_Click(sender As Object, e As EventArgs) Handles Panel_4_2.Click
        Color_Registro(3, 1)
    End Sub

    Private Sub Panel_4_3_Click(sender As Object, e As EventArgs) Handles Panel_4_3.Click
        Color_Registro(3, 2)
    End Sub

    Private Sub Panel_4_4_Click(sender As Object, e As EventArgs) Handles Panel_4_4.Click
        Color_Registro(3, 3)
    End Sub

    Private Sub Panel_4_5_Click(sender As Object, e As EventArgs) Handles Panel_4_5.Click
        Color_Registro(3, 4)
    End Sub

    Private Sub Panel_4_6_Click(sender As Object, e As EventArgs) Handles Panel_4_6.Click
        Color_Registro(3, 5)
    End Sub

    Private Sub Panel_4_7_Click(sender As Object, e As EventArgs) Handles Panel_4_7.Click
        Color_Registro(3, 6)
    End Sub

    Private Sub Panel_4_8_Click(sender As Object, e As EventArgs) Handles Panel_4_8.Click
        Color_Registro(3, 7)
    End Sub
    Private Sub Panel_4_9_Click(sender As Object, e As EventArgs) Handles Panel_4_9.Click
        Color_Registro(3, 8)
    End Sub
    Private Sub Panel_4_10_Click(sender As Object, e As EventArgs) Handles Panel_4_10.Click
        Color_Registro(3, 9)
    End Sub

    Private Sub Panel_5_1_Click(sender As Object, e As EventArgs) Handles Panel_5_1.Click
        Color_Registro(4, 0)
    End Sub

    Private Sub Panel_5_2_Click(sender As Object, e As EventArgs) Handles Panel_5_2.Click
        Color_Registro(4, 1)
    End Sub

    Private Sub Panel_5_3_Click(sender As Object, e As EventArgs) Handles Panel_5_3.Click
        Color_Registro(4, 2)
    End Sub

    Private Sub Panel_5_4_Click(sender As Object, e As EventArgs) Handles Panel_5_4.Click
        Color_Registro(4, 3)
    End Sub

    Private Sub Panel_5_5_Click(sender As Object, e As EventArgs) Handles Panel_5_5.Click
        Color_Registro(4, 4)
    End Sub

    Private Sub Panel_5_6_Click(sender As Object, e As EventArgs) Handles Panel_5_6.Click
        Color_Registro(4, 5)
    End Sub

    Private Sub Panel_5_7_Click(sender As Object, e As EventArgs) Handles Panel_5_7.Click
        Color_Registro(4, 6)
    End Sub

    Private Sub Panel_5_8_Click(sender As Object, e As EventArgs) Handles Panel_5_8.Click
        Color_Registro(4, 7)
    End Sub

    Private Sub Panel_5_9_Click(sender As Object, e As EventArgs) Handles Panel_5_9.Click
        Color_Registro(4, 8)
    End Sub

    Private Sub Panel_5_10_Click(sender As Object, e As EventArgs) Handles Panel_5_10.Click
        Color_Registro(4, 9)
    End Sub

    Private Sub Panel_6_1_Click(sender As Object, e As EventArgs) Handles Panel_6_1.Click
        Color_Registro(5, 0)
    End Sub

    Private Sub Panel_6_2_Click(sender As Object, e As EventArgs) Handles Panel_6_2.Click
        Color_Registro(5, 1)
    End Sub

    Private Sub Panel_6_3_Click(sender As Object, e As EventArgs) Handles Panel_6_3.Click
        Color_Registro(5, 2)
    End Sub

    Private Sub Panel_6_4_Click(sender As Object, e As EventArgs) Handles Panel_6_4.Click
        Color_Registro(5, 3)
    End Sub

    Private Sub Panel_6_5_Click(sender As Object, e As EventArgs) Handles Panel_6_5.Click
        Color_Registro(5, 4)
    End Sub

    Private Sub Panel_6_6_Click(sender As Object, e As EventArgs) Handles Panel_6_6.Click
        Color_Registro(5, 5)
    End Sub

    Private Sub Panel_6_7_Click(sender As Object, e As EventArgs) Handles Panel_6_7.Click
        Color_Registro(5, 6)
    End Sub

    Private Sub Panel_6_8_Click(sender As Object, e As EventArgs) Handles Panel_6_8.Click
        Color_Registro(5, 7)
    End Sub

    Private Sub Panel_6_9_Click(sender As Object, e As EventArgs) Handles Panel_6_9.Click
        Color_Registro(5, 8)
    End Sub

    Private Sub Panel_6_10_Click(sender As Object, e As EventArgs) Handles Panel_6_10.Click
        Color_Registro(5, 9)
    End Sub

    Private Sub Panel_2_1_Click(sender As Object, e As EventArgs) Handles Panel_2_1.Click
        Color_Registro(1, 0)
    End Sub

    Private Sub Panel_2_2_Click(sender As Object, e As EventArgs) Handles Panel_2_2.Click
        Color_Registro(1, 1)
    End Sub

    Private Sub Panel_7_1_Click(sender As Object, e As EventArgs) Handles Panel_7_1.Click
        Color_Registro(6, 0)
    End Sub

    Private Sub Panel_7_2_Click(sender As Object, e As EventArgs) Handles Panel_7_2.Click
        Color_Registro(6, 1)
    End Sub

    Private Sub Panel_7_3_Click(sender As Object, e As EventArgs) Handles Panel_7_3.Click
        Color_Registro(6, 2)
    End Sub

    Private Sub Panel_7_4_Click(sender As Object, e As EventArgs) Handles Panel_7_4.Click
        Color_Registro(6, 3)
    End Sub

    Private Sub Panel_7_5_Click(sender As Object, e As EventArgs) Handles Panel_7_5.Click
        Color_Registro(6, 4)
    End Sub

    Private Sub Panel_7_6_Click(sender As Object, e As EventArgs) Handles Panel_7_6.Click
        Color_Registro(6, 5)
    End Sub

    Private Sub Panel_7_7_Click(sender As Object, e As EventArgs) Handles Panel_7_7.Click
        Color_Registro(6, 6)
    End Sub

    Private Sub Panel_7_8_Click(sender As Object, e As EventArgs) Handles Panel_7_8.Click
        Color_Registro(6, 7)
    End Sub

    Private Sub Panel_7_9_Click(sender As Object, e As EventArgs) Handles Panel_7_9.Click
        Color_Registro(6, 8)
    End Sub

    Private Sub Panel_7_10_Click(sender As Object, e As EventArgs) Handles Panel_7_10.Click
        Color_Registro(6, 9)
    End Sub

    Private Sub Panel_8_1_Click(sender As Object, e As EventArgs) Handles Panel_8_1.Click
        Color_Registro(7, 0)
    End Sub

    Private Sub Panel_8_2_Click(sender As Object, e As EventArgs) Handles Panel_8_2.Click
        Color_Registro(7, 1)
    End Sub

    Private Sub Panel_8_3_Click(sender As Object, e As EventArgs) Handles Panel_8_3.Click
        Color_Registro(7, 2)
    End Sub

    Private Sub Panel_8_4_Click(sender As Object, e As EventArgs) Handles Panel_8_4.Click
        Color_Registro(7, 3)
    End Sub

    Private Sub Panel_8_5_Click(sender As Object, e As EventArgs) Handles Panel_8_5.Click
        Color_Registro(7, 4)
    End Sub

    Private Sub Panel_8_6_Click(sender As Object, e As EventArgs) Handles Panel_8_6.Click
        Color_Registro(7, 5)
    End Sub

    Private Sub Panel_8_7_Click(sender As Object, e As EventArgs) Handles Panel_8_7.Click
        Color_Registro(7, 6)
    End Sub

    Private Sub Panel_8_8_Click(sender As Object, e As EventArgs) Handles Panel_8_8.Click
        Color_Registro(7, 7)
    End Sub

    Private Sub Panel_8_9_Click(sender As Object, e As EventArgs) Handles Panel_8_9.Click
        Color_Registro(7, 8)
    End Sub

    Private Sub Panel_8_10_Click(sender As Object, e As EventArgs) Handles Panel_8_10.Click
        Color_Registro(7, 9)
    End Sub

    Private Sub Panel_9_1_Click(sender As Object, e As EventArgs) Handles Panel_9_1.Click
        Color_Registro(8, 0)
    End Sub

    Private Sub Panel_9_2_Click(sender As Object, e As EventArgs) Handles Panel_9_2.Click
        Color_Registro(8, 1)
    End Sub

    Private Sub Panel_9_3_Click(sender As Object, e As EventArgs) Handles Panel_9_3.Click
        Color_Registro(8, 2)
    End Sub

    Private Sub Panel_9_4_Click(sender As Object, e As EventArgs) Handles Panel_9_4.Click
        Color_Registro(8, 3)
    End Sub

    Private Sub Panel_9_5_Click(sender As Object, e As EventArgs) Handles Panel_9_5.Click
        Color_Registro(8, 4)
    End Sub

    Private Sub Panel_9_6_Click(sender As Object, e As EventArgs) Handles Panel_9_6.Click
        Color_Registro(8, 5)
    End Sub

    Private Sub Panel_9_7_Click(sender As Object, e As EventArgs) Handles Panel_9_7.Click
        Color_Registro(8, 6)
    End Sub

    Private Sub Panel_9_8_Click(sender As Object, e As EventArgs) Handles Panel_9_8.Click
        Color_Registro(8, 7)
    End Sub

    Private Sub Panel_9_9_Click(sender As Object, e As EventArgs) Handles Panel_9_9.Click
        Color_Registro(8, 8)
    End Sub

    Private Sub Panel_9_10_Click(sender As Object, e As EventArgs) Handles Panel_9_10.Click
        Color_Registro(8, 9)
    End Sub

    Private Sub Panel_10_1_Click(sender As Object, e As EventArgs) Handles Panel_10_1.Click
        Color_Registro(9, 0)
    End Sub

    Private Sub Panel_10_2_Click(sender As Object, e As EventArgs) Handles Panel_10_2.Click
        Color_Registro(9, 1)
    End Sub

    Private Sub Panel_10_3_Click(sender As Object, e As EventArgs) Handles Panel_10_3.Click
        Color_Registro(9, 2)
    End Sub

    Private Sub Panel_10_4_Click(sender As Object, e As EventArgs) Handles Panel_10_4.Click
        Color_Registro(9, 3)
    End Sub

    Private Sub Panel_10_5_Click(sender As Object, e As EventArgs) Handles Panel_10_5.Click
        Color_Registro(9, 4)
    End Sub

    Private Sub Panel_10_6_Click(sender As Object, e As EventArgs) Handles Panel_10_6.Click
        Color_Registro(9, 5)
    End Sub

    Private Sub Panel_10_7_Click(sender As Object, e As EventArgs) Handles Panel_10_7.Click
        Color_Registro(9, 6)
    End Sub

    Private Sub Panel_10_8_Click(sender As Object, e As EventArgs) Handles Panel_10_8.Click
        Color_Registro(9, 7)
    End Sub

    Private Sub Panel_10_9_Click(sender As Object, e As EventArgs) Handles Panel_10_9.Click
        Color_Registro(9, 8)
    End Sub

    Private Sub Panel_10_10_Click(sender As Object, e As EventArgs) Handles Panel_10_10.Click
        Color_Registro(9, 9)
    End Sub

    Private Sub Panel_11_1_Click(sender As Object, e As EventArgs) Handles Panel_11_1.Click
        Color_Registro(10, 0)
    End Sub

    Private Sub Panel_11_2_Click(sender As Object, e As EventArgs) Handles Panel_11_2.Click
        Color_Registro(10, 1)
    End Sub

    Private Sub Panel_11_3_Click(sender As Object, e As EventArgs) Handles Panel_11_3.Click
        Color_Registro(10, 2)
    End Sub

    Private Sub Panel_11_4_Click(sender As Object, e As EventArgs) Handles Panel_11_4.Click
        Color_Registro(10, 3)
    End Sub

    Private Sub Panel_11_5_Click(sender As Object, e As EventArgs) Handles Panel_11_5.Click
        Color_Registro(10, 4)
    End Sub

    Private Sub Panel_11_6_Click(sender As Object, e As EventArgs) Handles Panel_11_6.Click
        Color_Registro(10, 5)
    End Sub

    Private Sub Panel_11_7_Click(sender As Object, e As EventArgs) Handles Panel_11_7.Click
        Color_Registro(10, 6)
    End Sub

    Private Sub Panel_11_8_Click(sender As Object, e As EventArgs) Handles Panel_11_8.Click
        Color_Registro(10, 7)
    End Sub

    Private Sub Panel_11_9_Click(sender As Object, e As EventArgs) Handles Panel_11_9.Click
        Color_Registro(10, 8)
    End Sub

    Private Sub Panel_11_10_Click(sender As Object, e As EventArgs) Handles Panel_11_10.Click
        Color_Registro(10, 9)
    End Sub

    Private Sub Panel_12_1_Click(sender As Object, e As EventArgs) Handles Panel_12_1.Click
        Color_Registro(11, 0)
    End Sub

    Private Sub Panel_12_2_Click(sender As Object, e As EventArgs) Handles Panel_12_2.Click
        Color_Registro(11, 1)
    End Sub

    Private Sub Panel_12_3_Click(sender As Object, e As EventArgs) Handles Panel_12_3.Click
        Color_Registro(11, 2)
    End Sub

    Private Sub Panel_12_4_Click(sender As Object, e As EventArgs) Handles Panel_12_4.Click
        Color_Registro(11, 3)
    End Sub

    Private Sub Panel_12_5_Click(sender As Object, e As EventArgs) Handles Panel_12_5.Click
        Color_Registro(11, 4)
    End Sub

    Private Sub Panel_12_6_Click(sender As Object, e As EventArgs) Handles Panel_12_6.Click
        Color_Registro(11, 5)
    End Sub

    Private Sub Panel_12_7_Click(sender As Object, e As EventArgs) Handles Panel_12_7.Click
        Color_Registro(11, 6)
    End Sub

    Private Sub Panel_12_8_Click(sender As Object, e As EventArgs) Handles Panel_12_8.Click
        Color_Registro(11, 7)
    End Sub

    Private Sub Panel_12_9_Click(sender As Object, e As EventArgs) Handles Panel_12_9.Click
        Color_Registro(11, 8)
    End Sub

    Private Sub Panel_12_10_Click(sender As Object, e As EventArgs) Handles Panel_12_10.Click
        Color_Registro(11, 9)
    End Sub

    Private Sub Panel_13_1_Click(sender As Object, e As EventArgs) Handles Panel_13_1.Click
        Color_Registro(12, 0)
    End Sub

    Private Sub Panel_13_2_Click(sender As Object, e As EventArgs) Handles Panel_13_2.Click
        Color_Registro(12, 1)
    End Sub

    Private Sub Panel_13_3_Click(sender As Object, e As EventArgs) Handles Panel_13_3.Click
        Color_Registro(12, 2)
    End Sub

    Private Sub Panel_13_4_Click(sender As Object, e As EventArgs) Handles Panel_13_4.Click
        Color_Registro(12, 3)
    End Sub

    Private Sub Panel_13_5_Click(sender As Object, e As EventArgs) Handles Panel_13_5.Click
        Color_Registro(12, 4)
    End Sub

    Private Sub Panel_13_6_Click(sender As Object, e As EventArgs) Handles Panel_13_6.Click
        Color_Registro(12, 5)
    End Sub

    Private Sub Panel_13_7_Click(sender As Object, e As EventArgs) Handles Panel_13_7.Click
        Color_Registro(12, 6)
    End Sub

    Private Sub Panel_13_8_Click(sender As Object, e As EventArgs) Handles Panel_13_8.Click
        Color_Registro(12, 7)
    End Sub

    Private Sub Panel_13_9_Click(sender As Object, e As EventArgs) Handles Panel_13_9.Click
        Color_Registro(12, 8)
    End Sub

    Private Sub Panel_13_10_Click(sender As Object, e As EventArgs) Handles Panel_13_10.Click
        Color_Registro(12, 9)
    End Sub

    Private Sub Panel_14_1_Click(sender As Object, e As EventArgs) Handles Panel_14_1.Click
        Color_Registro(13, 0)
    End Sub

    Private Sub Panel_14_2_Click(sender As Object, e As EventArgs) Handles Panel_14_2.Click
        Color_Registro(13, 1)
    End Sub

    Private Sub Panel_14_3_Click(sender As Object, e As EventArgs) Handles Panel_14_3.Click
        Color_Registro(13, 2)
    End Sub

    Private Sub Panel_14_4_Click(sender As Object, e As EventArgs) Handles Panel_14_4.Click
        Color_Registro(13, 3)
    End Sub

    Private Sub Panel_14_5_Click(sender As Object, e As EventArgs) Handles Panel_14_5.Click
        Color_Registro(13, 4)
    End Sub

    Private Sub Panel_14_6_Click(sender As Object, e As EventArgs) Handles Panel_14_6.Click
        Color_Registro(13, 5)
    End Sub

    Private Sub Panel_14_7_Click(sender As Object, e As EventArgs) Handles Panel_14_7.Click
        Color_Registro(13, 6)
    End Sub

    Private Sub Panel_14_8_Click(sender As Object, e As EventArgs) Handles Panel_14_8.Click
        Color_Registro(13, 7)
    End Sub

    Private Sub Panel_14_9_Click(sender As Object, e As EventArgs) Handles Panel_14_9.Click
        Color_Registro(13, 8)
    End Sub

    Private Sub Panel_14_10_Click(sender As Object, e As EventArgs) Handles Panel_14_10.Click
        Color_Registro(13, 9)
    End Sub

    Private Sub Panel_15_1_Click(sender As Object, e As EventArgs) Handles Panel_15_1.Click
        Color_Registro(14, 0)
    End Sub

    Private Sub Panel_15_2_Click(sender As Object, e As EventArgs) Handles Panel_15_2.Click
        Color_Registro(14, 1)
    End Sub

    Private Sub Panel_15_3_Click(sender As Object, e As EventArgs) Handles Panel_15_3.Click
        Color_Registro(14, 2)
    End Sub

    Private Sub Panel_15_4_Click(sender As Object, e As EventArgs) Handles Panel_15_4.Click
        Color_Registro(14, 3)
    End Sub

    Private Sub Panel_15_5_Click(sender As Object, e As EventArgs) Handles Panel_15_5.Click
        Color_Registro(14, 4)
    End Sub

    Private Sub Panel_15_6_Click(sender As Object, e As EventArgs) Handles Panel_15_6.Click
        Color_Registro(14, 5)
    End Sub

    Private Sub Panel_15_7_Click(sender As Object, e As EventArgs) Handles Panel_15_7.Click
        Color_Registro(14, 6)
    End Sub

    Private Sub Panel_15_8_Click(sender As Object, e As EventArgs) Handles Panel_15_8.Click
        Color_Registro(14, 7)
    End Sub

    Private Sub Panel_15_9_Click(sender As Object, e As EventArgs) Handles Panel_15_9.Click
        Color_Registro(14, 8)
    End Sub

    Private Sub Panel_15_10_Click(sender As Object, e As EventArgs) Handles Panel_15_10.Click
        Color_Registro(14, 9)
    End Sub

    Private Sub Panel_16_1_Click(sender As Object, e As EventArgs) Handles Panel_16_1.Click
        Color_Registro(15, 0)
    End Sub

    Private Sub Panel_16_2_Click(sender As Object, e As EventArgs) Handles Panel_16_2.Click
        Color_Registro(15, 1)
    End Sub

    Private Sub Panel_16_3_Click(sender As Object, e As EventArgs) Handles Panel_16_3.Click
        Color_Registro(15, 2)
    End Sub

    Private Sub Panel_16_4_Click(sender As Object, e As EventArgs) Handles Panel_16_4.Click
        Color_Registro(15, 3)
    End Sub

    Private Sub Panel_16_5_Click(sender As Object, e As EventArgs) Handles Panel_16_5.Click
        Color_Registro(15, 4)
    End Sub

    Private Sub Panel_16_6_Click(sender As Object, e As EventArgs) Handles Panel_16_6.Click
        Color_Registro(15, 5)
    End Sub

    Private Sub Panel_16_7_Click(sender As Object, e As EventArgs) Handles Panel_16_7.Click
        Color_Registro(15, 6)
    End Sub

    Private Sub Panel_16_8_Click(sender As Object, e As EventArgs) Handles Panel_16_8.Click
        Color_Registro(15, 7)
    End Sub

    Private Sub Panel_16_9_Click(sender As Object, e As EventArgs) Handles Panel_16_9.Click
        Color_Registro(15, 8)
    End Sub

    Private Sub Panel_16_10_Click(sender As Object, e As EventArgs) Handles Panel_16_10.Click
        Color_Registro(15, 9)
    End Sub

    Private Sub Panel_17_1_Click(sender As Object, e As EventArgs) Handles Panel_17_1.Click
        Color_Registro(16, 0)
    End Sub

    Private Sub Panel_17_2_Click(sender As Object, e As EventArgs) Handles Panel_17_2.Click
        Color_Registro(16, 1)
    End Sub

    Private Sub Panel_17_3_Click(sender As Object, e As EventArgs) Handles Panel_17_3.Click
        Color_Registro(16, 2)
    End Sub

    Private Sub Panel_17_4_Click(sender As Object, e As EventArgs) Handles Panel_17_4.Click
        Color_Registro(16, 3)
    End Sub

    Private Sub Panel_17_5_Click(sender As Object, e As EventArgs) Handles Panel_17_5.Click
        Color_Registro(16, 4)
    End Sub

    Private Sub Panel_17_6_Click(sender As Object, e As EventArgs) Handles Panel_17_6.Click
        Color_Registro(16, 5)
    End Sub

    Private Sub Panel_17_7_Click(sender As Object, e As EventArgs) Handles Panel_17_7.Click
        Color_Registro(16, 6)
    End Sub

    Private Sub Panel_17_8_Click(sender As Object, e As EventArgs) Handles Panel_17_8.Click
        Color_Registro(16, 7)
    End Sub

    Private Sub Panel_17_9_Click(sender As Object, e As EventArgs) Handles Panel_17_9.Click
        Color_Registro(16, 8)
    End Sub

    Private Sub Panel_17_10_Click(sender As Object, e As EventArgs) Handles Panel_17_10.Click
        Color_Registro(16, 9)
    End Sub

    Private Sub Panel_18_1_Click(sender As Object, e As EventArgs) Handles Panel_18_1.Click
        Color_Registro(17, 0)
    End Sub

    Private Sub Panel_18_2_Click(sender As Object, e As EventArgs) Handles Panel_18_2.Click
        Color_Registro(17, 1)
    End Sub

    Private Sub Panel_18_3_Click(sender As Object, e As EventArgs) Handles Panel_18_3.Click
        Color_Registro(17, 2)
    End Sub

    Private Sub Panel_18_4_Click(sender As Object, e As EventArgs) Handles Panel_18_4.Click
        Color_Registro(17, 3)
    End Sub

    Private Sub Panel_18_5_Click(sender As Object, e As EventArgs) Handles Panel_18_5.Click
        Color_Registro(17, 4)
    End Sub

    Private Sub Panel_18_6_Click(sender As Object, e As EventArgs) Handles Panel_18_6.Click
        Color_Registro(17, 5)
    End Sub

    Private Sub Panel_18_7_Click(sender As Object, e As EventArgs) Handles Panel_18_7.Click
        Color_Registro(17, 6)
    End Sub

    Private Sub Panel_18_8_Click(sender As Object, e As EventArgs) Handles Panel_18_8.Click
        Color_Registro(17, 7)
    End Sub

    Private Sub Panel_18_9_Click(sender As Object, e As EventArgs) Handles Panel_18_9.Click
        Color_Registro(17, 8)
    End Sub

    Private Sub Panel_18_10_Click(sender As Object, e As EventArgs) Handles Panel_18_10.Click
        Color_Registro(17, 9)
    End Sub

    Private Sub Panel_19_1_Click(sender As Object, e As EventArgs) Handles Panel_19_1.Click
        Color_Registro(18, 0)
    End Sub

    Private Sub Panel_19_2_Click(sender As Object, e As EventArgs) Handles Panel_19_2.Click
        Color_Registro(18, 1)
    End Sub

    Private Sub Panel_19_3_Click(sender As Object, e As EventArgs) Handles Panel_19_3.Click
        Color_Registro(18, 2)
    End Sub

    Private Sub Panel_19_4_Click(sender As Object, e As EventArgs) Handles Panel_19_4.Click
        Color_Registro(18, 3)
    End Sub

    Private Sub Panel_19_5_Click(sender As Object, e As EventArgs) Handles Panel_19_5.Click
        Color_Registro(18, 4)
    End Sub

    Private Sub Panel_19_6_Click(sender As Object, e As EventArgs) Handles Panel_19_6.Click
        Color_Registro(18, 5)
    End Sub

    Private Sub Panel_19_7_Click(sender As Object, e As EventArgs) Handles Panel_19_7.Click
        Color_Registro(18, 6)
    End Sub

    Private Sub Panel_19_8_Click(sender As Object, e As EventArgs) Handles Panel_19_8.Click
        Color_Registro(18, 7)
    End Sub

    Private Sub Panel_19_9_Click(sender As Object, e As EventArgs) Handles Panel_19_9.Click
        Color_Registro(18, 8)
    End Sub

    Private Sub Panel_19_10_Click(sender As Object, e As EventArgs) Handles Panel_19_10.Click
        Color_Registro(18, 9)
    End Sub

    Private Sub Panel_20_1_Click(sender As Object, e As EventArgs) Handles Panel_20_1.Click
        Color_Registro(19, 0)
    End Sub

    Private Sub Panel_20_2_Click(sender As Object, e As EventArgs) Handles Panel_20_2.Click
        Color_Registro(19, 1)
    End Sub

    Private Sub Panel_20_3_Click(sender As Object, e As EventArgs) Handles Panel_20_3.Click
        Color_Registro(19, 2)
    End Sub

    Private Sub Panel_20_4_Click(sender As Object, e As EventArgs) Handles Panel_20_4.Click
        Color_Registro(19, 3)
    End Sub

    Private Sub Panel_20_5_Click(sender As Object, e As EventArgs) Handles Panel_20_5.Click
        Color_Registro(19, 4)
    End Sub

    Private Sub Panel_20_6_Click(sender As Object, e As EventArgs) Handles Panel_20_6.Click
        Color_Registro(19, 5)
    End Sub

    Private Sub Panel_20_7_Click(sender As Object, e As EventArgs) Handles Panel_20_7.Click
        Color_Registro(19, 6)
    End Sub

    Private Sub Panel_20_8_Click(sender As Object, e As EventArgs) Handles Panel_20_8.Click
        Color_Registro(19, 7)
    End Sub

    Private Sub Panel_20_9_Click(sender As Object, e As EventArgs) Handles Panel_20_9.Click
        Color_Registro(19, 8)
    End Sub

    Private Sub Panel_20_10_Click(sender As Object, e As EventArgs) Handles Panel_20_10.Click
        Color_Registro(19, 9)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub TextBox_Color_Rojo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Color_Rojo.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
            Bandera_Nuevo_Caracter = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Color_Rojo_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Color_Rojo.TextChanged
        If Bandera_Nuevo_Caracter = True Then
            Bandera_Nuevo_Caracter = False
            If TextBox_Color_Rojo.Text = "" Then
                TextBox_Color_Rojo.Text = "0"
            ElseIf Convert.ToInt32(TextBox_Color_Rojo.Text) > 255 Then
                TextBox_Color_Rojo.Text = "255"
            ElseIf Convert.ToInt32(TextBox_Color_Rojo.Text) < 0 Then
                TextBox_Color_Rojo.Text = "0"
            End If
            Dim Rojo, Verde, Azul As Integer
            If TextBox_Color_Rojo.Text = "" Or TextBox_Color_Verde.Text = "" Or TextBox_Color_Azul.Text = "" Then
            Else
                Rojo = Convert.ToInt16(TextBox_Color_Rojo.Text)
                Verde = Convert.ToInt16(TextBox_Color_Verde.Text)
                Azul = Convert.ToInt16(TextBox_Color_Azul.Text)
                Panel_Muestra.BackColor = Color.FromArgb(255, Rojo, Verde, Azul)
            End If
        End If
    End Sub

    Private Sub TextBox_Color_Verde_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Color_Verde.TextChanged
        If Bandera_Nuevo_Caracter = True Then
            Bandera_Nuevo_Caracter = False
            If TextBox_Color_Verde.Text = "" Then
                TextBox_Color_Verde.Text = "0"
            ElseIf Convert.ToInt32(TextBox_Color_Verde.Text) > 255 Then
                TextBox_Color_Verde.Text = "255"
            ElseIf Convert.ToInt32(TextBox_Color_Verde.Text) < 0 Then
                TextBox_Color_Verde.Text = "0"
            End If
            Dim Rojo, Verde, Azul As Integer
            If TextBox_Color_Rojo.Text = "" Or TextBox_Color_Verde.Text = "" Or TextBox_Color_Azul.Text = "" Then
            Else
                Rojo = Convert.ToInt16(TextBox_Color_Rojo.Text)
                Verde = Convert.ToInt16(TextBox_Color_Verde.Text)
                Azul = Convert.ToInt16(TextBox_Color_Azul.Text)
                Panel_Muestra.BackColor = Color.FromArgb(255, Rojo, Verde, Azul)
            End If
        End If
    End Sub

    Private Sub TextBox_Color_Azul_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Color_Azul.TextChanged
        If Bandera_Nuevo_Caracter = True Then
            Bandera_Nuevo_Caracter = False
            If TextBox_Color_Azul.Text = "" Then
                TextBox_Color_Azul.Text = "0"
            ElseIf Convert.ToInt32(TextBox_Color_Azul.Text) > 255 Then
                TextBox_Color_Azul.Text = "255"
            ElseIf Convert.ToInt32(TextBox_Color_Azul.Text) < 0 Then
                TextBox_Color_Azul.Text = "0"
            End If
            Dim Rojo, Verde, Azul As Integer
            If TextBox_Color_Rojo.Text = "" Or TextBox_Color_Verde.Text = "" Or TextBox_Color_Azul.Text = "" Then
            Else
                Rojo = Convert.ToInt16(TextBox_Color_Rojo.Text)
                Verde = Convert.ToInt16(TextBox_Color_Verde.Text)
                Azul = Convert.ToInt16(TextBox_Color_Azul.Text)
                Panel_Muestra.BackColor = Color.FromArgb(255, Rojo, Verde, Azul)
            End If
        End If
    End Sub

    Private Sub TextBox_Color_Verde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Color_Verde.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
            Bandera_Nuevo_Caracter = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Color_Azul_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Color_Azul.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
            Bandera_Nuevo_Caracter = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        UserControl_Modulo_Graficar_Invocador.Panel_Color_Registro_Graficado.BackColor = Panel_Muestra.BackColor
        Me.Close()
    End Sub


    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Aceptar.MouseEnter, Button_Cancelar.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Aceptar.MouseLeave, Button_Cancelar.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde
    End Sub
End Class