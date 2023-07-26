Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Class_Analisis_Registro

    Public Const Valor_Max_Tabla = 1000000
    Public Enum Tipos_QRS
        Sin_QRS = 0
        Qr_0 = 1
        qR_1 = 2
        Qrs_0 = 3
        qRs_1 = 4
        R_0 = 5
        Rs_0 = 6
        QS_0 = 7
        Qr_E_0 = 8
        Qrs_E_0 = 9
        qRs_E_1 = 10
        RS_E_0 = 11
    End Enum

    Const Procedimiento_Filtrando_Señal = 1
    Const Procedimiento_Trasnformada_Wavelet = 2
    Const Procedimiento_Deteccion_QRS = 3
    Const Procedimiento_Correcion_Puntos_Complejo_QRS = 6
    Const Procedimiento_Busqueda_Complejo_QRS_No_Detectados = 7
    Const Procedimiento_Calculo_Intervalo = 8
    Const Procedimiento_Calculo_Intervalo_RR = 9


    Public Shared Coeficientes_Filtro_b_Butterworth_2Hz_45Hz As Double(,) = {{0.220693285809031, 3.31039928713546, 23.1727950099482, 100.415445043109, 301.246335129327, 662.741937284519, 1104.5698954742, 1420.16129418111, 1420.16129418111, 1104.5698954742, 662.741937284519, 301.246335129327, 100.415445043109, 23.1727950099482, 3.31039928713546, 0.220693285809031},
                                   {0.00135930924385637, 0.0203896386578456, 0.142727470604919, 0.618485705954651, 1.85545711786395, 4.08200565930069, 6.80334276550116, 8.74715498421577, 8.74715498421577, 6.80334276550116, 4.08200565930069, 1.85545711786395, 0.618485705954651, 0.142727470604919, 0.0203896386578456, 0.00135930924385637},
                                    {0.00004550543915007, 0.00068258158725105, 0.00477807111075735, 0.0207049748132819, 0.0621149244398456, 0.13665283376766, 0.2277547229461, 0.292827500930701, 0.292827500930701, 0.2277547229461, 0.13665283376766, 0.0621149244398456, 0.0207049748132819, 0.00477807111075735, 0.00068258158725105, 0.00004550543915007},
                                    {0.00000320558701312387, 0.000048083805196858, 0.000336586636378006, 0.00145854209097136, 0.00437562627291408, 0.00962637780041097, 0.016043963000685, 0.0206279524294521, 0.0206279524294521, 0.016043963000685, 0.00962637780041097, 0.00437562627291408, 0.00145854209097136, 0.000336586636378006, 0.000048083805196858, 0.00000320558701312387},
                                    {0.000000352555588581208, 0.00000528833382871812, 0.0000370183368010269, 0.00016041279280445, 0.000481238378413349, 0.00105872443250937, 0.00176454072084895, 0.00226869521252007, 0.00226869521252007, 0.00176454072084895, 0.00105872443250937, 0.000481238378413349, 0.00016041279280445, 0.0000370183368010269, 0.00000528833382871812, 0.000000352555588581208},
                                    {0.0000000526385454266808, 0.000000789578181400213, 0.00000552704726980149, 0.0000239505381691398, 0.0000718516145074194, 0.000158073551916323, 0.000263455919860538, 0.000338729039820691, 0.000338729039820691, 0.000263455919860538, 0.000158073551916323, 0.0000718516145074194, 0.0000239505381691398, 0.00000552704726980149, 0.000000789578181400213, 0.0000000526385454266808},
                                    {0.0000000098537772016681, 0.000000147806658025022, 0.00000103464660617515, 0.00000448346862675899, 0.000013450405880277, 0.0000295908929366093, 0.0000493181548943489, 0.0000634090562927343, 0.0000634090562927343, 0.0000493181548943489, 0.0000295908929366093, 0.000013450405880277, 0.00000448346862675899, 0.00000103464660617515, 0.000000147806658025022, 0.0000000098537772016681},
                                    {0.00000000219856464655088, 0.0000000329784696982631, 0.000000230849287887842, 0.00000100034691418065, 0.00000300104074254194, 0.00000660228963359228, 0.0000110038160559871, 0.0000141477635005549, 0.0000141477635005549, 0.0000110038160559871, 0.00000660228963359228, 0.00000300104074254194, 0.00000100034691418065, 0.000000230849287887842, 0.0000000329784696982631, 0.00000000219856464655088},
                                    {0.000000000564752316694269, 0.00000000847128475041404, 0.0000000592989932528983, 0.000000256962304095893, 0.000000770886912287677, 0.00000169595120703289, 0.00000282658534505482, 0.00000363418115792762, 0.00000363418115792762, 0.00000282658534505482, 0.00000169595120703289, 0.000000770886912287677, 0.000000256962304095893, 0.0000000592989932528983, 0.00000000847128475041404, 0.000000000564752316694269},
                                    {0.00000000016289578153209, 0.00000000244343672298136, 0.0000000171040570608695, 0.0000000741175805971012, 0.000000222352741791303, 0.000000489176031940868, 0.000000815293386568113, 0.000001048234354159, 0.000001048234354159, 0.000000815293386568113, 0.000000489176031940868, 0.000000222352741791303, 0.0000000741175805971012, 0.0000000171040570608695, 0.00000000244343672298136, 0.00000000016289578153209},
                                    {0.0000000000517816328298614, 0.000000000776724492447921, 0.00000000543707144713545, 0.0000000235606429375869, 0.0000000706819288127608, 0.000000155500243388074, 0.000000259167072313456, 0.000000333214807260158, 0.000000333214807260158, 0.000000259167072313456, 0.000000155500243388074, 0.0000000706819288127608, 0.0000000235606429375869, 0.00000000543707144713545, 0.000000000776724492447921, 0.0000000000517816328298614},
                                    {0.000000000017881341686274, 0.00000000026822012529411, 0.00000000187754087705877, 0.00000000813601046725466, 0.000000024408031401764, 0.0000000536976690838807, 0.0000000894961151398012, 0.000000115066433751173, 0.000000115066433751173, 0.0000000894961151398012, 0.0000000536976690838807, 0.000000024408031401764, 0.00000000813601046725466, 0.00000000187754087705877, 0.00000000026822012529411, 0.000000000017881341686274},
                                    {0.00000000000663206956969767, 0.0000000000994810435454651, 0.000000000696367304818256, 0.00000000301759165421244, 0.00000000905277496263732, 0.0000000199161049178021, 0.0000000331935081963369, 0.0000000426773676810045, 0.0000000426773676810045, 0.0000000331935081963369, 0.0000000199161049178021, 0.00000000905277496263732, 0.00000000301759165421244, 0.000000000696367304818256, 0.0000000000994810435454651, 0.00000000000663206956969767},
                                    {0.00000000000261790984432185, 0.0000000000392686476648278, 0.000000000274880533653794, 0.00000000119114897916644, 0.00000000357344693749933, 0.00000000786158326249852, 0.0000000131026387708309, 0.0000000168462498482111, 0.0000000168462498482111, 0.0000000131026387708309, 0.00000000786158326249852, 0.00000000357344693749933, 0.00000000119114897916644, 0.000000000274880533653794, 0.0000000000392686476648278, 0.00000000000261790984432185},
                                    {0.00000000000109164111398389, 0.0000000000163746167097583, 0.000000000114622316968308, 0.00000000049669670686267, 0.00000000149009012058801, 0.00000000327819826529362, 0.00000000546366377548937, 0.00000000702471056848633, 0.00000000702471056848633, 0.00000000546366377548937, 0.00000000327819826529362, 0.00000000149009012058801, 0.00000000049669670686267, 0.000000000114622316968308, 0.0000000000163746167097583, 0.00000000000109164111398389},
                                    {0.000000000000477895775388574, 0.0000000000071684366308286, 0.0000000000501790564158002, 0.000000000217442577801801, 0.000000000652327733405403, 0.00000000143512101349189, 0.00000000239186835581981, 0.00000000307525931462547, 0.00000000307525931462547, 0.00000000239186835581981, 0.00000000143512101349189, 0.000000000652327733405403, 0.000000000217442577801801, 0.0000000000501790564158002, 0.0000000000071684366308286, 0.000000000000477895775388574},
                                    {0.000000000000218513165325734, 0.00000000000327769747988601, 0.0000000000229438823592021, 0.000000000099423490223209, 0.000000000298270470669627, 0.000000000656195035473179, 0.0000000010936583924553, 0.0000000014061322188711, 0.0000000014061322188711, 0.0000000010936583924553, 0.000000000656195035473179, 0.000000000298270470669627, 0.000000000099423490223209, 0.0000000000229438823592021, 0.00000000000327769747988601, 0.000000000000218513165325734},
                                    {0.00000000000010389340212788, 0.00000000000155840103191821, 0.0000000000109088072234274, 0.0000000000472714979681856, 0.000000000141814493904557, 0.000000000311991886590025, 0.000000000519986477650041, 0.00000000066855404269291, 0.00000000066855404269291, 0.000000000519986477650041, 0.000000000311991886590025, 0.000000000141814493904557, 0.0000000000472714979681856, 0.0000000000109088072234274, 0.00000000000155840103191821, 0.00000000000010389340212788},
                                    {0.0000000000000511643814338561, 0.000000000000767465721507842, 0.00000000000537226005055489, 0.0000000000232797935524045, 0.0000000000698393806572136, 0.00000000015364663744587, 0.00000000025607772907645, 0.000000000329242794526864, 0.000000000329242794526864, 0.00000000025607772907645, 0.00000000015364663744587, 0.0000000000698393806572136, 0.0000000000232797935524045, 0.00000000000537226005055489, 0.000000000000767465721507842, 0.0000000000000511643814338561}}
    Public Shared Coeficientes_Filtro_a_Butterworth_2Hz_45Hz As Double(,) = {{1.0, 11.994867831229, 67.3936805542597, 235.242873544265, 570.422488582759, 1017.65697157711, 1379.74736465136, 1447.46816618977, 1184.51746287032, 756.052713027703, 373.283785865026, 139.988930328003, 38.5970627348106, 7.38556666710311, 0.876949440202926, 0.0487055264011864},
                                    {1.0, 2.99489932436201, 6.05325661389571, 8.3169895556241, 8.90849316076588, 7.47441605453859, 5.08971789865631, 2.80822881749483, 1.26475837157028, 0.46040518828142, 0.13416731212267, 0.0305592817398725, 0.0052589061032353, 0.000643067831192413, 0.0000499021051445619, 0.00000184759442610031},
                                    {1.0, -1.49731984117928, 3.03641188552391, -2.95157206451262, 3.03987968418815, -2.03871414573537, 1.32212011959137, -0.619847354786909, 0.26586928799048, -0.0852898049889622, 0.0237449921983022, -0.00488250964508446, 0.000805959017302175, -0.0000905093806668791, 0.00000676476777517853, -0.000000232978900182082},
                                    {1.0, -4.19330934229958, 9.92233201159933, -15.9917474518362, 19.2814424258385, -18.0945027396078, 13.5332751221965, -8.15079278973645, 3.96519211246326, -1.55118425778468, 0.482372420971607, -0.116757242895382, 0.02124319749805, -0.00273707355193838, 0.000222920454510493, -0.00000863806370681207},
                                    {1.0, -5.99173138510749, 18.1715705306676, -36.162468712266, 52.2150954158991, -57.5045903884902, 49.6311048188208, -34.0434623158489, 18.6507757795969, -8.13960770252023, 2.80058741696916, -0.74467548285251, 0.147893915606344, -0.0206826111883799, 0.00181902901199881, -0.0000757667715952129},
                                    {1.0, -7.2770202019102, 25.8790818855355, -59.1291776055052, 96.5147104204375, -118.721326151008, 113.334560231764, -85.2860820163612, 50.9038556195824, -24.0570475933256, 8.91596015312472, -2.54168064897718, 0.538900837086593, -0.0801528352487511, 0.00747157611895848, -0.000328811458056233},
                                    {1.0, -8.24139770852631, 32.6638177299216, -82.2205598836906, 146.527942889858, -195.351561943763, 200.880818582235, -161.9767440983, 103.117184539612, -51.7693352082972, 20.3088307874023, -6.10830502263525, 1.36245572855096, -0.212613971270271, 0.0207438297078487, -0.00095336223485143},
                                    {1.0, -8.99171192409114, 38.5415076752719, -104.200754691812, 198.330303432564, -281.059601633865, 305.954104634443, -260.228272703338, 174.198290055018, -91.7001313476716, 37.6237545386877, -11.8079877915081, 2.74246787612871, -0.444771385568148, 0.0450181857064446, -0.00214287739885234},
                                    {1.0, -9.59211126793686, 43.6250170838789, -124.591508927096, 249.566948661137, -370.995017367531, 422.436868587416, -374.885747029355, 261.242670051361, -142.868924777282, 60.7840647661839, -19.7480565275203, 4.74058117234399, -0.793489670253583, 0.082780026313296, -0.00405627585489718},
                                    {1.0, -10.0834404172297, 48.0379940095002, -143.278648799621, 298.941390697504, -461.818177016945, 545.351143687257, -500.982354558282, 360.786067445664, -203.592917671098, 89.25365333697, -29.840897698714, 7.36295385424762, -1.26535783486105, 0.135394384328825, -0.00679808095199101},
                                    {1.0, -10.4929421975618, 51.8908439057062, -160.313843204555, 345.807231381465, -551.366130621491, 670.967401776179, -634.307362783816, 469.490789796803, -271.97721686505, 122.26997295766, -41.8788918086034, 10.5759782617213, -1.85861546283639, 0.203203482273215, -0.0104169211129223},
                                    {1.0, -10.8394845497686, 55.27602253833, -175.817849840809, 389.901106283839, -638.308607379922, 796.624937301074, -771.522019092858, 584.443818211842, -346.193126315961, 159.003714034605, -55.5956072399985, 14.3219543826113, -2.56570256422065, 0.285758756036761, -0.0149139388644844},
                                    {1.0, -11.1365490275889, 58.2692017064598, -189.933948735517, 431.178838498981, -721.8789017934, 920.494023575345, -910.085590369411, 703.240257934079, -424.610036833788, 198.652812621188, -70.7077564230222, 18.5314032580822, -3.37557116754835, 0.382071568947611, -0.0202545954876662},
                                    {1.0, -11.3940248146879, 60.9319043552007, -202.806066321261, 469.717350667194, -801.682215076477, 1041.36109603167, -1048.12106345033, 823.96374017798, -505.840832553928, 240.490304757132, -86.9407547400681, 23.1315823956351, -4.27547061888504, 0.490829483989947, -0.0263802073850672},
                                    {1.0, -11.6193304950744, 63.3141803155584, -214.569083012075, 505.656610143086, -877.564589641148, 1158.45746188105, -1184.27697165966, 945.125336408788, -588.741488171184, 283.883417451629, -104.042527614757, 28.0518369118036, -5.2521971311666, 0.610562278936681, -0.0332176300092368},
                                    {1.0, -11.8181401926967, 65.4569112701114, -225.345142635952, 539.165577034781, -949.524998178367, 1271.33016369163, -1317.60636871329, 1065.59184389551, -672.389222765556, 328.296230449816, -121.789664123163, 33.2266385772496, -6.29290129465706, 0.739759690049612, -0.0406866898045525},
                                    {1.0, -11.994867831229, 67.3936805542599, -235.242873544265, 570.422488582761, -1017.65697157711, 1379.74736465137, -1447.46816618978, 1184.51746287033, -756.052713027712, 373.28378586503, -139.988930328005, 38.5970627348112, -7.38556666710322, 0.876949440202941, -0.0487055264011873},
                                    {1.0, -12.1529985685765, 69.1522529624693, -244.357963681025, 599.603705212129, -1082.11009128319, 1483.63009453161, -1573.44967255338, 1301.28425940667, -839.161337318303, 418.482355516081, -158.476167288954, 44.1112711864218, -8.51925912049805, 1.02074521576619, -0.0571942138116799},
                                    {1.0, -12.2953208610798, 70.755735028868, -252.774303572841, 626.877667787334, -1143.06474021933, 1583.00344879745, -1695.30706190251, 1415.45265731415, -921.276723975483, 463.59852985404, -177.113858944429, 49.7243989846499, -9.68422436425333, 1.16987313448119, -0.0660770593638975}}
    Public Structure Configuracion_Deteccion_QRS_1
        'Parametros de relacion en la busqueda de complejos QRS
        Public m_Comparacion_Wavelet_QRS As Double 'tang 45°=1 Pendiente de comparacion Para deterla busqueda de punos significativos  
        Public Margen_Separacion_QRS_Ruido As Double 'Establece el limite de cuanto pude crecer la amplitud de P_Max_Central con respecto a Valor_Promedio_P_Max sin considerarse ruido 
        Public Margen_Separacion_Desniveles As Double 'Establece  la relacion minima entre P_Max_Central y uno de los minimos para direnciar los cambios de nivel en la señal y un QRS
        Public Margen_Actualizacion_R_Promedio As Double 'Limite maximo de un P_Max_Central para poder actualizar el Valor_Promedio_P_Max
        Public Cantidad_Latido_Ectopico As Double 'Cantidad de posibles latidos Ectopicos antes de actulizar Vector_Valor_P_Max  

        Public PorCiento_Comparacion_QRS As Double 'Determian el cuanto se reduce margen Valor_Promedio_P_Max en % para asignarselo a Valor_P_Max
        Public PorCiento_Comparacion_Busqueda_QRS As Double 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW entre P_Max_Izquierda y P_Max_Derecha 
        Public PorCiento_Comparacion_Busqueda_Extremos_QRS As Double 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW fuera de lso puntos P_Max_Izquierda y P_Max_Derecha 
        Public PorCiento_Rechazo_Extremos As Double

        Public Duracion_Maxima_QRS As Double 'Duarcion Maxima que puede tener un QRS
        Public Duracion_Minima_QRS As Double 'Duarcion Minima que puede tener un QRS
        Public Separacion_Minima_QRS As Double 'En segundos =200ms Separacion minima de debe existir entre dos QRS consecutivos de 200 ms 
        Public Demora_Despues_QRS As Double 'Demora_Despues_QRS*frecuencia desplasamiento despues de detectar un QRS   

        Public Cantida_Datos_TW As Double 'Cantidad Maxima de datos ledias de para ser prosesada  
        Public Cantida_Datos_Retenidos As Double 'el quivalente a 3 segundos Math.Floor(Cantida_Datos_Retenidos * Frecuencia) de datos alamcenadades para ser prosesada         Static Reset_Limite_Max_Min As Int32    'Limite de tiempo sin detectar un QRS para resetear  Limite_Max y Limite_Min

        Public Frecuencia_Baja_Filtro As Double 'Frecuencia pasa Baja del Filtro pasa banda
        Public Frecuencia_Alta_Filtro As Double 'Frecuencia pasa Alta del Filtro pasa banda
        Public Escala_TW_QRS As Double 'Escala de la TW empleda para el analisis del QRS

    End Structure
    Public Shared Function Tipo_Onda_P_QRS_T_To_int(Onda As String)
        Select Case Onda
            Case "Sin_QRS"
                Return 0
            Case "Qr"
                Return 1
            Case "qR"
                Return 2
            Case "Qrs"
                Return 3
            Case "qRs"
                Return 4
            Case "R"
                Return 5
            Case "Rs"
                Return 6
            Case "QS"
                Return 7
            Case "Qr_E"
                Return 8
            Case "Qrs_E"
                Return 9
            Case "qRs_E"
                Return 10
            Case "RS_E"
                Return 11
            Case Else
                Return 0
        End Select
    End Function
    Public Shared Function Tipo_Onda_QRS_To_String(Onda As Int16)
        Select Case Onda
            Case 0
                Return "Sin_QRS"
            Case 1
                Return "Qr"
            Case 2
                Return "qR"
            Case 3
                Return "Qrs"
            Case 4
                Return "qRs"
            Case 5
                Return "R"
            Case 6
                Return "Rs"
            Case 7
                Return "QS"
            Case 8
                Return "Qr_E"
            Case 9
                Return "Qrs_E"
            Case 10
                Return "qRs_E"
            Case 11
                Return "RS_E"
            Case Else
                Return ""
        End Select
    End Function
    Public Shared Function Derivada_To_int(Derivada As String)
        Select Case Derivada
            Case "DI"
                Return 1
            Case "DII"
                Return 2
            Case "DIII"
                Return 3
            Case "aVF"
                Return 4
            Case "aVL"
                Return 5
            Case "aVR"
                Return 6
            Case "V1"
                Return 7
            Case "V2"
                Return 8
            Case "V3"
                Return 9
            Case "V4"
                Return 10
            Case "V5"
                Return 11
            Case "V6"
                Return 12
            Case Else
                Return 13
        End Select
    End Function
    Public Shared Function Derivada_To_String(Derivada As Int16)
        Select Case Derivada
            Case 1
                Return "DI"
            Case 2
                Return "DII"
            Case 3
                Return "DIII"
            Case 4
                Return "aVF"
            Case 5
                Return "aVL"
            Case 6
                Return "aVR"
            Case 7
                Return "V1"
            Case 8
                Return "V2"
            Case 9
                Return "V3"
            Case 10
                Return "V4"
            Case 11
                Return "V5"
            Case 12
                Return "V6"
            Case Else
                Return "XX"
        End Select
    End Function
    Public Function Transformada_Wavelet_Reset_Escala(Escala As Int16)
        'Pone en cero todos los coeficientes de la Transformada Wavelet selecionada
        'Escala = 0 o Escala > 10  se resetean todas las escalas de la Transformada Wavelet
        'Escala > 0 o Escala < 10 se resetena la escala de la Transformada Wavelet correspondiente
        Select Case Escala
            Case 1
                Dim Temp As Double
                For Index1 = 1 To 100
                    Temp = Transformada_Wavelet_Parte_1(0)
                    Temp = Transformada_Wavelet_Parte_2_Escala_1(Temp)
                    Transformada_Wavelet_Parte_3_Escala_1(Temp)
                Next
            Case 2
                Dim Temp As Double
                For Index1 = 1 To 100
                    Temp = Transformada_Wavelet_Parte_1(0)
                    Temp = Transformada_Wavelet_Parte_2_Escala_2(Temp)
                    Transformada_Wavelet_Parte_3_Escala_2(Temp)
                Next
            Case 3
                Dim Temp As Double
                For Index1 = 1 To 100
                    Temp = Transformada_Wavelet_Parte_1(0)
                    Temp = Transformada_Wavelet_Parte_2_Escala_3(Temp)
                    Transformada_Wavelet_Parte_3_Escala_3(Temp)
                Next
            Case 4
                Dim Temp As Double
                For Index1 = 1 To 100
                    Temp = Transformada_Wavelet_Parte_1(0)
                    Temp = Transformada_Wavelet_Parte_2_Escala_4(Temp)
                    Transformada_Wavelet_Parte_3_Escala_4(Temp)
                Next
            Case 5
                Dim Temp As Double
                For Index1 = 1 To 100
                    Temp = Transformada_Wavelet_Parte_1(0)
                    Temp = Transformada_Wavelet_Parte_2_Escala_5(Temp)
                    Transformada_Wavelet_Parte_3_Escala_5(Temp)
                Next
            Case 6
                Dim Temp As Double
                For Index1 = 1 To 100
                    Temp = Transformada_Wavelet_Parte_1(0)
                    Temp = Transformada_Wavelet_Parte_2_Escala_6(Temp)
                    Transformada_Wavelet_Parte_3_Escala_6(Temp)
                Next
            Case 7
                Dim Temp As Double
                For Index1 = 1 To 100
                    Temp = Transformada_Wavelet_Parte_1(0)
                    Temp = Transformada_Wavelet_Parte_2_Escala_7(Temp)
                    Transformada_Wavelet_Parte_3_Escala_7(Temp)
                Next
            Case 8
                Dim Temp As Double
                For Index1 = 1 To 100
                    Temp = Transformada_Wavelet_Parte_1(0)
                    Temp = Transformada_Wavelet_Parte_2_Escala_8(Temp)
                    Transformada_Wavelet_Parte_3_Escala_8(Temp)
                Next
            Case 9
                Dim Temp As Double
                For Index1 = 1 To 100
                    Temp = Transformada_Wavelet_Parte_1(0)
                    Temp = Transformada_Wavelet_Parte_2_Escala_9(Temp)
                    Transformada_Wavelet_Parte_3_Escala_9(Temp)
                Next
            Case 10
                Dim Temp As Double
                For Index1 = 1 To 100
                    Temp = Transformada_Wavelet_Parte_1(0)
                    Temp = Transformada_Wavelet_Parte_2_Escala_10(Temp)
                    Transformada_Wavelet_Parte_3_Escala_10(Temp)
                Next
            Case Else
                Dim Temp1, Temp2, Temp3, Temp4, Temp5, Temp6, Temp7, Temp8, Temp9, Temp10 As Double
                For Index1 = 1 To 100
                    Temp1 = Transformada_Wavelet_Parte_1(0)
                    Temp1 = Transformada_Wavelet_Parte_2_Escala_1(Temp1)
                    Transformada_Wavelet_Parte_3_Escala_1(Temp1)

                    Temp2 = Transformada_Wavelet_Parte_1(0)
                    Temp2 = Transformada_Wavelet_Parte_2_Escala_2(Temp2)
                    Transformada_Wavelet_Parte_3_Escala_2(Temp2)

                    Temp3 = Transformada_Wavelet_Parte_1(0)
                    Temp3 = Transformada_Wavelet_Parte_2_Escala_3(Temp3)
                    Transformada_Wavelet_Parte_3_Escala_3(Temp3)

                    Temp4 = Transformada_Wavelet_Parte_1(0)
                    Temp4 = Transformada_Wavelet_Parte_2_Escala_4(Temp4)
                    Transformada_Wavelet_Parte_3_Escala_4(Temp4)

                    Temp5 = Transformada_Wavelet_Parte_1(0)
                    Temp5 = Transformada_Wavelet_Parte_2_Escala_5(Temp5)
                    Transformada_Wavelet_Parte_3_Escala_5(Temp5)

                    Temp6 = Transformada_Wavelet_Parte_1(0)
                    Temp6 = Transformada_Wavelet_Parte_2_Escala_6(Temp6)
                    Transformada_Wavelet_Parte_3_Escala_6(Temp6)

                    Temp7 = Transformada_Wavelet_Parte_1(0)
                    Temp7 = Transformada_Wavelet_Parte_2_Escala_7(Temp7)
                    Transformada_Wavelet_Parte_3_Escala_7(Temp7)

                    Temp8 = Transformada_Wavelet_Parte_1(0)
                    Temp8 = Transformada_Wavelet_Parte_2_Escala_8(Temp8)
                    Transformada_Wavelet_Parte_3_Escala_8(Temp8)

                    Temp9 = Transformada_Wavelet_Parte_1(0)
                    Temp9 = Transformada_Wavelet_Parte_2_Escala_9(Temp9)
                    Transformada_Wavelet_Parte_3_Escala_9(Temp9)

                    Temp10 = Transformada_Wavelet_Parte_1(0)
                    Temp10 = Transformada_Wavelet_Parte_2_Escala_10(Temp10)
                    Transformada_Wavelet_Parte_3_Escala_10(Temp10)

                Next

        End Select

    End Function

    Public Function Transformada_Wavelet_Escala_1(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Max_Puntero As Int64, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        Dim Cantidad_Datos_Max As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos ledias de para ser prosesada

        Const Divisor_Trasn_Wavelet = 5 'Corrector de Amplitud de la señal
        Const Correcion_Desplazamiento = 4 'Corrector de retardo

        Dim Temp_y As Double
        Dim Cantidad_Datos_Leidos As Int32
        Dim Puntero As Int32 = 0
        Dim Datos_Lectura_Registro As DataSet
        'Tabla temporal para lamacenar los datos andes de envialos a la base de datos
        Dim Tabla_Datos As New DataTable()
        'Incerta las nuevas columnas de las derivaciones a calcula en tabla de datos
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn(Nombre_Columna, GetType(System.Double)))
        If Progreso.CancellationPending = True Then
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()
            Return False
        End If
        Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero / Max_Puntero * 100)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        'Primera lectura de Datos
        Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
        Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count
        If Cantidad_Datos_Leidos > 1 Then
            'Iniciar el procesamiento
            'Correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_1(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_1(Temp_y) / Divisor_Trasn_Wavelet
                Puntero = Puntero + 1
            Next Index
            'Calculo de la TW sin retardo
            For Index = Correcion_Desplazamiento + 1 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1

                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_1(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_1(Temp_y) / Divisor_Trasn_Wavelet

                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno la primera Ronda de Datos
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Compruebo solicitud de cancelacion
            If Progreso.CancellationPending = True Then
                'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()
                Return False
            End If
            'Reporto el progreso 
            Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

            'Segunda lectura de Datos
            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            While Cantidad_Datos_Leidos > 1 And (Puntero - Correcion_Desplazamiento - 1) <= Max_Puntero
                'Calculo de la TW sin retardo
                For Index = 0 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1
                    Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                    Temp_y = Transformada_Wavelet_Parte_2_Escala_1(Temp_y)
                    Temp_y = Transformada_Wavelet_Parte_3_Escala_1(Temp_y) / Divisor_Trasn_Wavelet
                    Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                    Puntero = Puntero + 1
                Next Index
                'Almacenamietno ciclico de los Datos
                Try
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Compruebo solicitud de cancelacion
                If Progreso.CancellationPending = True Then
                    'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Return False
                End If
                'Reporto el progreso 
                Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                'Lectura Ciclica de Datos
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            End While
            'Agrego la correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(0)
                Temp_y = Transformada_Wavelet_Parte_2_Escala_1(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_1(Temp_y) / Divisor_Trasn_Wavelet
                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno los datos del retardo
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
            'Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Almacenamiento_Resultados)

            'If (Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")) = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados) Then
            '    'Agregar una nueva columna en la trasformada wavelet
            '    Class_Funciones_Base_Datos.Sobre_Escribir_Columna(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados, Nombre_Columna)

            '    'Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna, "float")
            '    ''Actualizar la columna en la tabla final de la trasnformada Wavelet
            '    'Dim sql_Actualizaar As String = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN Temp Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero"
            '    'Dim cmd_Actualizar As New SqlCommand(sql_Actualizaar, Coneccion)
            '    'Try
            '    '    cmd_Actualizar.ExecuteNonQuery()
            '    'Catch ex As Exception
            '    '    MsgBox(ex.Message)
            '    'End Try
            'Else
            '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados)
            '    Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados)

            'End If
            'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")

        End If
        Datos_Lectura_Registro.Clear()
        Datos_Lectura_Registro.Dispose()
        Datos_Lectura_Registro.AcceptChanges()
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()

        Return True
    End Function
    Public Function Transformada_Wavelet_Escala_2(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Max_Puntero As Int64, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        Dim Cantidad_Datos_Max As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos ledias de para ser prosesada
        Const Divisor_Trasn_Wavelet = 50 'Corrector de Amplitud de la señal
        Const Correcion_Desplazamiento = 9 'Corrector de retardo

        Dim Temp_y As Double
        Dim Cantidad_Datos_Leidos As Int32
        Dim Puntero As Int32 = 0
        Dim Datos_Lectura_Registro As DataSet
        'Tabla temporal para lamacenar los datos andes de envialos a la base de datos
        Dim Tabla_Datos As New DataTable()
        'Incerta las nuevas columnas de las derivaciones a calcula en tabla de datos
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn(Nombre_Columna, GetType(System.Double)))
        If Progreso.CancellationPending = True Then
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()
            Return False
        End If
        Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero / Max_Puntero * 100)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        'Primera lectura de Datos
        Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
        Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count
        If Cantidad_Datos_Leidos > 1 Then
            'Iniciar el procesamiento
            'Correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_2(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_2(Temp_y) / Divisor_Trasn_Wavelet
                Puntero = Puntero + 1
            Next Index
            'Calculo de la TW sin retardo
            For Index = Correcion_Desplazamiento + 1 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1

                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_2(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_2(Temp_y) / Divisor_Trasn_Wavelet

                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno la primera Ronda de Datos
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Compruebo solicitud de cancelacion
            If Progreso.CancellationPending = True Then
                'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()
                Return False
            End If
            'Reporto el progreso 
            Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

            'Segunda lectura de Datos
            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            While Cantidad_Datos_Leidos > 1 And (Puntero - Correcion_Desplazamiento - 1) <= Max_Puntero
                'Calculo de la TW sin retardo
                For Index = 0 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1
                    Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                    Temp_y = Transformada_Wavelet_Parte_2_Escala_2(Temp_y)
                    Temp_y = Transformada_Wavelet_Parte_3_Escala_2(Temp_y) / Divisor_Trasn_Wavelet
                    Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                    Puntero = Puntero + 1
                Next Index
                'Almacenamietno ciclico de los Datos
                Try
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Compruebo solicitud de cancelacion
                If Progreso.CancellationPending = True Then
                    'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Return False
                End If
                'Reporto el progreso 
                Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                'Lectura Ciclica de Datos
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            End While
            'Agrego la correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(0)
                Temp_y = Transformada_Wavelet_Parte_2_Escala_2(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_2(Temp_y) / Divisor_Trasn_Wavelet
                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno los datos del retardo
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
            'Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Almacenamiento_Resultados)

            'If (Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")) = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados) Then
            '    'Agregar una nueva columna en la trasformada wavelet
            '    Class_Funciones_Base_Datos.Sobre_Escribir_Columna(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados, Nombre_Columna)

            '    'Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna, "float")
            '    ''Actualizar la columna en la tabla final de la trasnformada Wavelet
            '    'Dim sql_Actualizaar As String = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN Temp Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero"
            '    'Dim cmd_Actualizar As New SqlCommand(sql_Actualizaar, Coneccion)
            '    'Try
            '    '    cmd_Actualizar.ExecuteNonQuery()
            '    'Catch ex As Exception
            '    '    MsgBox(ex.Message)
            '    'End Try
            'Else
            '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados)
            '    Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados)

            'End If
            'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")

        End If
        Datos_Lectura_Registro.Clear()
        Datos_Lectura_Registro.Dispose()
        Datos_Lectura_Registro.AcceptChanges()
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()


        Return True
    End Function
    Public Function Transformada_Wavelet_Escala_3(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Max_Puntero As Int64, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        Dim Cantidad_Datos_Max As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos ledias de para ser prosesada

        Const Divisor_Trasn_Wavelet = 500 'Corrector de Amplitud de la señal
        Const Correcion_Desplazamiento = 14 'Corrector de retardo

        Dim Temp_y As Double
        Dim Cantidad_Datos_Leidos As Int32
        Dim Puntero As Int32 = 0
        Dim Datos_Lectura_Registro As DataSet
        'Tabla temporal para lamacenar los datos andes de envialos a la base de datos
        Dim Tabla_Datos As New DataTable()
        'Incerta las nuevas columnas de las derivaciones a calcula en tabla de datos
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn(Nombre_Columna, GetType(System.Double)))
        If Progreso.CancellationPending = True Then
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()
            Return False
        End If
        Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero / Max_Puntero * 100)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        'Primera lectura de Datos
        Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
        Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count
        If Cantidad_Datos_Leidos > 1 Then
            'Iniciar el procesamiento
            'Correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_3(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_3(Temp_y) / Divisor_Trasn_Wavelet
                Puntero = Puntero + 1
            Next Index
            'Calculo de la TW sin retardo
            For Index = Correcion_Desplazamiento + 1 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1

                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_3(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_3(Temp_y) / Divisor_Trasn_Wavelet

                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno la primera Ronda de Datos
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Compruebo solicitud de cancelacion
            If Progreso.CancellationPending = True Then
                'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()
                Return False
            End If
            'Reporto el progreso 
            Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

            'Segunda lectura de Datos
            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            While Cantidad_Datos_Leidos > 1 And (Puntero - Correcion_Desplazamiento - 1) <= Max_Puntero
                'Calculo de la TW sin retardo
                For Index = 0 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1
                    Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                    Temp_y = Transformada_Wavelet_Parte_2_Escala_3(Temp_y)
                    Temp_y = Transformada_Wavelet_Parte_3_Escala_3(Temp_y) / Divisor_Trasn_Wavelet
                    Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                    Puntero = Puntero + 1
                Next Index
                'Almacenamietno ciclico de los Datos
                Try
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Compruebo solicitud de cancelacion
                If Progreso.CancellationPending = True Then
                    'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Return False
                End If
                'Reporto el progreso 
                Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                'Lectura Ciclica de Datos
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            End While
            'Agrego la correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(0)
                Temp_y = Transformada_Wavelet_Parte_2_Escala_3(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_3(Temp_y) / Divisor_Trasn_Wavelet
                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno los datos del retardo
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
            'Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Almacenamiento_Resultados)

            'If (Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")) = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados) Then
            '    'Agregar una nueva columna en la trasformada wavelet
            '    Class_Funciones_Base_Datos.Sobre_Escribir_Columna(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados, Nombre_Columna)

            '    'Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna, "float")
            '    ''Actualizar la columna en la tabla final de la trasnformada Wavelet
            '    'Dim sql_Actualizaar As String = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN Temp Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero"
            '    'Dim cmd_Actualizar As New SqlCommand(sql_Actualizaar, Coneccion)
            '    'Try
            '    '    cmd_Actualizar.ExecuteNonQuery()
            '    'Catch ex As Exception
            '    '    MsgBox(ex.Message)
            '    'End Try
            'Else
            '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados)
            '    Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados)

            'End If
            'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")

        End If
        Datos_Lectura_Registro.Clear()
        Datos_Lectura_Registro.Dispose()
        Datos_Lectura_Registro.AcceptChanges()
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()


        Return True
    End Function
    Public Function Transformada_Wavelet_Escala_4(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Max_Puntero As Int64, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        Dim Cantidad_Datos_Max As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos ledias de para ser prosesada

        Const Divisor_Trasn_Wavelet = 2000 'Corrector de Amplitud de la señal
        Const Correcion_Desplazamiento = 19 'Corrector de retardo

        Dim Temp_y As Double
        Dim Cantidad_Datos_Leidos As Int32
        Dim Puntero As Int32 = 0
        Dim Datos_Lectura_Registro As DataSet
        'Tabla temporal para lamacenar los datos andes de envialos a la base de datos
        Dim Tabla_Datos As New DataTable()
        'Incerta las nuevas columnas de las derivaciones a calcula en tabla de datos
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn(Nombre_Columna, GetType(System.Double)))
        If Progreso.CancellationPending = True Then
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()
            Return False
        End If
        Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero / Max_Puntero * 100)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        'Primera lectura de Datos
        Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
        Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count
        If Cantidad_Datos_Leidos > 1 Then
            'Iniciar el procesamiento
            'Correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_4(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_4(Temp_y) / Divisor_Trasn_Wavelet
                Puntero = Puntero + 1
            Next Index
            'Calculo de la TW sin retardo
            For Index = Correcion_Desplazamiento + 1 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1

                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_4(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_4(Temp_y) / Divisor_Trasn_Wavelet

                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno la primera Ronda de Datos
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Compruebo solicitud de cancelacion
            If Progreso.CancellationPending = True Then
                'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()
                Return False
            End If
            'Reporto el progreso 
            Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

            'Segunda lectura de Datos
            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            While Cantidad_Datos_Leidos > 1 And (Puntero - Correcion_Desplazamiento - 1) <= Max_Puntero
                'Calculo de la TW sin retardo
                For Index = 0 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1
                    Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                    Temp_y = Transformada_Wavelet_Parte_2_Escala_4(Temp_y)
                    Temp_y = Transformada_Wavelet_Parte_3_Escala_4(Temp_y) / Divisor_Trasn_Wavelet
                    Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                    Puntero = Puntero + 1
                Next Index
                'Almacenamietno ciclico de los Datos
                Try
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Compruebo solicitud de cancelacion
                If Progreso.CancellationPending = True Then
                    'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Return False
                End If
                'Reporto el progreso 
                Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                'Lectura Ciclica de Datos
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            End While
            'Agrego la correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(0)
                Temp_y = Transformada_Wavelet_Parte_2_Escala_4(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_4(Temp_y) / Divisor_Trasn_Wavelet
                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno los datos del retardo
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
            'Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Almacenamiento_Resultados)

            'If (Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")) = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados) Then
            '    'Agregar una nueva columna en la trasformada wavelet
            '    Class_Funciones_Base_Datos.Sobre_Escribir_Columna(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados, Nombre_Columna)

            '    'Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna, "float")
            '    ''Actualizar la columna en la tabla final de la trasnformada Wavelet
            '    'Dim sql_Actualizaar As String = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN Temp Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero"
            '    'Dim cmd_Actualizar As New SqlCommand(sql_Actualizaar, Coneccion)
            '    'Try
            '    '    cmd_Actualizar.ExecuteNonQuery()
            '    'Catch ex As Exception
            '    '    MsgBox(ex.Message)
            '    'End Try
            'Else
            '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados)
            '    Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados)

            'End If
            'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")

        End If
        Datos_Lectura_Registro.Clear()
        Datos_Lectura_Registro.Dispose()
        Datos_Lectura_Registro.AcceptChanges()
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()


        Return True
    End Function
    Public Function Transformada_Wavelet_Escala_5(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Max_Puntero As Int64, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        Dim Cantidad_Datos_Max As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos ledias de para ser prosesada

        Const Divisor_Trasn_Wavelet = 4000 'Corrector de Amplitud de la señal
        Const Correcion_Desplazamiento = 24 'Corrector de retardo

        Dim Temp_y As Double
        Dim Cantidad_Datos_Leidos As Int32
        Dim Puntero As Int32 = 0
        Dim Datos_Lectura_Registro As DataSet
        'Tabla temporal para lamacenar los datos andes de envialos a la base de datos
        Dim Tabla_Datos As New DataTable()
        'Incerta las nuevas columnas de las derivaciones a calcula en tabla de datos
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn(Nombre_Columna, GetType(System.Double)))
        If Progreso.CancellationPending = True Then
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()
            Return False
        End If
        Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero / Max_Puntero * 100)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        'Primera lectura de Datos
        Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
        Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count
        If Cantidad_Datos_Leidos > 1 Then
            'Iniciar el procesamiento
            'Correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_5(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_5(Temp_y) / Divisor_Trasn_Wavelet
                Puntero = Puntero + 1
            Next Index
            'Calculo de la TW sin retardo
            For Index = Correcion_Desplazamiento + 1 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1

                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_5(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_5(Temp_y) / Divisor_Trasn_Wavelet

                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno la primera Ronda de Datos
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Compruebo solicitud de cancelacion
            If Progreso.CancellationPending = True Then
                'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()
                Return False
            End If
            'Reporto el progreso 
            Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

            'Segunda lectura de Datos
            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            While Cantidad_Datos_Leidos > 1 And (Puntero - Correcion_Desplazamiento - 1) <= Max_Puntero
                'Calculo de la TW sin retardo
                For Index = 0 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1
                    Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                    Temp_y = Transformada_Wavelet_Parte_2_Escala_5(Temp_y)
                    Temp_y = Transformada_Wavelet_Parte_3_Escala_5(Temp_y) / Divisor_Trasn_Wavelet
                    Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                    Puntero = Puntero + 1
                Next Index
                'Almacenamietno ciclico de los Datos
                Try
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Compruebo solicitud de cancelacion
                If Progreso.CancellationPending = True Then
                    'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Return False
                End If
                'Reporto el progreso 
                Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                'Lectura Ciclica de Datos
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            End While
            'Agrego la correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(0)
                Temp_y = Transformada_Wavelet_Parte_2_Escala_5(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_5(Temp_y) / Divisor_Trasn_Wavelet
                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno los datos del retardo
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
            'Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Almacenamiento_Resultados)

            'If (Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")) = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados) Then
            '    'Agregar una nueva columna en la trasformada wavelet
            '    Class_Funciones_Base_Datos.Sobre_Escribir_Columna(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados, Nombre_Columna)

            '    'Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna, "float")
            '    ''Actualizar la columna en la tabla final de la trasnformada Wavelet
            '    'Dim sql_Actualizaar As String = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN Temp Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero"
            '    'Dim cmd_Actualizar As New SqlCommand(sql_Actualizaar, Coneccion)
            '    'Try
            '    '    cmd_Actualizar.ExecuteNonQuery()
            '    'Catch ex As Exception
            '    '    MsgBox(ex.Message)
            '    'End Try
            'Else
            '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados)
            '    Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados)

            'End If
            'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")

        End If
        Datos_Lectura_Registro.Clear()
        Datos_Lectura_Registro.Dispose()
        Datos_Lectura_Registro.AcceptChanges()
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()

        Return True
    End Function
    Public Function Transformada_Wavelet_Escala_6(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Max_Puntero As Int64, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        Dim Cantidad_Datos_Max As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos ledias de para ser prosesada

        Const Divisor_Trasn_Wavelet = 500 'Corrector de Amplitud de la señal
        Const Correcion_Desplazamiento = 29 'Corrector de retardo
        Dim Temp_y As Double
        Dim Cantidad_Datos_Leidos As Int32
        Dim Puntero As Int32 = 0
        Dim Datos_Lectura_Registro As DataSet
        'Tabla temporal para lamacenar los datos andes de envialos a la base de datos
        Dim Tabla_Datos As New DataTable()
        'Incerta las nuevas columnas de las derivaciones a calcula en tabla de datos
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn(Nombre_Columna, GetType(System.Double)))
        If Progreso.CancellationPending = True Then
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()
            Return False
        End If
        Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero / Max_Puntero * 100)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        'Primera lectura de Datos
        Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
        Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count
        If Cantidad_Datos_Leidos > 1 Then
            'Iniciar el procesamiento
            'Correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_6(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_6(Temp_y) / Divisor_Trasn_Wavelet
                Puntero = Puntero + 1
            Next Index
            'Calculo de la TW sin retardo
            For Index = Correcion_Desplazamiento + 1 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1

                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_6(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_6(Temp_y) / Divisor_Trasn_Wavelet

                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno la primera Ronda de Datos
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Compruebo solicitud de cancelacion
            If Progreso.CancellationPending = True Then
                'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()
                Return False
            End If
            'Reporto el progreso 
            Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

            'Segunda lectura de Datos
            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            While Cantidad_Datos_Leidos > 1 And (Puntero - Correcion_Desplazamiento - 1) <= Max_Puntero
                'Calculo de la TW sin retardo
                For Index = 0 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1
                    Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                    Temp_y = Transformada_Wavelet_Parte_2_Escala_6(Temp_y)
                    Temp_y = Transformada_Wavelet_Parte_3_Escala_6(Temp_y) / Divisor_Trasn_Wavelet
                    Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                    Puntero = Puntero + 1
                Next Index
                'Almacenamietno ciclico de los Datos
                Try
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Compruebo solicitud de cancelacion
                If Progreso.CancellationPending = True Then
                    'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Return False
                End If
                'Reporto el progreso 
                Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                'Lectura Ciclica de Datos
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            End While
            'Agrego la correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(0)
                Temp_y = Transformada_Wavelet_Parte_2_Escala_6(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_6(Temp_y) / Divisor_Trasn_Wavelet
                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno los datos del retardo
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
            'Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Almacenamiento_Resultados)

            'If (Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")) = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados) Then
            '    'Agregar una nueva columna en la trasformada wavelet
            '    Class_Funciones_Base_Datos.Sobre_Escribir_Columna(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados, Nombre_Columna)

            '    'Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna, "float")
            '    ''Actualizar la columna en la tabla final de la trasnformada Wavelet
            '    'Dim sql_Actualizaar As String = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN Temp Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero"
            '    'Dim cmd_Actualizar As New SqlCommand(sql_Actualizaar, Coneccion)
            '    'Try
            '    '    cmd_Actualizar.ExecuteNonQuery()
            '    'Catch ex As Exception
            '    '    MsgBox(ex.Message)
            '    'End Try
            'Else
            '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados)
            '    Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados)

            'End If
            'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")

        End If
        Datos_Lectura_Registro.Clear()
        Datos_Lectura_Registro.Dispose()
        Datos_Lectura_Registro.AcceptChanges()
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()

        Return True
    End Function
    Public Function Transformada_Wavelet_Escala_7(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Max_Puntero As Int64, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        Dim Cantidad_Datos_Max As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos ledias de para ser prosesada


        Const Divisor_Trasn_Wavelet = 800 'Corrector de Amplitud de la señal
        Const Correcion_Desplazamiento = 34 'Corrector de retardo


        Dim Temp_y As Double
        Dim Cantidad_Datos_Leidos As Int32
        Dim Puntero As Int32 = 0
        Dim Datos_Lectura_Registro As DataSet
        'Tabla temporal para lamacenar los datos andes de envialos a la base de datos
        Dim Tabla_Datos As New DataTable()
        'Incerta las nuevas columnas de las derivaciones a calcula en tabla de datos
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn(Nombre_Columna, GetType(System.Double)))
        If Progreso.CancellationPending = True Then
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()
            Return False
        End If
        Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero / Max_Puntero * 100)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        'Primera lectura de Datos
        Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
        Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count
        If Cantidad_Datos_Leidos > 1 Then
            'Iniciar el procesamiento
            'Correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_7(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_7(Temp_y) / Divisor_Trasn_Wavelet
                Puntero = Puntero + 1
            Next Index
            'Calculo de la TW sin retardo
            For Index = Correcion_Desplazamiento + 1 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1

                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_7(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_7(Temp_y) / Divisor_Trasn_Wavelet

                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno la primera Ronda de Datos
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Compruebo solicitud de cancelacion
            If Progreso.CancellationPending = True Then
                'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()
                Return False
            End If
            'Reporto el progreso 
            Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

            'Segunda lectura de Datos
            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            While Cantidad_Datos_Leidos > 1 And (Puntero - Correcion_Desplazamiento - 1) <= Max_Puntero
                'Calculo de la TW sin retardo
                For Index = 0 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1
                    Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                    Temp_y = Transformada_Wavelet_Parte_2_Escala_7(Temp_y)
                    Temp_y = Transformada_Wavelet_Parte_3_Escala_7(Temp_y) / Divisor_Trasn_Wavelet
                    Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                    Puntero = Puntero + 1
                Next Index
                'Almacenamietno ciclico de los Datos
                Try
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Compruebo solicitud de cancelacion
                If Progreso.CancellationPending = True Then
                    'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Return False
                End If
                'Reporto el progreso 
                Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                'Lectura Ciclica de Datos
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            End While
            'Agrego la correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(0)
                Temp_y = Transformada_Wavelet_Parte_2_Escala_7(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_7(Temp_y) / Divisor_Trasn_Wavelet
                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno los datos del retardo
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
            'Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Almacenamiento_Resultados)

            'If (Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")) = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados) Then
            '    'Agregar una nueva columna en la trasformada wavelet
            '    Class_Funciones_Base_Datos.Sobre_Escribir_Columna(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados, Nombre_Columna)

            '    'Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna, "float")
            '    ''Actualizar la columna en la tabla final de la trasnformada Wavelet
            '    'Dim sql_Actualizaar As String = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN Temp Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero"
            '    'Dim cmd_Actualizar As New SqlCommand(sql_Actualizaar, Coneccion)
            '    'Try
            '    '    cmd_Actualizar.ExecuteNonQuery()
            '    'Catch ex As Exception
            '    '    MsgBox(ex.Message)
            '    'End Try
            'Else
            '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados)
            '    Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados)

            'End If
            'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")

        End If
        Datos_Lectura_Registro.Clear()
        Datos_Lectura_Registro.Dispose()
        Datos_Lectura_Registro.AcceptChanges()
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()


        Return True
    End Function
    Public Function Transformada_Wavelet_Escala_8(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Max_Puntero As Int64, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        Dim Cantidad_Datos_Max As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos ledias de para ser prosesada

        Const Divisor_Trasn_Wavelet = 3600 'Corrector de Amplitud de la señal
        Const Correcion_Desplazamiento = 38 'Corrector de retardo

        Dim Temp_y As Double
        Dim Cantidad_Datos_Leidos As Int32
        Dim Puntero As Int32 = 0
        Dim Datos_Lectura_Registro As DataSet
        'Tabla temporal para lamacenar los datos andes de envialos a la base de datos
        Dim Tabla_Datos As New DataTable()
        'Incerta las nuevas columnas de las derivaciones a calcula en tabla de datos
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn(Nombre_Columna, GetType(System.Double)))
        If Progreso.CancellationPending = True Then
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()
            Return False
        End If
        Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero / Max_Puntero * 100)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        'Primera lectura de Datos
        Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
        Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count
        If Cantidad_Datos_Leidos > 1 Then
            'Iniciar el procesamiento
            'Correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_8(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_8(Temp_y) / Divisor_Trasn_Wavelet
                Puntero = Puntero + 1
            Next Index
            'Calculo de la TW sin retardo
            For Index = Correcion_Desplazamiento + 1 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1

                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_8(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_8(Temp_y) / Divisor_Trasn_Wavelet

                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno la primera Ronda de Datos
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Compruebo solicitud de cancelacion
            If Progreso.CancellationPending = True Then
                'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()
                Return False
            End If
            'Reporto el progreso 
            Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

            'Segunda lectura de Datos
            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            While Cantidad_Datos_Leidos > 1 And (Puntero - Correcion_Desplazamiento - 1) <= Max_Puntero
                'Calculo de la TW sin retardo
                For Index = 0 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1
                    Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                    Temp_y = Transformada_Wavelet_Parte_2_Escala_8(Temp_y)
                    Temp_y = Transformada_Wavelet_Parte_3_Escala_8(Temp_y) / Divisor_Trasn_Wavelet
                    Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                    Puntero = Puntero + 1
                Next Index
                'Almacenamietno ciclico de los Datos
                Try
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Compruebo solicitud de cancelacion
                If Progreso.CancellationPending = True Then
                    'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Return False
                End If
                'Reporto el progreso 
                Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                'Lectura Ciclica de Datos
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            End While
            'Agrego la correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(0)
                Temp_y = Transformada_Wavelet_Parte_2_Escala_8(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_8(Temp_y) / Divisor_Trasn_Wavelet
                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno los datos del retardo
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
            'Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Almacenamiento_Resultados)

            'If (Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")) = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados) Then
            '    'Agregar una nueva columna en la trasformada wavelet
            '    Class_Funciones_Base_Datos.Sobre_Escribir_Columna(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados, Nombre_Columna)

            '    'Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna, "float")
            '    ''Actualizar la columna en la tabla final de la trasnformada Wavelet
            '    'Dim sql_Actualizaar As String = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN Temp Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero"
            '    'Dim cmd_Actualizar As New SqlCommand(sql_Actualizaar, Coneccion)
            '    'Try
            '    '    cmd_Actualizar.ExecuteNonQuery()
            '    'Catch ex As Exception
            '    '    MsgBox(ex.Message)
            '    'End Try
            'Else
            '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados)
            '    Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados)

            'End If
            'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")

        End If
        Datos_Lectura_Registro.Clear()
        Datos_Lectura_Registro.Dispose()
        Datos_Lectura_Registro.AcceptChanges()
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()


        Return True
    End Function
    Public Function Transformada_Wavelet_Escala_9(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Max_Puntero As Int64, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        Dim Cantidad_Datos_Max As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos ledias de para ser prosesada

        Const Divisor_Trasn_Wavelet = 1600 'Corrector de Amplitud de la señal
        Const Correcion_Desplazamiento = 43 'Corrector de retardo

        Dim Temp_y As Double
        Dim Cantidad_Datos_Leidos As Int32
        Dim Puntero As Int32 = 0
        Dim Datos_Lectura_Registro As DataSet
        'Tabla temporal para lamacenar los datos andes de envialos a la base de datos
        Dim Tabla_Datos As New DataTable()
        'Incerta las nuevas columnas de las derivaciones a calcula en tabla de datos
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn(Nombre_Columna, GetType(System.Double)))
        If Progreso.CancellationPending = True Then
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()
            Return False
        End If
        Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero / Max_Puntero * 100)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        'Primera lectura de Datos
        Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
        Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count
        If Cantidad_Datos_Leidos > 1 Then
            'Iniciar el procesamiento
            'Correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_9(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_9(Temp_y) / Divisor_Trasn_Wavelet
                Puntero = Puntero + 1
            Next Index
            'Calculo de la TW sin retardo
            For Index = Correcion_Desplazamiento + 1 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1

                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_9(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_9(Temp_y) / Divisor_Trasn_Wavelet

                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno la primera Ronda de Datos
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Compruebo solicitud de cancelacion
            If Progreso.CancellationPending = True Then
                'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()
                Return False
            End If
            'Reporto el progreso 
            Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

            'Segunda lectura de Datos
            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            While Cantidad_Datos_Leidos > 1 And (Puntero - Correcion_Desplazamiento - 1) <= Max_Puntero
                'Calculo de la TW sin retardo
                For Index = 0 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1
                    Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                    Temp_y = Transformada_Wavelet_Parte_2_Escala_9(Temp_y)
                    Temp_y = Transformada_Wavelet_Parte_3_Escala_9(Temp_y) / Divisor_Trasn_Wavelet
                    Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                    Puntero = Puntero + 1
                Next Index
                'Almacenamietno ciclico de los Datos
                Try
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Compruebo solicitud de cancelacion
                If Progreso.CancellationPending = True Then
                    'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Return False
                End If
                'Reporto el progreso 
                Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                'Lectura Ciclica de Datos
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            End While
            'Agrego la correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(0)
                Temp_y = Transformada_Wavelet_Parte_2_Escala_9(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_9(Temp_y) / Divisor_Trasn_Wavelet
                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno los datos del retardo
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
            'Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Almacenamiento_Resultados)

            'If (Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")) = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados) Then
            '    'Agregar una nueva columna en la trasformada wavelet
            '    Class_Funciones_Base_Datos.Sobre_Escribir_Columna(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados, Nombre_Columna)

            '    'Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna, "float")
            '    ''Actualizar la columna en la tabla final de la trasnformada Wavelet
            '    'Dim sql_Actualizaar As String = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN Temp Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero"
            '    'Dim cmd_Actualizar As New SqlCommand(sql_Actualizaar, Coneccion)
            '    'Try
            '    '    cmd_Actualizar.ExecuteNonQuery()
            '    'Catch ex As Exception
            '    '    MsgBox(ex.Message)
            '    'End Try
            'Else
            '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados)
            '    Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados)

            'End If
            'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")

        End If
        Datos_Lectura_Registro.Clear()
        Datos_Lectura_Registro.Dispose()
        Datos_Lectura_Registro.AcceptChanges()
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()


        Return True
    End Function
    Public Function Transformada_Wavelet_Escala_10(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Max_Puntero As Int64, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        Dim Cantidad_Datos_Max As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos ledias de para ser prosesada

        Const Divisor_Trasn_Wavelet = 2400 'Corrector de Amplitud de la señal
        Const Correcion_Desplazamiento = 47 'Corrector de retardo

        Dim Temp_y As Double
        Dim Cantidad_Datos_Leidos As Int32
        Dim Puntero As Int32 = 0
        Dim Datos_Lectura_Registro As DataSet
        'Tabla temporal para lamacenar los datos andes de envialos a la base de datos
        Dim Tabla_Datos As New DataTable()
        'Incerta las nuevas columnas de las derivaciones a calcula en tabla de datos
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn(Nombre_Columna, GetType(System.Double)))
        If Progreso.CancellationPending = True Then
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()
            Return False
        End If
        Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero / Max_Puntero * 100)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        'Primera lectura de Datos
        Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
        Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count
        If Cantidad_Datos_Leidos > 1 Then
            'Iniciar el procesamiento
            'Correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_10(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_10(Temp_y) / Divisor_Trasn_Wavelet
                Puntero = Puntero + 1
            Next Index
            'Calculo de la TW sin retardo
            For Index = Correcion_Desplazamiento + 1 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1

                Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                Temp_y = Transformada_Wavelet_Parte_2_Escala_10(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_10(Temp_y) / Divisor_Trasn_Wavelet

                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno la primera Ronda de Datos
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Compruebo solicitud de cancelacion
            If Progreso.CancellationPending = True Then
                'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()
                Return False
            End If
            'Reporto el progreso 
            Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

            'Segunda lectura de Datos
            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            While Cantidad_Datos_Leidos > 1 And (Puntero - Correcion_Desplazamiento - 1) <= Max_Puntero
                'Calculo de la TW sin retardo
                For Index = 0 To Datos_Lectura_Registro.Tables(0).Rows.Count - 1
                    Temp_y = Transformada_Wavelet_Parte_1(Datos_Lectura_Registro.Tables(Tabla_Origen).Rows(Index)(1))
                    Temp_y = Transformada_Wavelet_Parte_2_Escala_10(Temp_y)
                    Temp_y = Transformada_Wavelet_Parte_3_Escala_10(Temp_y) / Divisor_Trasn_Wavelet
                    Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                    Puntero = Puntero + 1
                Next Index
                'Almacenamietno ciclico de los Datos
                Try
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Compruebo solicitud de cancelacion
                If Progreso.CancellationPending = True Then
                    'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Return False
                End If
                'Reporto el progreso 
                Progreso.ReportProgress(Procedimiento_Trasnformada_Wavelet * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - Correcion_Desplazamiento - 1) / Max_Puntero * 100)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                'Lectura Ciclica de Datos
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count

            End While
            'Agrego la correcion del retardo de desplazamiento del filtro  en la TW
            For Index = 0 To Correcion_Desplazamiento
                Temp_y = Transformada_Wavelet_Parte_1(0)
                Temp_y = Transformada_Wavelet_Parte_2_Escala_10(Temp_y)
                Temp_y = Transformada_Wavelet_Parte_3_Escala_10(Temp_y) / Divisor_Trasn_Wavelet
                Tabla_Datos.Rows.Add(Puntero - Correcion_Desplazamiento - 1, Temp_y)
                Puntero = Puntero + 1
            Next Index
            'Almaceno los datos del retardo
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
            'Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Almacenamiento_Resultados)

            'If (Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")) = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados) Then
            '    'Agregar una nueva columna en la trasformada wavelet
            '    Class_Funciones_Base_Datos.Sobre_Escribir_Columna(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados, Nombre_Columna)

            '    'Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna, "float")
            '    ''Actualizar la columna en la tabla final de la trasnformada Wavelet
            '    'Dim sql_Actualizaar As String = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN Temp Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero"
            '    'Dim cmd_Actualizar As New SqlCommand(sql_Actualizaar, Coneccion)
            '    'Try
            '    '    cmd_Actualizar.ExecuteNonQuery()
            '    'Catch ex As Exception
            '    '    MsgBox(ex.Message)
            '    'End Try
            'Else
            '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados)
            '    Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp", Tabla_Almacenamiento_Resultados)

            'End If
            'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Tabla_Almacenamiento_Resultados + "___Temp")

        End If
        Datos_Lectura_Registro.Clear()
        Datos_Lectura_Registro.Dispose()
        Datos_Lectura_Registro.AcceptChanges()
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()


        Return True
    End Function

    Public Function Transformada_Wavelet_Parte_1(Lectura_Registro As Double)

        Dim b() As Double = {1 / 120, 26 / 120, 66 / 120, 26 / 120, 1 / 120} 'Wavelet_1
        Static z() As Double = {0, 0, 0, 0}

        Dim Lectura_Temp As Double = 0
        Dim Lectura_Temp1 As Double = 0

        Lectura_Temp = Lectura_Registro

        Lectura_Temp1 = b(0) * Lectura_Temp + z(0)
        z(0) = b(1) * Lectura_Temp + z(1)
        z(1) = b(2) * Lectura_Temp + z(2)
        z(2) = b(3) * Lectura_Temp + z(3)
        z(3) = b(4) * Lectura_Temp

        Return Lectura_Temp1
    End Function

    Public Function Transformada_Wavelet_Parte_2_Escala_1(Lectura_ADC As Double)
        Const Raiz_Escala = (6) ^ (1 / 2)
        'Son 37 datos
        Static S1() As Double = {0, 0}
        'Son 28 datos
        Static S2() As Double = {0, 0}
        'Son 19 datos
        Static S3() As Double = {0, 0}
        'Son 10 datos
        Static S4() As Double = {0, 0}
        'Son 2 datos
        Static S5() As Double = {0, 0}

        S2(1) = S2(0) + S1(1) - S1(0)

        S3(1) = S3(0) + S2(1) - S2(0)

        S4(1) = S4(0) + S3(1) - S3(0)

        S5(1) = S5(0) + S4(1) - S4(0)

        S1(0) = S1(1)

        S2(0) = S2(1)

        S3(0) = S3(1)

        S4(0) = S4(1)

        S5(0) = S5(1)

        S1(1) = Lectura_ADC
        'Return S5(1) / Raiz_Escala
        Return S5(1)
    End Function
    Public Function Transformada_Wavelet_Parte_2_Escala_2(Lectura_ADC As Double)
        Const Raiz_Escala = (6) ^ (1 / 2)
        'Son 37 datos
        Static S1() As Double = {0, 0, 0, 0, 0, 0}
        'Son 28 datos
        Static S2() As Double = {0, 0, 0, 0, 0}
        'Son 19 datos
        Static S3() As Double = {0, 0, 0, 0}
        'Son 10 datos
        Static S4() As Double = {0, 0, 0}
        'Son 2 datos
        Static S5() As Double = {0, 0}

        S2(1) = S2(0) + S1(2) - S1(0)
        S2(2) = S2(1) + S1(3) - S1(1)
        S2(3) = S2(2) + S1(4) - S1(2)
        S2(4) = S2(3) + S1(5) - S1(3)

        S3(1) = S3(0) + S2(2) - S2(0)
        S3(2) = S3(1) + S2(3) - S2(1)
        S3(3) = S3(2) + S2(4) - S2(2)

        S4(1) = S4(0) + S3(2) - S3(0)
        S4(2) = S4(1) + S3(3) - S3(1)

        S5(1) = S5(0) + S4(2) - S4(0)

        S1(0) = S1(1)
        S1(1) = S1(2)
        S1(2) = S1(3)
        S1(3) = S1(4)
        S1(4) = S1(5)

        S2(0) = S2(1)
        S2(1) = S2(2)
        S2(2) = S2(3)
        S2(3) = S2(4)

        S3(0) = S3(1)
        S3(1) = S3(2)
        S3(2) = S3(3)

        S4(0) = S4(1)
        S4(1) = S4(2)

        S5(0) = S5(1)

        S1(5) = Lectura_ADC
        'Return S5(1) / Raiz_Escala
        Return S5(1)
    End Function
    Public Function Transformada_Wavelet_Parte_2_Escala_3(Lectura_ADC As Double)
        Const Raiz_Escala = (6) ^ (1 / 2)
        'Son 37 datos
        Static S1() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 28 datos
        Static S2() As Double = {0, 0, 0, 0, 0, 0, 0, 0}
        'Son 19 datos
        Static S3() As Double = {0, 0, 0, 0, 0, 0}
        'Son 10 datos
        Static S4() As Double = {0, 0, 0, 0}
        'Son 2 datos
        Static S5() As Double = {0, 0}

        S2(1) = S2(0) + S1(3) - S1(0)
        S2(2) = S2(1) + S1(4) - S1(1)
        S2(3) = S2(2) + S1(5) - S1(2)
        S2(4) = S2(3) + S1(6) - S1(3)
        S2(5) = S2(4) + S1(7) - S1(4)
        S2(6) = S2(5) + S1(8) - S1(5)
        S2(7) = S2(6) + S1(9) - S1(6)

        S3(1) = S3(0) + S2(3) - S2(0)
        S3(2) = S3(1) + S2(4) - S2(1)
        S3(3) = S3(2) + S2(5) - S2(2)
        S3(4) = S3(3) + S2(6) - S2(3)
        S3(5) = S3(4) + S2(7) - S2(4)

        S4(1) = S4(0) + S3(3) - S3(0)
        S4(2) = S4(1) + S3(4) - S3(1)
        S4(3) = S4(2) + S3(5) - S3(2)

        S5(1) = S5(0) + S4(3) - S4(0)

        S1(0) = S1(1)
        S1(1) = S1(2)
        S1(2) = S1(3)
        S1(3) = S1(4)
        S1(4) = S1(5)
        S1(5) = S1(6)
        S1(6) = S1(7)
        S1(7) = S1(8)
        S1(8) = S1(9)

        S2(0) = S2(1)
        S2(1) = S2(2)
        S2(2) = S2(3)
        S2(3) = S2(4)
        S2(4) = S2(5)
        S2(5) = S2(6)
        S2(6) = S2(7)

        S3(0) = S3(1)
        S3(1) = S3(2)
        S3(2) = S3(3)
        S3(3) = S3(4)
        S3(4) = S3(5)

        S4(0) = S4(1)
        S4(1) = S4(2)
        S4(2) = S4(3)


        S5(0) = S5(1)

        S1(9) = Lectura_ADC
        ' Return S5(1) / Raiz_Escala
        Return S5(1)
    End Function
    Public Function Transformada_Wavelet_Parte_2_Escala_4(Lectura_ADC As Double)
        Const Raiz_Escala = (6) ^ (1 / 2)
        'Son 37 datos
        Static S1() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 28 datos
        Static S2() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 19 datos
        Static S3() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 10 datos
        Static S4() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 2 datos
        Static S5() As Double = {0, 0}

        S2(1) = S2(0) + S1(4) - S1(0)
        S2(2) = S2(1) + S1(5) - S1(1)
        S2(3) = S2(2) + S1(6) - S1(2)
        S2(4) = S2(3) + S1(7) - S1(3)
        S2(5) = S2(4) + S1(8) - S1(4)
        S2(6) = S2(5) + S1(9) - S1(5)
        S2(7) = S2(6) + S1(10) - S1(6)
        S2(8) = S2(7) + S1(11) - S1(7)
        S2(9) = S2(8) + S1(12) - S1(8)
        S2(10) = S2(9) + S1(13) - S1(9)

        S3(1) = S3(0) + S2(4) - S2(0)
        S3(2) = S3(1) + S2(5) - S2(1)
        S3(3) = S3(2) + S2(6) - S2(2)
        S3(4) = S3(3) + S2(7) - S2(3)
        S3(5) = S3(4) + S2(8) - S2(4)
        S3(6) = S3(5) + S2(9) - S2(5)
        S3(7) = S3(6) + S2(10) - S2(6)

        S4(1) = S4(0) + S3(4) - S3(0)
        S4(2) = S4(1) + S3(5) - S3(1)
        S4(3) = S4(2) + S3(6) - S3(2)
        S4(4) = S4(3) + S3(7) - S3(3)

        S5(1) = S5(0) + S4(4) - S4(0)

        S1(0) = S1(1)
        S1(1) = S1(2)
        S1(2) = S1(3)
        S1(3) = S1(4)
        S1(4) = S1(5)
        S1(5) = S1(6)
        S1(6) = S1(7)
        S1(7) = S1(8)
        S1(8) = S1(9)
        S1(9) = S1(10)
        S1(10) = S1(11)
        S1(11) = S1(12)
        S1(12) = S1(13)

        S2(0) = S2(1)
        S2(1) = S2(2)
        S2(2) = S2(3)
        S2(3) = S2(4)
        S2(4) = S2(5)
        S2(5) = S2(6)
        S2(6) = S2(7)
        S2(7) = S2(8)
        S2(8) = S2(9)
        S2(9) = S2(10)

        S3(0) = S3(1)
        S3(1) = S3(2)
        S3(2) = S3(3)
        S3(3) = S3(4)
        S3(4) = S3(5)
        S3(5) = S3(6)
        S3(6) = S3(7)

        S4(0) = S4(1)
        S4(1) = S4(2)
        S4(2) = S4(3)
        S4(3) = S4(4)

        S5(0) = S5(1)

        S1(13) = Lectura_ADC
        'Return S5(1) / Raiz_Escala
        Return S5(1)
    End Function
    Public Function Transformada_Wavelet_Parte_2_Escala_5(Lectura_ADC As Double)
        Const Raiz_Escala = (6) ^ (1 / 2)
        'Son 37 datos
        Static S1() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 28 datos
        Static S2() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 19 datos
        Static S3() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 10 datos
        Static S4() As Double = {0, 0, 0, 0, 0, 0}
        'Son 2 datos
        Static S5() As Double = {0, 0}

        S2(1) = S2(0) + S1(5) - S1(0)
        S2(2) = S2(1) + S1(6) - S1(1)
        S2(3) = S2(2) + S1(7) - S1(2)
        S2(4) = S2(3) + S1(8) - S1(3)
        S2(5) = S2(4) + S1(9) - S1(4)
        S2(6) = S2(5) + S1(10) - S1(5)
        S2(7) = S2(6) + S1(11) - S1(6)
        S2(8) = S2(7) + S1(12) - S1(7)
        S2(9) = S2(8) + S1(13) - S1(8)
        S2(10) = S2(9) + S1(14) - S1(9)
        S2(11) = S2(10) + S1(15) - S1(10)
        S2(12) = S2(11) + S1(16) - S1(11)
        S2(13) = S2(12) + S1(17) - S1(12)

        S3(1) = S3(0) + S2(5) - S2(0)
        S3(2) = S3(1) + S2(6) - S2(1)
        S3(3) = S3(2) + S2(7) - S2(2)
        S3(4) = S3(3) + S2(8) - S2(3)
        S3(5) = S3(4) + S2(9) - S2(4)
        S3(6) = S3(5) + S2(10) - S2(5)
        S3(7) = S3(6) + S2(11) - S2(6)
        S3(8) = S3(7) + S2(12) - S2(7)
        S3(9) = S3(8) + S2(13) - S2(8)

        S4(1) = S4(0) + S3(5) - S3(0)
        S4(2) = S4(1) + S3(6) - S3(1)
        S4(3) = S4(2) + S3(7) - S3(2)
        S4(4) = S4(3) + S3(8) - S3(3)
        S4(5) = S4(4) + S3(9) - S3(4)

        S5(1) = S5(0) + S4(5) - S4(0)

        S1(0) = S1(1)
        S1(1) = S1(2)
        S1(2) = S1(3)
        S1(3) = S1(4)
        S1(4) = S1(5)
        S1(5) = S1(6)
        S1(6) = S1(7)
        S1(7) = S1(8)
        S1(8) = S1(9)
        S1(9) = S1(10)
        S1(10) = S1(11)
        S1(11) = S1(12)
        S1(12) = S1(13)
        S1(13) = S1(14)
        S1(14) = S1(15)
        S1(15) = S1(16)
        S1(16) = S1(17)

        S2(0) = S2(1)
        S2(1) = S2(2)
        S2(2) = S2(3)
        S2(3) = S2(4)
        S2(4) = S2(5)
        S2(5) = S2(6)
        S2(6) = S2(7)
        S2(7) = S2(8)
        S2(8) = S2(9)
        S2(9) = S2(10)
        S2(10) = S2(11)
        S2(11) = S2(12)
        S2(12) = S2(13)

        S3(0) = S3(1)
        S3(1) = S3(2)
        S3(2) = S3(3)
        S3(3) = S3(4)
        S3(4) = S3(5)
        S3(5) = S3(6)
        S3(6) = S3(7)
        S3(7) = S3(8)
        S3(8) = S3(9)

        S4(0) = S4(1)
        S4(1) = S4(2)
        S4(2) = S4(3)
        S4(3) = S4(4)
        S4(4) = S4(5)


        S5(0) = S5(1)

        S1(17) = Lectura_ADC
        'Return S5(1) / Raiz_Escala
        Return S5(1)
    End Function
    Public Function Transformada_Wavelet_Parte_2_Escala_6(Lectura_ADC As Double)
        Const Raiz_Escala = (6) ^ (1 / 2)
        'Son 37 datos
        Static S1() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 28 datos
        Static S2() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 19 datos
        Static S3() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 10 datos
        Static S4() As Double = {0, 0, 0, 0, 0, 0, 0}
        'Son 2 datos
        Static S5() As Double = {0, 0}

        S2(1) = S2(0) + S1(6) - S1(0)
        S2(2) = S2(1) + S1(7) - S1(1)
        S2(3) = S2(2) + S1(8) - S1(2)
        S2(4) = S2(3) + S1(9) - S1(3)
        S2(5) = S2(4) + S1(10) - S1(4)
        S2(6) = S2(5) + S1(11) - S1(5)
        S2(7) = S2(6) + S1(12) - S1(6)
        S2(8) = S2(7) + S1(13) - S1(7)
        S2(9) = S2(8) + S1(14) - S1(8)
        S2(10) = S2(9) + S1(15) - S1(9)
        S2(11) = S2(10) + S1(16) - S1(10)
        S2(12) = S2(11) + S1(17) - S1(11)
        S2(13) = S2(12) + S1(18) - S1(12)
        S2(14) = S2(13) + S1(19) - S1(13)
        S2(15) = S2(14) + S1(20) - S1(14)
        S2(16) = S2(15) + S1(21) - S1(15)

        S3(1) = S3(0) + S2(6) - S2(0)
        S3(2) = S3(1) + S2(7) - S2(1)
        S3(3) = S3(2) + S2(8) - S2(2)
        S3(4) = S3(3) + S2(9) - S2(3)
        S3(5) = S3(4) + S2(10) - S2(4)
        S3(6) = S3(5) + S2(11) - S2(5)
        S3(7) = S3(6) + S2(12) - S2(6)
        S3(8) = S3(7) + S2(13) - S2(7)
        S3(9) = S3(8) + S2(14) - S2(8)
        S3(10) = S3(9) + S2(15) - S2(9)
        S3(11) = S3(10) + S2(16) - S2(10)

        S4(1) = S4(0) + S3(6) - S3(0)
        S4(2) = S4(1) + S3(7) - S3(1)
        S4(3) = S4(2) + S3(8) - S3(2)
        S4(4) = S4(3) + S3(9) - S3(3)
        S4(5) = S4(4) + S3(10) - S3(4)
        S4(6) = S4(5) + S3(11) - S3(5)

        S5(1) = S5(0) + S4(6) - S4(0)


        S1(0) = S1(1)
        S1(1) = S1(2)
        S1(2) = S1(3)
        S1(3) = S1(4)
        S1(4) = S1(5)
        S1(5) = S1(6)
        S1(6) = S1(7)
        S1(7) = S1(8)
        S1(8) = S1(9)
        S1(9) = S1(10)
        S1(10) = S1(11)
        S1(11) = S1(12)
        S1(12) = S1(13)
        S1(13) = S1(14)
        S1(14) = S1(15)
        S1(15) = S1(16)
        S1(16) = S1(17)
        S1(17) = S1(18)
        S1(18) = S1(19)
        S1(19) = S1(20)
        S1(20) = S1(21)

        S2(0) = S2(1)
        S2(1) = S2(2)
        S2(2) = S2(3)
        S2(3) = S2(4)
        S2(4) = S2(5)
        S2(5) = S2(6)
        S2(6) = S2(7)
        S2(7) = S2(8)
        S2(8) = S2(9)
        S2(9) = S2(10)
        S2(10) = S2(11)
        S2(11) = S2(12)
        S2(12) = S2(13)
        S2(13) = S2(14)
        S2(14) = S2(15)
        S2(15) = S2(16)


        S3(0) = S3(1)
        S3(1) = S3(2)
        S3(2) = S3(3)
        S3(3) = S3(4)
        S3(4) = S3(5)
        S3(5) = S3(6)
        S3(6) = S3(7)
        S3(7) = S3(8)
        S3(8) = S3(9)
        S3(9) = S3(10)
        S3(10) = S3(11)

        S4(0) = S4(1)
        S4(1) = S4(2)
        S4(2) = S4(3)
        S4(3) = S4(4)
        S4(4) = S4(5)
        S4(5) = S4(6)

        S5(0) = S5(1)

        S1(21) = Lectura_ADC
        'Return S5(1) / Raiz_Escala
        Return S5(1)
    End Function
    Public Function Transformada_Wavelet_Parte_2_Escala_7(Lectura_ADC As Double)
        Const Raiz_Escala = (10) ^ (1 / 2)
        'Son 37 datos
        Static S1() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 28 datos
        Static S2() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 19 datos
        Static S3() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 10 datos
        Static S4() As Double = {0, 0, 0, 0, 0, 0, 0, 0}
        'Son 2 datos
        Static S5() As Double = {0, 0}

        S2(1) = S2(0) + S1(7) - S1(0)
        S2(2) = S2(1) + S1(8) - S1(1)
        S2(3) = S2(2) + S1(9) - S1(2)
        S2(4) = S2(3) + S1(10) - S1(3)
        S2(5) = S2(4) + S1(11) - S1(4)
        S2(6) = S2(5) + S1(12) - S1(5)
        S2(7) = S2(6) + S1(13) - S1(6)
        S2(8) = S2(7) + S1(14) - S1(7)
        S2(9) = S2(8) + S1(15) - S1(8)
        S2(10) = S2(9) + S1(16) - S1(9)
        S2(11) = S2(10) + S1(17) - S1(10)
        S2(12) = S2(11) + S1(18) - S1(11)
        S2(13) = S2(12) + S1(19) - S1(12)
        S2(14) = S2(13) + S1(20) - S1(13)
        S2(15) = S2(14) + S1(21) - S1(14)
        S2(16) = S2(15) + S1(22) - S1(15)
        S2(17) = S2(16) + S1(23) - S1(16)
        S2(18) = S2(17) + S1(24) - S1(17)
        S2(19) = S2(18) + S1(25) - S1(18)

        S3(1) = S3(0) + S2(7) - S2(0)
        S3(2) = S3(1) + S2(8) - S2(1)
        S3(3) = S3(2) + S2(9) - S2(2)
        S3(4) = S3(3) + S2(10) - S2(3)
        S3(5) = S3(4) + S2(11) - S2(4)
        S3(6) = S3(5) + S2(12) - S2(5)
        S3(7) = S3(6) + S2(13) - S2(6)
        S3(8) = S3(7) + S2(14) - S2(7)
        S3(9) = S3(8) + S2(15) - S2(8)
        S3(10) = S3(9) + S2(16) - S2(9)
        S3(11) = S3(10) + S2(17) - S2(10)
        S3(12) = S3(11) + S2(18) - S2(11)
        S3(13) = S3(12) + S2(19) - S2(12)

        S4(1) = S4(0) + S3(7) - S3(0)
        S4(2) = S4(1) + S3(8) - S3(1)
        S4(3) = S4(2) + S3(9) - S3(2)
        S4(4) = S4(3) + S3(10) - S3(3)
        S4(5) = S4(4) + S3(11) - S3(4)
        S4(6) = S4(5) + S3(12) - S3(5)
        S4(7) = S4(6) + S3(13) - S3(6)

        S5(1) = S5(0) + S4(7) - S4(0)

        S1(0) = S1(1)
        S1(1) = S1(2)
        S1(2) = S1(3)
        S1(3) = S1(4)
        S1(4) = S1(5)
        S1(5) = S1(6)
        S1(6) = S1(7)
        S1(7) = S1(8)
        S1(8) = S1(9)
        S1(9) = S1(10)
        S1(10) = S1(11)
        S1(11) = S1(12)
        S1(12) = S1(13)
        S1(13) = S1(14)
        S1(14) = S1(15)
        S1(15) = S1(16)
        S1(16) = S1(17)
        S1(17) = S1(18)
        S1(18) = S1(19)
        S1(19) = S1(20)
        S1(20) = S1(21)
        S1(21) = S1(22)
        S1(22) = S1(23)
        S1(23) = S1(24)
        S1(24) = S1(25)

        S2(0) = S2(1)
        S2(1) = S2(2)
        S2(2) = S2(3)
        S2(3) = S2(4)
        S2(4) = S2(5)
        S2(5) = S2(6)
        S2(6) = S2(7)
        S2(7) = S2(8)
        S2(8) = S2(9)
        S2(9) = S2(10)
        S2(10) = S2(11)
        S2(11) = S2(12)
        S2(12) = S2(13)
        S2(13) = S2(14)
        S2(14) = S2(15)
        S2(15) = S2(16)
        S2(16) = S2(17)
        S2(17) = S2(18)
        S2(18) = S2(19)

        S3(0) = S3(1)
        S3(1) = S3(2)
        S3(2) = S3(3)
        S3(3) = S3(4)
        S3(4) = S3(5)
        S3(5) = S3(6)
        S3(6) = S3(7)
        S3(7) = S3(8)
        S3(8) = S3(9)
        S3(9) = S3(10)
        S3(10) = S3(11)
        S3(11) = S3(12)
        S3(12) = S3(13)

        S4(0) = S4(1)
        S4(1) = S4(2)
        S4(2) = S4(3)
        S4(3) = S4(4)
        S4(4) = S4(5)
        S4(5) = S4(6)
        S4(6) = S4(7)

        S5(0) = S5(1)

        S1(25) = Lectura_ADC
        'Return S5(1) / Raiz_Escala
        Return S5(1)
    End Function
    Public Function Transformada_Wavelet_Parte_2_Escala_8(Lectura_ADC As Double)

        'Son 30 datos
        Static S1() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 23 datos
        Static S2() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 16 datos
        Static S3() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 9 datos
        Static S4() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 2 datos
        Static S5() As Double = {0, 0}

        S2(1) = S2(0) + S1(8) - S1(0)
        S2(2) = S2(1) + S1(9) - S1(1)
        S2(3) = S2(2) + S1(10) - S1(2)
        S2(4) = S2(3) + S1(11) - S1(3)
        S2(5) = S2(4) + S1(12) - S1(4)
        S2(6) = S2(5) + S1(13) - S1(5)
        S2(7) = S2(6) + S1(14) - S1(6)
        S2(8) = S2(7) + S1(15) - S1(7)
        S2(9) = S2(8) + S1(16) - S1(8)
        S2(10) = S2(9) + S1(17) - S1(9)
        S2(11) = S2(10) + S1(18) - S1(10)
        S2(12) = S2(11) + S1(19) - S1(11)
        S2(13) = S2(12) + S1(20) - S1(12)
        S2(14) = S2(13) + S1(21) - S1(13)
        S2(15) = S2(14) + S1(22) - S1(14)
        S2(16) = S2(15) + S1(23) - S1(15)
        S2(17) = S2(16) + S1(24) - S1(16)
        S2(18) = S2(17) + S1(25) - S1(17)
        S2(19) = S2(18) + S1(26) - S1(18)
        S2(20) = S2(19) + S1(27) - S1(19)
        S2(21) = S2(20) + S1(28) - S1(20)
        S2(22) = S2(21) + S1(29) - S1(21)

        S3(1) = S3(0) + S2(8) - S2(0)
        S3(2) = S3(1) + S2(9) - S2(1)
        S3(3) = S3(2) + S2(10) - S2(2)
        S3(4) = S3(3) + S2(11) - S2(3)
        S3(5) = S3(4) + S2(12) - S2(4)
        S3(6) = S3(5) + S2(13) - S2(5)
        S3(7) = S3(6) + S2(14) - S2(6)
        S3(8) = S3(7) + S2(15) - S2(7)
        S3(9) = S3(8) + S2(16) - S2(8)
        S3(10) = S3(9) + S2(17) - S2(9)
        S3(11) = S3(10) + S2(18) - S2(10)
        S3(12) = S3(11) + S2(19) - S2(11)
        S3(13) = S3(12) + S2(20) - S2(12)
        S3(14) = S3(13) + S2(21) - S2(13)
        S3(15) = S3(14) + S2(22) - S2(14)

        S4(1) = S4(0) + S3(8) - S3(0)
        S4(2) = S4(1) + S3(9) - S3(1)
        S4(3) = S4(2) + S3(10) - S3(2)
        S4(4) = S4(3) + S3(11) - S3(3)
        S4(5) = S4(4) + S3(12) - S3(4)
        S4(6) = S4(5) + S3(13) - S3(5)
        S4(7) = S4(6) + S3(14) - S3(6)
        S4(8) = S4(7) + S3(15) - S3(7)

        S5(1) = S5(0) + S4(8) - S4(0)


        S1(0) = S1(1)
        S1(1) = S1(2)
        S1(2) = S1(3)
        S1(3) = S1(4)
        S1(4) = S1(5)
        S1(5) = S1(6)
        S1(6) = S1(7)
        S1(7) = S1(8)
        S1(8) = S1(9)
        S1(9) = S1(10)
        S1(10) = S1(11)
        S1(11) = S1(12)
        S1(12) = S1(13)
        S1(13) = S1(14)
        S1(14) = S1(15)
        S1(15) = S1(16)
        S1(16) = S1(17)
        S1(17) = S1(18)
        S1(18) = S1(19)
        S1(19) = S1(20)
        S1(20) = S1(21)
        S1(21) = S1(22)
        S1(22) = S1(23)
        S1(23) = S1(24)
        S1(24) = S1(25)
        S1(25) = S1(26)
        S1(26) = S1(27)
        S1(27) = S1(28)
        S1(28) = S1(29)

        S2(0) = S2(1)
        S2(1) = S2(2)
        S2(2) = S2(3)
        S2(3) = S2(4)
        S2(4) = S2(5)
        S2(5) = S2(6)
        S2(6) = S2(7)
        S2(7) = S2(8)
        S2(8) = S2(9)
        S2(9) = S2(10)
        S2(10) = S2(11)
        S2(11) = S2(12)
        S2(12) = S2(13)
        S2(13) = S2(14)
        S2(14) = S2(15)
        S2(15) = S2(16)
        S2(16) = S2(17)
        S2(17) = S2(18)
        S2(18) = S2(19)
        S2(19) = S2(20)
        S2(20) = S2(21)
        S2(21) = S2(22)

        S3(0) = S3(1)
        S3(1) = S3(2)
        S3(2) = S3(3)
        S3(3) = S3(4)
        S3(4) = S3(5)
        S3(5) = S3(6)
        S3(6) = S3(7)
        S3(7) = S3(8)
        S3(8) = S3(9)
        S3(9) = S3(10)
        S3(10) = S3(11)
        S3(11) = S3(12)
        S3(12) = S3(13)
        S3(13) = S3(14)
        S3(14) = S3(15)

        S4(0) = S4(1)
        S4(1) = S4(2)
        S4(2) = S4(3)
        S4(3) = S4(4)
        S4(4) = S4(5)
        S4(5) = S4(6)
        S4(6) = S4(7)
        S4(7) = S4(8)

        S5(0) = S5(1)

        S1(29) = Lectura_ADC
        Return S5(1)
    End Function
    Public Function Transformada_Wavelet_Parte_2_Escala_9(Lectura_ADC As Double)
        Const Raiz_Escala = (10) ^ (1 / 2)
        'Son 37 datos
        Static S1() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 28 datos
        Static S2() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 19 datos
        Static S3() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 10 datos
        Static S4() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 2 datos
        Static S5() As Double = {0, 0}

        S2(1) = S2(0) + S1(9) - S1(0)
        S2(2) = S2(1) + S1(10) - S1(1)
        S2(3) = S2(2) + S1(11) - S1(2)
        S2(4) = S2(3) + S1(12) - S1(3)
        S2(5) = S2(4) + S1(13) - S1(4)
        S2(6) = S2(5) + S1(14) - S1(5)
        S2(7) = S2(6) + S1(15) - S1(6)
        S2(8) = S2(7) + S1(16) - S1(7)
        S2(9) = S2(8) + S1(17) - S1(8)
        S2(10) = S2(9) + S1(18) - S1(9)
        S2(11) = S2(10) + S1(19) - S1(10)
        S2(12) = S2(11) + S1(20) - S1(11)
        S2(13) = S2(12) + S1(21) - S1(12)
        S2(14) = S2(13) + S1(22) - S1(13)
        S2(15) = S2(14) + S1(23) - S1(14)
        S2(16) = S2(15) + S1(24) - S1(15)
        S2(17) = S2(16) + S1(25) - S1(16)
        S2(18) = S2(17) + S1(26) - S1(17)
        S2(19) = S2(18) + S1(27) - S1(18)
        S2(20) = S2(19) + S1(28) - S1(19)
        S2(21) = S2(20) + S1(29) - S1(20)
        S2(22) = S2(21) + S1(30) - S1(21)
        S2(23) = S2(22) + S1(31) - S1(22)
        S2(24) = S2(23) + S1(32) - S1(23)
        S2(25) = S2(24) + S1(33) - S1(24)

        S3(1) = S3(0) + S2(9) - S2(0)
        S3(2) = S3(1) + S2(10) - S2(1)
        S3(3) = S3(2) + S2(11) - S2(2)
        S3(4) = S3(3) + S2(12) - S2(3)
        S3(5) = S3(4) + S2(13) - S2(4)
        S3(6) = S3(5) + S2(14) - S2(5)
        S3(7) = S3(6) + S2(15) - S2(6)
        S3(8) = S3(7) + S2(16) - S2(7)
        S3(9) = S3(8) + S2(17) - S2(8)
        S3(10) = S3(9) + S2(18) - S2(9)
        S3(11) = S3(10) + S2(19) - S2(10)
        S3(12) = S3(11) + S2(20) - S2(11)
        S3(13) = S3(12) + S2(21) - S2(12)
        S3(14) = S3(13) + S2(22) - S2(13)
        S3(15) = S3(14) + S2(23) - S2(14)
        S3(16) = S3(15) + S2(24) - S2(15)
        S3(17) = S3(16) + S2(25) - S2(16)

        S4(1) = S4(0) + S3(9) - S3(0)
        S4(2) = S4(1) + S3(10) - S3(1)
        S4(3) = S4(2) + S3(11) - S3(2)
        S4(4) = S4(3) + S3(12) - S3(3)
        S4(5) = S4(4) + S3(13) - S3(4)
        S4(6) = S4(5) + S3(14) - S3(5)
        S4(7) = S4(6) + S3(15) - S3(6)
        S4(8) = S4(7) + S3(16) - S3(7)
        S4(9) = S4(8) + S3(17) - S3(8)

        S5(1) = S5(0) + S4(9) - S4(0)


        S1(0) = S1(1)
        S1(1) = S1(2)
        S1(2) = S1(3)
        S1(3) = S1(4)
        S1(4) = S1(5)
        S1(5) = S1(6)
        S1(6) = S1(7)
        S1(7) = S1(8)
        S1(8) = S1(9)
        S1(9) = S1(10)
        S1(10) = S1(11)
        S1(11) = S1(12)
        S1(12) = S1(13)
        S1(13) = S1(14)
        S1(14) = S1(15)
        S1(15) = S1(16)
        S1(16) = S1(17)
        S1(17) = S1(18)
        S1(18) = S1(19)
        S1(19) = S1(20)
        S1(20) = S1(21)
        S1(21) = S1(22)
        S1(22) = S1(23)
        S1(23) = S1(24)
        S1(24) = S1(25)
        S1(25) = S1(26)
        S1(26) = S1(27)
        S1(27) = S1(28)
        S1(28) = S1(29)
        S1(29) = S1(30)
        S1(30) = S1(31)
        S1(31) = S1(32)
        S1(32) = S1(33)

        S2(0) = S2(1)
        S2(1) = S2(2)
        S2(2) = S2(3)
        S2(3) = S2(4)
        S2(4) = S2(5)
        S2(5) = S2(6)
        S2(6) = S2(7)
        S2(7) = S2(8)
        S2(8) = S2(9)
        S2(9) = S2(10)
        S2(10) = S2(11)
        S2(11) = S2(12)
        S2(12) = S2(13)
        S2(13) = S2(14)
        S2(14) = S2(15)
        S2(15) = S2(16)
        S2(16) = S2(17)
        S2(17) = S2(18)
        S2(18) = S2(19)
        S2(19) = S2(20)
        S2(20) = S2(21)
        S2(21) = S2(22)
        S2(22) = S2(23)
        S2(23) = S2(24)
        S2(24) = S2(25)


        S3(0) = S3(1)
        S3(1) = S3(2)
        S3(2) = S3(3)
        S3(3) = S3(4)
        S3(4) = S3(5)
        S3(5) = S3(6)
        S3(6) = S3(7)
        S3(7) = S3(8)
        S3(8) = S3(9)
        S3(9) = S3(10)
        S3(10) = S3(11)
        S3(11) = S3(12)
        S3(12) = S3(13)
        S3(13) = S3(14)
        S3(14) = S3(15)
        S3(15) = S3(16)
        S3(16) = S3(17)



        S4(0) = S4(1)
        S4(1) = S4(2)
        S4(2) = S4(3)
        S4(3) = S4(4)
        S4(4) = S4(5)
        S4(5) = S4(6)
        S4(6) = S4(7)
        S4(7) = S4(8)
        S4(8) = S4(9)


        S5(0) = S5(1)

        S1(33) = Lectura_ADC
        '  Return S5(1) / Raiz_Escala
        Return S5(1)
    End Function
    Public Function Transformada_Wavelet_Parte_2_Escala_10(Lectura_ADC As Double)
        Const Raiz_Escala = (10) ^ (1 / 2)
        'Son 37 datos
        Static S1() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 28 datos
        Static S2() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 19 datos
        Static S3() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 10 datos
        Static S4() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        'Son 2 datos
        Static S5() As Double = {0, 0}

        S2(1) = S2(0) + S1(10) - S1(0)
        S2(2) = S2(1) + S1(11) - S1(1)
        S2(3) = S2(2) + S1(12) - S1(2)
        S2(4) = S2(3) + S1(13) - S1(3)
        S2(5) = S2(4) + S1(14) - S1(4)
        S2(6) = S2(5) + S1(15) - S1(5)
        S2(7) = S2(6) + S1(16) - S1(6)
        S2(8) = S2(7) + S1(17) - S1(7)
        S2(9) = S2(8) + S1(18) - S1(8)
        S2(10) = S2(9) + S1(19) - S1(9)
        S2(11) = S2(10) + S1(20) - S1(10)
        S2(12) = S2(11) + S1(21) - S1(11)
        S2(13) = S2(12) + S1(22) - S1(12)
        S2(14) = S2(13) + S1(23) - S1(13)
        S2(15) = S2(14) + S1(24) - S1(14)
        S2(16) = S2(15) + S1(25) - S1(15)
        S2(17) = S2(16) + S1(26) - S1(16)
        S2(18) = S2(17) + S1(27) - S1(17)
        S2(19) = S2(18) + S1(28) - S1(18)
        S2(20) = S2(19) + S1(29) - S1(19)
        S2(21) = S2(20) + S1(30) - S1(20)
        S2(22) = S2(21) + S1(31) - S1(21)
        S2(23) = S2(22) + S1(32) - S1(22)
        S2(24) = S2(23) + S1(33) - S1(23)
        S2(25) = S2(24) + S1(34) - S1(24)
        S2(26) = S2(25) + S1(35) - S1(25)
        S2(27) = S2(26) + S1(36) - S1(26)
        S2(28) = S2(27) + S1(37) - S1(27)

        S3(1) = S3(0) + S2(10) - S2(0)
        S3(2) = S3(1) + S2(11) - S2(1)
        S3(3) = S3(2) + S2(12) - S2(2)
        S3(4) = S3(3) + S2(13) - S2(3)
        S3(5) = S3(4) + S2(14) - S2(4)
        S3(6) = S3(5) + S2(15) - S2(5)
        S3(7) = S3(6) + S2(16) - S2(6)
        S3(8) = S3(7) + S2(17) - S2(7)
        S3(9) = S3(8) + S2(18) - S2(8)
        S3(10) = S3(9) + S2(19) - S2(9)
        S3(11) = S3(10) + S2(20) - S2(10)
        S3(12) = S3(11) + S2(21) - S2(11)
        S3(13) = S3(12) + S2(22) - S2(12)
        S3(14) = S3(13) + S2(23) - S2(13)
        S3(15) = S3(14) + S2(24) - S2(14)
        S3(16) = S3(15) + S2(25) - S2(15)
        S3(17) = S3(16) + S2(26) - S2(16)
        S3(18) = S3(17) + S2(27) - S2(17)
        S3(19) = S3(18) + S2(28) - S2(18)

        S4(1) = S4(0) + S3(10) - S3(0)
        S4(2) = S4(1) + S3(11) - S3(1)
        S4(3) = S4(2) + S3(12) - S3(2)
        S4(4) = S4(3) + S3(13) - S3(3)
        S4(5) = S4(4) + S3(14) - S3(4)
        S4(6) = S4(5) + S3(15) - S3(5)
        S4(7) = S4(6) + S3(16) - S3(6)
        S4(8) = S4(7) + S3(17) - S3(7)
        S4(9) = S4(8) + S3(18) - S3(8)
        S4(10) = S4(9) + S3(19) - S3(9)

        S5(1) = S5(0) + S4(10) - S4(0)


        S1(0) = S1(1)
        S1(1) = S1(2)
        S1(2) = S1(3)
        S1(3) = S1(4)
        S1(4) = S1(5)
        S1(5) = S1(6)
        S1(6) = S1(7)
        S1(7) = S1(8)
        S1(8) = S1(9)
        S1(9) = S1(10)
        S1(10) = S1(11)
        S1(11) = S1(12)
        S1(12) = S1(13)
        S1(13) = S1(14)
        S1(14) = S1(15)
        S1(15) = S1(16)
        S1(16) = S1(17)
        S1(17) = S1(18)
        S1(18) = S1(19)
        S1(19) = S1(20)
        S1(20) = S1(21)
        S1(21) = S1(22)
        S1(22) = S1(23)
        S1(23) = S1(24)
        S1(24) = S1(25)
        S1(25) = S1(26)
        S1(26) = S1(27)
        S1(27) = S1(28)
        S1(28) = S1(29)
        S1(29) = S1(30)
        S1(30) = S1(31)
        S1(31) = S1(32)
        S1(32) = S1(33)
        S1(33) = S1(34)
        S1(34) = S1(35)
        S1(35) = S1(36)
        S1(36) = S1(37)

        S2(0) = S2(1)
        S2(1) = S2(2)
        S2(2) = S2(3)
        S2(3) = S2(4)
        S2(4) = S2(5)
        S2(5) = S2(6)
        S2(6) = S2(7)
        S2(7) = S2(8)
        S2(8) = S2(9)
        S2(9) = S2(10)
        S2(10) = S2(11)
        S2(11) = S2(12)
        S2(12) = S2(13)
        S2(13) = S2(14)
        S2(14) = S2(15)
        S2(15) = S2(16)
        S2(16) = S2(17)
        S2(17) = S2(18)
        S2(18) = S2(19)
        S2(19) = S2(20)
        S2(20) = S2(21)
        S2(21) = S2(22)
        S2(22) = S2(23)
        S2(23) = S2(24)
        S2(24) = S2(25)
        S2(25) = S2(26)
        S2(26) = S2(27)
        S2(27) = S2(28)

        S3(0) = S3(1)
        S3(1) = S3(2)
        S3(2) = S3(3)
        S3(3) = S3(4)
        S3(4) = S3(5)
        S3(5) = S3(6)
        S3(6) = S3(7)
        S3(7) = S3(8)
        S3(8) = S3(9)
        S3(9) = S3(10)
        S3(10) = S3(11)
        S3(11) = S3(12)
        S3(12) = S3(13)
        S3(13) = S3(14)
        S3(14) = S3(15)
        S3(15) = S3(16)
        S3(16) = S3(17)
        S3(17) = S3(18)
        S3(18) = S3(19)


        S4(0) = S4(1)
        S4(1) = S4(2)
        S4(2) = S4(3)
        S4(3) = S4(4)
        S4(4) = S4(5)
        S4(5) = S4(6)
        S4(6) = S4(7)
        S4(7) = S4(8)
        S4(8) = S4(9)
        S4(9) = S4(10)

        S5(0) = S5(1)

        S1(37) = Lectura_ADC
        'Return S5(1) / Raiz_Escala
        Return S5(1)
    End Function

    Public Function Transformada_Wavelet_Parte_3_Escala_1(Lectura_ADC As Double)

        Static p3() As Double = {-1, -4, -5, 5, 4}
        'Son 58 datos
        Static Q() As Double = {0, 0, 0, 0, 0, 0}
        Dim Temp As Double

        Temp = Lectura_ADC * p3(0) + Q(0)
        Q(0) = Lectura_ADC * p3(1) + Q(1)
        Q(1) = Lectura_ADC * p3(2) + Q(2)
        Q(2) = Q(3)
        Q(3) = Lectura_ADC * p3(3) + Q(4)
        Q(4) = Lectura_ADC * p3(4) + Q(5)
        Q(5) = Lectura_ADC

        Return Temp
    End Function
    Public Function Transformada_Wavelet_Parte_3_Escala_2(Lectura_ADC As Double)

        Static p3() As Double = {-1, -4, -5, 5, 4}
        'Son 58 datos
        Static Q() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Temp As Double

        Temp = Lectura_ADC * p3(0) + Q(0)
        Q(0) = Q(1)
        Q(1) = Lectura_ADC * p3(1) + Q(2)
        Q(2) = Q(3)
        Q(3) = Lectura_ADC * p3(2) + Q(4)
        Q(4) = Q(5)
        Q(5) = Q(6)
        Q(6) = Q(7)
        Q(7) = Lectura_ADC * p3(3) + Q(8)
        Q(8) = Q(9)
        Q(9) = Lectura_ADC * p3(4) + Q(10)
        Q(10) = Q(11)
        Q(11) = Lectura_ADC

        Return Temp
    End Function
    Public Function Transformada_Wavelet_Parte_3_Escala_3(Lectura_ADC As Double)

        Static p3() As Double = {-1, -4, -5, 5, 4}
        'Son 58 datos
        Static Q() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Temp As Double

        Temp = Lectura_ADC * p3(0) + Q(0)
        Q(0) = Q(1)
        Q(1) = Q(2)
        Q(2) = Lectura_ADC * p3(1) + Q(3)
        Q(3) = Q(4)
        Q(4) = Q(5)
        Q(5) = Lectura_ADC * p3(2) + Q(6)
        Q(6) = Q(7)
        Q(7) = Q(8)
        Q(8) = Q(9)
        Q(9) = Q(10)
        Q(10) = Q(11)
        Q(11) = Lectura_ADC * p3(3) + Q(12)
        Q(12) = Q(13)
        Q(13) = Q(14)
        Q(14) = Lectura_ADC * p3(4) + Q(15)
        Q(15) = Q(16)
        Q(16) = Q(17)
        Q(17) = Lectura_ADC

        Return Temp
    End Function
    Public Function Transformada_Wavelet_Parte_3_Escala_4(Lectura_ADC As Double)

        Static p3() As Double = {-1, -4, -5, 5, 4}
        'Son 58 datos
        Static Q() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Temp As Double

        Temp = Lectura_ADC * p3(0) + Q(0)
        Q(0) = Q(1)
        Q(1) = Q(2)
        Q(2) = Q(3)
        Q(3) = Lectura_ADC * p3(1) + Q(4)
        Q(4) = Q(5)
        Q(5) = Q(6)
        Q(6) = Q(7)
        Q(7) = Lectura_ADC * p3(2) + Q(8)
        Q(8) = Q(9)
        Q(9) = Q(10)
        Q(10) = Q(11)
        Q(11) = Q(12)
        Q(12) = Q(13)
        Q(13) = Q(14)
        Q(14) = Q(15)
        Q(15) = Lectura_ADC * p3(3) + Q(16)
        Q(16) = Q(17)
        Q(17) = Q(18)
        Q(18) = Q(19)
        Q(19) = Lectura_ADC * p3(4) + Q(20)
        Q(20) = Q(21)
        Q(21) = Q(22)
        Q(22) = Q(23)
        Q(23) = Lectura_ADC

        Return Temp
    End Function
    Public Function Transformada_Wavelet_Parte_3_Escala_5(Lectura_ADC As Double)

        Static p3() As Double = {-1, -4, -5, 5, 4}
        'Son 58 datos
        Static Q() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Temp As Double

        Temp = Lectura_ADC * p3(0) + Q(0)
        Q(0) = Q(1)
        Q(1) = Q(2)
        Q(2) = Q(3)
        Q(3) = Q(4)
        Q(4) = Lectura_ADC * p3(1) + Q(5)
        Q(5) = Q(6)
        Q(6) = Q(7)
        Q(7) = Q(8)
        Q(8) = Q(9)
        Q(9) = Lectura_ADC * p3(2) + Q(10)
        Q(10) = Q(11)
        Q(11) = Q(12)
        Q(12) = Q(13)
        Q(13) = Q(14)
        Q(14) = Q(15)
        Q(15) = Q(16)
        Q(16) = Q(17)
        Q(17) = Q(18)
        Q(18) = Q(19)
        Q(19) = Lectura_ADC * p3(3) + Q(20)
        Q(20) = Q(21)
        Q(21) = Q(22)
        Q(22) = Q(23)
        Q(23) = Q(24)
        Q(24) = Lectura_ADC * p3(4) + Q(25)
        Q(25) = Q(26)
        Q(26) = Q(27)
        Q(27) = Q(28)
        Q(28) = Q(29)
        Q(29) = Lectura_ADC

        Return Temp
    End Function
    Public Function Transformada_Wavelet_Parte_3_Escala_6(Lectura_ADC As Double)

        Static p3() As Double = {-1, -4, -5, 5, 4}
        'Son 58 datos
        Static Q() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Temp As Double

        Temp = Lectura_ADC * p3(0) + Q(0)
        Q(0) = Q(1)
        Q(1) = Q(2)
        Q(2) = Q(3)
        Q(3) = Q(4)
        Q(4) = Q(5)
        Q(5) = Lectura_ADC * p3(1) + Q(6)
        Q(6) = Q(7)
        Q(7) = Q(8)
        Q(8) = Q(9)
        Q(9) = Q(10)
        Q(10) = Q(11)
        Q(11) = Lectura_ADC * p3(2) + Q(12)
        Q(12) = Q(13)
        Q(13) = Q(14)
        Q(14) = Q(15)
        Q(15) = Q(16)
        Q(16) = Q(17)
        Q(17) = Q(18)
        Q(18) = Q(19)
        Q(19) = Q(20)
        Q(20) = Q(21)
        Q(21) = Q(22)
        Q(22) = Q(23)
        Q(23) = Lectura_ADC * p3(3) + Q(24)
        Q(24) = Q(25)
        Q(25) = Q(26)
        Q(26) = Q(27)
        Q(27) = Q(28)
        Q(28) = Q(29)
        Q(29) = Lectura_ADC * p3(4) + Q(30)
        Q(30) = Q(31)
        Q(31) = Q(32)
        Q(32) = Q(33)
        Q(33) = Q(34)
        Q(34) = Q(35)
        Q(35) = Lectura_ADC

        Return Temp
    End Function
    Public Function Transformada_Wavelet_Parte_3_Escala_7(Lectura_ADC As Double)

        Static p3() As Double = {-1, -4, -5, 5, 4}
        'Son 48 datos
        Static Q() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Temp As Double

        Temp = Lectura_ADC * p3(0) + Q(0)
        Q(0) = Q(1)
        Q(1) = Q(2)
        Q(2) = Q(3)
        Q(3) = Q(4)
        Q(4) = Q(5)
        Q(5) = Q(6)
        Q(6) = Lectura_ADC * p3(1) + Q(7)
        Q(7) = Q(8)
        Q(8) = Q(9)
        Q(9) = Q(10)
        Q(10) = Q(11)
        Q(11) = Q(12)
        Q(12) = Q(13)
        Q(13) = Lectura_ADC * p3(2) + Q(14)
        Q(14) = Q(15)
        Q(15) = Q(16)
        Q(16) = Q(17)
        Q(17) = Q(18)
        Q(18) = Q(19)
        Q(19) = Q(20)
        Q(20) = Q(21)
        Q(21) = Q(22)
        Q(22) = Q(23)
        Q(23) = Q(24)
        Q(24) = Q(25)
        Q(25) = Q(26)
        Q(26) = Q(27)
        Q(27) = Lectura_ADC * p3(3) + Q(28)
        Q(28) = Q(29)
        Q(29) = Q(30)
        Q(30) = Q(31)
        Q(31) = Q(32)
        Q(32) = Q(33)
        Q(33) = Q(34)
        Q(34) = Lectura_ADC * p3(4) + Q(35)
        Q(35) = Q(36)
        Q(36) = Q(37)
        Q(37) = Q(38)
        Q(38) = Q(39)
        Q(39) = Q(40)
        Q(40) = Q(41)
        Q(41) = Lectura_ADC

        Return Temp
    End Function
    Public Function Transformada_Wavelet_Parte_3_Escala_8(Lectura_ADC As Double)

        Static p3() As Double = {-1, -4, -5, 5, 4}
        'Son 48 datos
        Static Q() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Temp As Double

        Temp = Lectura_ADC * p3(0) + Q(0)
        Q(0) = Q(1)
        Q(1) = Q(2)
        Q(2) = Q(3)
        Q(3) = Q(4)
        Q(4) = Q(5)
        Q(5) = Q(6)
        Q(6) = Q(7)
        Q(7) = Lectura_ADC * p3(1) + Q(8)
        Q(8) = Q(9)
        Q(9) = Q(10)
        Q(10) = Q(11)
        Q(11) = Q(12)
        Q(12) = Q(13)
        Q(13) = Q(14)
        Q(14) = Q(15)
        Q(15) = Lectura_ADC * p3(2) + Q(16)
        Q(16) = Q(17)
        Q(17) = Q(18)
        Q(18) = Q(19)
        Q(19) = Q(20)
        Q(20) = Q(21)
        Q(21) = Q(22)
        Q(22) = Q(23)
        Q(23) = Q(24)
        Q(24) = Q(25)
        Q(25) = Q(26)
        Q(26) = Q(27)
        Q(27) = Q(28)
        Q(28) = Q(29)
        Q(29) = Q(30)
        Q(30) = Q(31)
        Q(31) = Lectura_ADC * p3(3) + Q(32)
        Q(32) = Q(33)
        Q(33) = Q(34)
        Q(34) = Q(35)
        Q(35) = Q(36)
        Q(36) = Q(37)
        Q(37) = Q(38)
        Q(38) = Q(39)
        Q(39) = Lectura_ADC * p3(4) + Q(40)
        Q(40) = Q(41)
        Q(41) = Q(42)
        Q(42) = Q(43)
        Q(43) = Q(44)
        Q(44) = Q(45)
        Q(45) = Q(46)
        Q(46) = Q(47)
        Q(47) = Lectura_ADC

        Return Temp
    End Function
    Public Function Transformada_Wavelet_Parte_3_Escala_9(Lectura_ADC As Double)

        Static p3() As Double = {-1, -4, -5, 5, 4}
        'Son 58 datos
        Static Q() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Temp As Double

        Temp = Lectura_ADC * p3(0) + Q(0)
        Q(0) = Q(1)
        Q(1) = Q(2)
        Q(2) = Q(3)
        Q(3) = Q(4)
        Q(4) = Q(5)
        Q(5) = Q(6)
        Q(6) = Q(7)
        Q(7) = Q(8)
        Q(8) = Lectura_ADC * p3(1) + Q(9)
        Q(9) = Q(10)
        Q(10) = Q(11)
        Q(11) = Q(12)
        Q(12) = Q(13)
        Q(13) = Q(14)
        Q(14) = Q(15)
        Q(15) = Q(16)
        Q(16) = Q(17)
        Q(17) = Lectura_ADC * p3(2) + Q(18)
        Q(18) = Q(19)
        Q(19) = Q(20)
        Q(20) = Q(21)
        Q(21) = Q(22)
        Q(22) = Q(23)
        Q(23) = Q(24)
        Q(24) = Q(25)
        Q(25) = Q(26)
        Q(26) = Q(27)
        Q(27) = Q(28)
        Q(28) = Q(29)
        Q(29) = Q(30)
        Q(30) = Q(31)
        Q(31) = Q(32)
        Q(32) = Q(33)
        Q(33) = Q(34)
        Q(34) = Q(35)
        Q(35) = Lectura_ADC * p3(3) + Q(36)
        Q(36) = Q(37)
        Q(37) = Q(38)
        Q(38) = Q(39)
        Q(39) = Q(40)
        Q(40) = Q(41)
        Q(41) = Q(42)
        Q(42) = Q(43)
        Q(43) = Q(44)
        Q(44) = Lectura_ADC * p3(4) + Q(45)
        Q(45) = Q(46)
        Q(46) = Q(47)
        Q(47) = Q(48)
        Q(48) = Q(49)
        Q(49) = Q(50)
        Q(50) = Q(51)
        Q(51) = Q(52)
        Q(52) = Q(53)
        Q(53) = Lectura_ADC

        Return Temp
    End Function
    Public Function Transformada_Wavelet_Parte_3_Escala_10(Lectura_ADC As Double)

        Static p3() As Double = {-1, -4, -5, 5, 4}
        'Son 58 datos
        Static Q() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Temp As Double

        Temp = Lectura_ADC * p3(0) + Q(0)
        Q(0) = Q(1)
        Q(1) = Q(2)
        Q(2) = Q(3)
        Q(3) = Q(4)
        Q(4) = Q(5)
        Q(5) = Q(6)
        Q(6) = Q(7)
        Q(7) = Q(8)
        Q(8) = Q(9)
        Q(9) = Lectura_ADC * p3(1) + Q(10)
        Q(10) = Q(11)
        Q(11) = Q(12)
        Q(12) = Q(13)
        Q(13) = Q(14)
        Q(14) = Q(15)
        Q(15) = Q(16)
        Q(16) = Q(17)
        Q(17) = Q(18)
        Q(18) = Q(19)
        Q(19) = Lectura_ADC * p3(2) + Q(20)
        Q(20) = Q(21)
        Q(21) = Q(22)
        Q(22) = Q(23)
        Q(23) = Q(24)
        Q(24) = Q(25)
        Q(25) = Q(26)
        Q(26) = Q(27)
        Q(27) = Q(28)
        Q(28) = Q(29)
        Q(29) = Q(30)
        Q(30) = Q(31)
        Q(31) = Q(32)
        Q(32) = Q(33)
        Q(33) = Q(34)
        Q(34) = Q(35)
        Q(35) = Q(36)
        Q(36) = Q(37)
        Q(37) = Q(38)
        Q(38) = Q(39)
        Q(39) = Lectura_ADC * p3(3) + Q(40)
        Q(40) = Q(41)
        Q(41) = Q(42)
        Q(42) = Q(43)
        Q(43) = Q(44)
        Q(44) = Q(45)
        Q(45) = Q(46)
        Q(46) = Q(47)
        Q(47) = Q(48)
        Q(48) = Q(49)
        Q(49) = Lectura_ADC * p3(4) + Q(50)
        Q(50) = Q(51)
        Q(51) = Q(52)
        Q(52) = Q(53)
        Q(53) = Q(54)
        Q(54) = Q(55)
        Q(55) = Q(56)
        Q(56) = Q(57)
        Q(57) = Q(58)
        Q(58) = Q(59)
        Q(59) = Lectura_ADC

        Return Temp
    End Function

    Public Function Deteccion_QRS_Con_Deteccion_Puntos(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Registro As String, Tabla_Transformada_Wavelet As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Frecuencia As Double, Max_Puntero As Int64, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        'En esta funcion se ulilisa Coneccion_Entrada para obtner las trasnfomras wavele y Coneccion_Salida para guardar los QRS detectados
        '                   _                                                               _   
        '                  / \                                                             /!\
        '                 /!  \             ! Onda T  !                                   / ! \
        '                / !   \            !      _  !                                  /  !  \           
        '               /  !    \           !     /!\ !              _        _         /   !   \          
        '_______       /   !     \       ___!    / ! \!__________   / \______/!\       /    !    \       __
        '       \     /    !      \     /   \   /! !  !         !\_/   !      ! \     /!    !    !\     /  
        '        \   /     !       \   /     \_/ ! !  !         !      !      ! !\   / !    !    ! \   /   
        '        !\_/      !       !\_/       !  ! !  !         !      !      ! ! \_/  !    !    !  \_/    
        '        !         !       !          !  ! !  !         !      !      ! !  !   !    !    !   !
        '        !         !       !          !  ! !  !         !Onda P!      ! !  !   !    !    !   !
        '       Rmin      Rmax    Smin        !  T !  T0                      Q !  Q1  R    R0   S   S0        
        '                                   Tmin  Tmax       	                Q0             Q   Q0  R    R0   S   S0        
        'Correccion=0 sin correcion
        'Correccion=1 correcion por pendiente
        'Correccion=2 correcion por minimo valor
        Dim m_Comparacion_Wavelet As Double = Configuracion_Deteccion_QRS.m_Comparacion_Wavelet_QRS 'tang 45°=1 Pendiente de comparacion Para deterla busqueda de punos significativos  
        Dim Margen_Separacion_QRS_Ruido As Double = Configuracion_Deteccion_QRS.Margen_Separacion_QRS_Ruido 'Establece el limite de cuanto pude crecer la amplitud de P_Max_Central con respecto a Valor_Promedio_P_Max sin considerarse ruido 
        Dim Margen_Separacion_Desniveles As Double = Configuracion_Deteccion_QRS.Margen_Separacion_Desniveles 'Establece  la relacion minima entre P_Max_Central y uno de los minimos para direnciar los cambios de nivel en la señal y un QRS
        Dim Margen_Actualizacion_R_Promedio As Double = Configuracion_Deteccion_QRS.Margen_Actualizacion_R_Promedio 'Limite maximo de un P_Max_Central para poder actualizar el Valor_Promedio_P_Max
        Dim Cantidad_Latido_Ectopico As Double = Configuracion_Deteccion_QRS.Cantidad_Latido_Ectopico 'Cantidad de posibles latidos Ectopicos antes de actulizar Vector_Valor_P_Max  

        Dim PorCiento_Comparacion As Double = Configuracion_Deteccion_QRS.PorCiento_Comparacion_QRS 'Determian el cuanto se reduce margen Valor_Promedio_P_Max minimo para asignarselo a Valor_P_Max
        Dim PorCiento_Comparacion_Busqueda As Double = Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_QRS  'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW entre P_Max_Izquierda y P_Max_Derecha 
        Dim PorCiento_Comparacion_Busqueda_Extremos As Double = Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_Extremos_QRS 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW fuera de lso puntos P_Max_Izquierda y P_Max_Derecha 

        Dim Duracion_Maxima_QRS As Double = Configuracion_Deteccion_QRS.Duracion_Maxima_QRS 'Duracion Maxima que puede tener un QRS
        Dim Duracion_Minima_QRS As Double = Configuracion_Deteccion_QRS.Duracion_Minima_QRS 'Duracion Minima que puede tener un QRS
        Dim Separacion_Minima_QRS As Double = Configuracion_Deteccion_QRS.Separacion_Minima_QRS  'En segundos =200ms Separacion minima de debe existir entre dos QRS consecutivos de 200 ms 
        Dim Demora_Despues_QRS As Double = Configuracion_Deteccion_QRS.Demora_Despues_QRS  'Demora_Despues_QRS*frecuencia desplasamiento despues de detectar un QRS   

        Dim Cantida_Datos As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos ledias de para ser prosesada  
        Dim Cantida_Datos_Retenidos As Double = Configuracion_Deteccion_QRS.Cantida_Datos_Retenidos 'el quivalente a 10 segundos Math.Floor(Cantida_Datos_Retenidos * Frecuencia) de datos alamcenadades para ser prosesada         Static Reset_Limite_Max_Min As Int32    'Limite de tiempo sin detectar un QRS para resetear  Limite_Max y Limite_Min
        Dim PorCiento_Rechazo_Extremos As Double = Configuracion_Deteccion_QRS.PorCiento_Rechazo_Extremos  '% de rechaso de los puntos estremos(P_Max_Derecha y P_Max_Izquierda ) con respecto P_Max_Central

        Dim Bandera_Primera_Lectura_Datos As Double
        Dim Bandera_Cambio_Lobulo_Central_a_Derecho As Double
        Dim Bandera_Desnivel_Detectado As Double
        Dim Bandera_Muesca_Detectada As Double = 0
        Dim Bandera_Latido_Ectopico As Double = 0
        'Clasificar el Complejo QRS
        Dim Multiplicador_Desplazamiento As Int64 = 1
        Dim m As Double 'Pendiente de la rectas
        Dim Index_Final As Double
        Dim Index_Clasificacion As Int64
        Dim Index_Clasificacion_Temp, Index_Clasificacion_Temp_1, Index_Clasificacion_Temp_2 As Int64
        Dim Index_Inicio_Intervalo_Busqueda_Temp As Int64 = 0
        Dim Index_Fin_Intervalo_Busqueda_Temp As Int64 = 0
        Dim Intervalo_Busqueda As Double = 0.03

        Dim P_Max_Central As Double = 0
        Dim P_Max_Izquierda As Double = 0
        Dim P_Max_Derecha As Double = 0
        Dim P_Min_Izquierda As Double = 0
        Dim P_Min_Izquierda_Temp As Double = 0
        Dim P_Min_Izquierda_1 As Double = 0
        Dim P_Min_Derecha As Double = 0
        Dim P_Min_Derecha_Temp As Double = 0
        Dim P_Min_Derecha_1 As Double = 0
        Dim P_Min_Comparacion As Double = 0

        Dim Puntero_P_Max_Central As Double = 0
        Dim Puntero_P_Max_Izquierda As Double = 0
        Dim Puntero_P_Max_Derecha As Double = 0
        Dim Puntero_P_Min_Izquierda As Double = 0
        Dim Puntero_P_Min_Izquierda_1 As Double = 0
        Dim Puntero_P_Min_Derecha As Double = 0
        Dim Puntero_P_Min_Derecha_1 As Double = 0

        Dim Index_Cambio_Nivel As Double = 0

        Dim Puntero_Q_i As Double = 0
        Dim Puntero_Q As Double = 0
        Dim Puntero_R As Double = 0
        Dim Puntero_S As Double = 0
        Dim Puntero_J As Double = 0
        Dim Puntero_S1 As Double = 0
        Dim Puntero_S2 As Double = 0
        Dim Puntero_S3 As Double = 0
        Dim Puntero_Ultimo_J As Double = -1 * Frecuencia * Separacion_Minima_QRS
        Dim Puntero_Ultimo_R As Double = -1 * Frecuencia * Separacion_Minima_QRS

        Dim Tipo_QRS As Tipos_QRS

        '---------------------------------------------------------------------------

        Dim Datos_Transformada_Wavelet As DataSet
        'Dim Datos_Registro As DataSet

        Dim Index As Int64 = 0
        Dim Index1 As Int64 = 0
        Dim Index_temp As Int64 = 0


        Dim Cantidad_Leidos As Int64
        Dim Puntero As Int64 = 0
        Dim Puntero_Cantidad_QRS As Int64 = 0
        Dim Puntero_Onda_R As Int64 = 0


        Dim Error_QRS As Int64 = 0
        'Error_QRS=0 no hay erroes 
        'Error_QRS=1 Index > Cantidad_Leidos Hay que leer nuevos datos
        'Error_QRS=2 Se superaron los tiempos posible de un QRS
        'Error_QRS=3 Index <0 no se puede retroceder mas en el vector de busqueda
        'Error_QRS=4 no se detecto P_Max_Central
        Dim Valor_P_Max As Double
        Dim Valor_Promedio_P_Max As Double
        Dim Vector_Valor_P_Max() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Vector_Valor_P_Max_Ectopico(Cantidad_Latido_Ectopico - 1) As Double

        Dim Demora_Entre_Ondas_R As Int64 = 0
        Dim Segmentos_RR As Int64() = {3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia}
        Dim Segmentos_RR_Promedio As Int64 = 0 'Almacena 1.5 del promedio de los ulimos 10 segmentos RR 
        Datos_Transformada_Wavelet = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Transformada_Wavelet, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantida_Datos))
        'Datos_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion, Tabla_Registro, Nombre_Columna + ", Puntero", Convert.ToString(Puntero), Convert.ToString(Puntero + Cantida_Datos))
        Cantidad_Leidos = Datos_Transformada_Wavelet.Tables(0).Rows.Count
        'Buscar el valor maximo a partir de 0.1*Cantidad_Leidos asta 120 seguntos despues del 0.1*Cantidad_Leidos o el 90% de registro
        If Cantidad_Leidos > 180 * Frecuencia Then
            Index = Frecuencia * 60
            Valor_P_Max = 0
            While Cantidad_Leidos >= Index + 2 And Index < 180 * Frecuencia
                If Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) > Valor_P_Max Then
                    Valor_P_Max = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                End If
                Index = Index + 1
            End While
        Else
            Index = Cantidad_Leidos * 0.1
            Valor_P_Max = 0
            While Cantidad_Leidos >= Index + 2 And Index < Cantidad_Leidos * 0.9
                If Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) > Valor_P_Max Then
                    Valor_P_Max = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                End If
                Index = Index + 1
            End While
        End If

        '--------------------------------------------------------------------------------------
        'Buscar posibles el valor maximo(Primera Aproximacion)
        Index_temp = 0
        Puntero_Ultimo_R = Cantidad_Leidos / 10
        If Cantidad_Leidos > 180 * Frecuencia Then
            Index = 60 * Frecuencia
        Else
            Index = Cantidad_Leidos / 10
        End If

        Valor_P_Max = Valor_P_Max * 0.7
        Segmentos_RR_Promedio = (Segmentos_RR(0) + Segmentos_RR(1) + Segmentos_RR(2) + Segmentos_RR(3) + Segmentos_RR(4) + Segmentos_RR(5) + Segmentos_RR(6) + Segmentos_RR(7) + Segmentos_RR(8) + Segmentos_RR(9)) / 10

        While Cantidad_Leidos >= Index + 2 And Index_temp < 10 And Multiplicador_Desplazamiento < 1000
            Index = Index + 1
            'Identificando posible complejo QRS
            If Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) > Valor_P_Max Then
                'Identificando valor maximo del posible complejo QRS
                Index_Fin_Intervalo_Busqueda_Temp = Index + 0.3 * Frecuencia
                If Index_Fin_Intervalo_Busqueda_Temp > Cantidad_Leidos - 2 Then
                    Index_Fin_Intervalo_Busqueda_Temp = Cantidad_Leidos - 2
                End If

                Index1 = Index
                P_Max_Central = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                While Index < Index_Fin_Intervalo_Busqueda_Temp
                    Index = Index + 1
                    If P_Max_Central < Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                        P_Max_Central = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                        Index1 = Index
                    End If
                End While

                ' Obtener P_Min_Derecha
                Index = Index1
                Index_Fin_Intervalo_Busqueda_Temp = Index + 0.1 * Frecuencia
                If Index_Fin_Intervalo_Busqueda_Temp > Cantidad_Leidos - 2 Then
                    Index_Fin_Intervalo_Busqueda_Temp = Cantidad_Leidos - 2
                End If

                P_Min_Derecha = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                While Index < Index_Fin_Intervalo_Busqueda_Temp
                    Index = Index + 1
                    If P_Min_Derecha > Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                        P_Min_Derecha = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                    End If
                End While

                ' Obtener P_Min_Derecha
                Index = Index1
                Index_Fin_Intervalo_Busqueda_Temp = Index - 0.2 * Frecuencia
                If Index_Fin_Intervalo_Busqueda_Temp < 1 Then
                    Index_Fin_Intervalo_Busqueda_Temp = 1
                End If

                P_Min_Izquierda = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                While Index > Index_Fin_Intervalo_Busqueda_Temp
                    Index = Index - 1
                    If P_Min_Izquierda > Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                        P_Min_Izquierda = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                    End If
                End While

                'Almacenamiento del valor maximo
                'Obtencion del P_Min mas pequeño
                If P_Min_Izquierda < P_Min_Derecha Then
                    P_Min_Comparacion = P_Min_Izquierda
                Else
                    P_Min_Comparacion = P_Min_Derecha
                End If

                'Comprobacion si no es un desnivel
                If (P_Max_Central * Margen_Separacion_Desniveles < Math.Abs(P_Min_Comparacion) And P_Max_Central > Margen_Separacion_Desniveles * Math.Abs(P_Min_Comparacion) And P_Min_Comparacion < 0) Then
                    'Almacenamiento del valor de los intervalos RR
                    Vector_Valor_P_Max(Index_temp) = Datos_Transformada_Wavelet.Tables(0).Rows(Index1)(1)
                    'Almacenamiento del valor de los intervalos RR
                    If Puntero_Ultimo_R = Cantidad_Leidos / 10 Then
                        Puntero_Ultimo_R = Index1
                    Else
                        Segmentos_RR(Index_temp) = Index1 - Puntero_Ultimo_R
                        Puntero_Ultimo_R = Index1
                        Multiplicador_Desplazamiento = 1
                        Index_temp = Index_temp + 1
                    End If
                    'Desplazar el Index  debusqueda para salir del analisis QRS actual
                    Index = Index1 + Frecuencia * Separacion_Minima_QRS
                Else
                    Index = Index1 + Frecuencia * Separacion_Minima_QRS
                End If

            End If
            If Index - Puntero_Ultimo_R > Segmentos_RR_Promedio Then
                Valor_P_Max = Valor_P_Max * 0.8
                Multiplicador_Desplazamiento = Multiplicador_Desplazamiento + 1

                If Puntero_Ultimo_R = Cantidad_Leidos / 10 Then
                    Puntero_Ultimo_R = Index
                Else
                    Index = Puntero_Ultimo_R + Frecuencia * 0.25
                End If
            End If

        End While
        'Precaucion por si el registro es pequeño y no se detectan 10 posibles QRS 
        Segmentos_RR_Promedio = 0
        Valor_Promedio_P_Max = 0
        For i = 0 To Index_temp - 1
            Segmentos_RR_Promedio = Segmentos_RR_Promedio + Segmentos_RR(i)
            Valor_Promedio_P_Max = Valor_Promedio_P_Max + Vector_Valor_P_Max(i)
        Next
        If Index_temp = 0 Then
            Segmentos_RR_Promedio = 3 * Frecuencia
            Valor_Promedio_P_Max = Class_Funciones_Base_Datos.Registro_Maximo_Valor(Coneccion_Entrada, Tabla_Transformada_Wavelet, Nombre_Columna, "0", "200000")
            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
        Else
            Segmentos_RR_Promedio = Segmentos_RR_Promedio * 1.5 / (Index_temp)
            Valor_Promedio_P_Max = Valor_Promedio_P_Max / (Index_temp)
            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
        End If
        'Precaucion por si el registro es pequeño y no se detectan 10 posibles QRS 
        For i = Index_temp To 9
            Segmentos_RR(i) = Segmentos_RR_Promedio
            Vector_Valor_P_Max(i) = Valor_Promedio_P_Max
        Next


        Dim Tabla_Datos As New DataTable()
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn("Q_i", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn("Q", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn("R", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn("S", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn("J", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn("Tipo_QRS", GetType(System.Int32)))

        Class_Funciones_Base_Datos.Registros_Crear_Tabla_QRS(Coneccion_Salida, Tabla_Almacenamiento_Resultados)

        If Progreso.CancellationPending = True Then
            Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
            Datos_Transformada_Wavelet.Clear()
            Datos_Transformada_Wavelet.Dispose()
            Datos_Transformada_Wavelet.AcceptChanges()
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()


            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()
            'Datos_Registro.Clear()
            'Datos_Registro.Dispose()
            'Datos_Registro.AcceptChanges
            Return False
        End If
        Progreso.ReportProgress(Procedimiento_Deteccion_QRS * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero / Max_Puntero * 100)


        Index = Frecuencia * 0.15
        Puntero = Frecuencia * 0.15
        Bandera_Primera_Lectura_Datos = 1
        Puntero_Ultimo_R = -1 * Frecuencia * Separacion_Minima_QRS
        While Cantidad_Leidos >= Math.Floor(Frecuencia * Cantida_Datos_Retenidos) + 2 Or Bandera_Primera_Lectura_Datos = 1

            While (Cantidad_Leidos - 3) >= Index + Math.Abs(Index_Clasificacion)
                '     While Error_QRS <> 1

                'Deteccion del posible QRS
                Demora_Entre_Ondas_R = 0
                While Error_QRS = 0 And Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) <= Valor_P_Max
                    Index = Index + 1
                    Puntero = Puntero + 1
                    Demora_Entre_Ondas_R = Demora_Entre_Ondas_R + 1
                    If Index > Cantidad_Leidos - 3 Then
                        Error_QRS = 1
                    End If
                    If (Demora_Entre_Ondas_R > Segmentos_RR_Promedio) Then
                        If (Valor_P_Max < (0.3 * Valor_Promedio_P_Max)) Then
                            If Puntero - Puntero_Onda_R > 10 * Frecuencia Then
                                Vector_Valor_P_Max(0) = Vector_Valor_P_Max(0) * 0.1
                                Vector_Valor_P_Max(1) = Vector_Valor_P_Max(1) * 0.1
                                Vector_Valor_P_Max(2) = Vector_Valor_P_Max(2) * 0.1
                                Vector_Valor_P_Max(3) = Vector_Valor_P_Max(3) * 0.1
                                Vector_Valor_P_Max(4) = Vector_Valor_P_Max(4) * 0.1
                                Vector_Valor_P_Max(5) = Vector_Valor_P_Max(5) * 0.1
                                Vector_Valor_P_Max(6) = Vector_Valor_P_Max(6) * 0.1
                                Vector_Valor_P_Max(7) = Vector_Valor_P_Max(7) * 0.1
                                Vector_Valor_P_Max(8) = Vector_Valor_P_Max(8) * 0.1
                                Vector_Valor_P_Max(9) = Vector_Valor_P_Max(9) * 0.1
                                Valor_Promedio_P_Max = Valor_Promedio_P_Max * 0.1
                                Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                            ElseIf Puntero - Puntero_Onda_R > 8 * Frecuencia Then
                                Vector_Valor_P_Max(0) = Vector_Valor_P_Max(0) * 0.2
                                Vector_Valor_P_Max(1) = Vector_Valor_P_Max(1) * 0.2
                                Vector_Valor_P_Max(2) = Vector_Valor_P_Max(2) * 0.2
                                Vector_Valor_P_Max(3) = Vector_Valor_P_Max(3) * 0.2
                                Vector_Valor_P_Max(4) = Vector_Valor_P_Max(4) * 0.2
                                Vector_Valor_P_Max(5) = Vector_Valor_P_Max(5) * 0.2
                                Vector_Valor_P_Max(6) = Vector_Valor_P_Max(6) * 0.2
                                Vector_Valor_P_Max(7) = Vector_Valor_P_Max(7) * 0.2
                                Vector_Valor_P_Max(8) = Vector_Valor_P_Max(8) * 0.2
                                Vector_Valor_P_Max(9) = Vector_Valor_P_Max(9) * 0.2
                                Valor_Promedio_P_Max = Valor_Promedio_P_Max * 0.2
                                Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                            ElseIf Puntero - Puntero_Onda_R > 6 * Frecuencia Then
                                Vector_Valor_P_Max(0) = Vector_Valor_P_Max(0) * 0.4
                                Vector_Valor_P_Max(1) = Vector_Valor_P_Max(1) * 0.4
                                Vector_Valor_P_Max(2) = Vector_Valor_P_Max(2) * 0.4
                                Vector_Valor_P_Max(3) = Vector_Valor_P_Max(3) * 0.4
                                Vector_Valor_P_Max(4) = Vector_Valor_P_Max(4) * 0.4
                                Vector_Valor_P_Max(5) = Vector_Valor_P_Max(5) * 0.4
                                Vector_Valor_P_Max(6) = Vector_Valor_P_Max(6) * 0.4
                                Vector_Valor_P_Max(7) = Vector_Valor_P_Max(7) * 0.4
                                Vector_Valor_P_Max(8) = Vector_Valor_P_Max(8) * 0.4
                                Vector_Valor_P_Max(9) = Vector_Valor_P_Max(9) * 0.4
                                Valor_Promedio_P_Max = Valor_Promedio_P_Max * 0.4
                                Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                            ElseIf Puntero - Puntero_Onda_R > 4 * Frecuencia Then
                                Vector_Valor_P_Max(0) = Vector_Valor_P_Max(0) * 0.6
                                Vector_Valor_P_Max(1) = Vector_Valor_P_Max(1) * 0.6
                                Vector_Valor_P_Max(2) = Vector_Valor_P_Max(2) * 0.6
                                Vector_Valor_P_Max(3) = Vector_Valor_P_Max(3) * 0.6
                                Vector_Valor_P_Max(4) = Vector_Valor_P_Max(4) * 0.6
                                Vector_Valor_P_Max(5) = Vector_Valor_P_Max(5) * 0.6
                                Vector_Valor_P_Max(6) = Vector_Valor_P_Max(6) * 0.6
                                Vector_Valor_P_Max(7) = Vector_Valor_P_Max(7) * 0.6
                                Vector_Valor_P_Max(8) = Vector_Valor_P_Max(8) * 0.6
                                Vector_Valor_P_Max(9) = Vector_Valor_P_Max(9) * 0.6
                                Valor_Promedio_P_Max = Valor_Promedio_P_Max * 0.6
                                Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                            ElseIf Puntero - Puntero_Onda_R > 2 * Frecuencia Then
                                Vector_Valor_P_Max(0) = Vector_Valor_P_Max(0) * 0.8
                                Vector_Valor_P_Max(1) = Vector_Valor_P_Max(1) * 0.8
                                Vector_Valor_P_Max(2) = Vector_Valor_P_Max(2) * 0.8
                                Vector_Valor_P_Max(3) = Vector_Valor_P_Max(3) * 0.8
                                Vector_Valor_P_Max(4) = Vector_Valor_P_Max(4) * 0.8
                                Vector_Valor_P_Max(5) = Vector_Valor_P_Max(5) * 0.8
                                Vector_Valor_P_Max(6) = Vector_Valor_P_Max(6) * 0.8
                                Vector_Valor_P_Max(7) = Vector_Valor_P_Max(7) * 0.8
                                Vector_Valor_P_Max(8) = Vector_Valor_P_Max(8) * 0.8
                                Vector_Valor_P_Max(9) = Vector_Valor_P_Max(9) * 0.8
                                Valor_Promedio_P_Max = Valor_Promedio_P_Max * 0.8
                                Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                            Else
                                Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                            End If
                            Demora_Entre_Ondas_R = 0
                        Else
                            Valor_P_Max = Valor_P_Max * PorCiento_Comparacion
                            'Puntero = Puntero + Math.Floor(Frecuencia * Demora_Despues_QRS) - Demora_Entre_Ondas_R
                            'Index = Index + Math.Floor(Frecuencia * Demora_Despues_QRS) - Demora_Entre_Ondas_R
                            Puntero = Puntero - Demora_Entre_Ondas_R
                            Index = Index - Demora_Entre_Ondas_R
                            Demora_Entre_Ondas_R = 0
                        End If
                    End If
                End While

                ' Limpiar los parametros de busqueda
                Index_Clasificacion = 0
                P_Max_Central = -1
                P_Max_Izquierda = -1
                P_Max_Derecha = -1
                P_Min_Izquierda = 1
                P_Min_Derecha = 1
                P_Min_Derecha_1 = 1
                Bandera_Muesca_Detectada = 0
                ' Obtener posible P_Max_Central
                'While Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                '    Index_Clasificacion = Index_Clasificacion + 1
                '    P_Max_Central = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                '    If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                '        Error_QRS = 1
                '    End If
                'End While
                P_Max_Central = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                Index_Clasificacion_Temp = Index_Clasificacion
                'Obtencion de la primera aproximacio de P_Max_Central(busqueda asta el valor se menor a cero )
                While 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                    Index_Clasificacion = Index_Clasificacion + 1
                    If P_Max_Central < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) Then
                        P_Max_Central = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                        Index_Clasificacion_Temp = Index_Clasificacion
                    End If
                    If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                        Error_QRS = 1
                    End If
                End While
                If P_Max_Central < 0 Then
                    Error_QRS = 4
                End If
                'Index_Clasificacion = Index_Clasificacion_Temp 'Uvicacion del Maximo P_Max_Central

                ' Corregir posible Confucion entre Onda P y un complejo QRS  
                Index_Inicio_Intervalo_Busqueda_Temp = Index + Index_Clasificacion 'Uvicacion del primer cruce por cero despues del Maximo P_Max_Central
                If Segmentos_RR_Promedio > 1.5 * Frecuencia Then
                    '"Segmentos_RR_Promedio*0.3 /1.5 > 0.3 * Frecuencia" es lo mismo que "Segmentos_RR_Promedio > 1.5 * Frecuencia"
                    Index_Fin_Intervalo_Busqueda_Temp = Index + Index_Clasificacion_Temp + 0.3 * Frecuencia
                ElseIf Segmentos_RR_Promedio < Frecuencia Then
                    '"Segmentos_RR_Promedio * 0.3/1.5 < 0.2 * Frecuencia" es lo mismo que "Segmentos_RR_Promedio < * Frecuencia"
                    Index_Fin_Intervalo_Busqueda_Temp = Index + Index_Clasificacion_Temp + 0.2 * Frecuencia
                Else
                    '"(Segmentos_RR_Promedio 0.3/ 1.5)"es lo mismo que  "(Segmentos_RR_Promedio 0.2)"
                    Index_Fin_Intervalo_Busqueda_Temp = Index + Index_Clasificacion_Temp + (Segmentos_RR_Promedio * 0.2)
                End If

                If Cantidad_Leidos - Index_Inicio_Intervalo_Busqueda_Temp < 0.31 * Frecuencia Then
                    Error_QRS = 1
                End If

                ' Busqueda de un P_Max_Derecha mayor a P_Max_Central
                'P_Max_Derecha = P_Max_Central
                P_Max_Derecha = 0
                While Index + Index_Clasificacion < Index_Fin_Intervalo_Busqueda_Temp And Error_QRS = 0
                    Index_Clasificacion = Index_Clasificacion + 1
                    If P_Max_Derecha < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) Then
                        P_Max_Derecha = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                        Index_Clasificacion_Temp_1 = Index_Clasificacion
                    End If
                    If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                        Error_QRS = 1
                    End If
                End While
                ' Confirmar que el valor maximo P_Max_Derecha no esta en el limite del intervalo de busqueda, de ser asi si considera que este podria aumentar mas y por tanto pertenece a otro complejo QRS 
                If Index + Index_Clasificacion_Temp_1 >= Index_Fin_Intervalo_Busqueda_Temp Then
                    P_Max_Derecha = -1
                End If
                ' Validar que no es un cambio de Nivel ¯¯\__
                'Relisar busqueda de posible confucion de ondas si se detyecta un maximo mayor al 80 % de P_Max_Central
                If P_Max_Derecha > P_Max_Central * 0.8 And Error_QRS = 0 Then
                    Index_Clasificacion = Index_Clasificacion_Temp_1
                    Index_Fin_Intervalo_Busqueda_Temp = Index + Index_Clasificacion_Temp_1 + 0.2 * Frecuencia
                    Index_Inicio_Intervalo_Busqueda_Temp = Index + Index_Clasificacion_Temp_1 - 0.2 * Frecuencia

                    ' Avansar a la Derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Derecha
                    While PorCiento_Comparacion_Busqueda * P_Max_Derecha <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Error_QRS = 0
                        Index_Clasificacion = Index_Clasificacion + 1
                        If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                            Error_QRS = 1
                        ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                            Error_QRS = 2
                        End If
                    End While
                    ' Avansar a la Derecha asta que el valor sea menor a 0
                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                    While m < -1 * m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Error_QRS = 0
                        Index_Clasificacion = Index_Clasificacion + 1
                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                        If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                            Error_QRS = 1
                        ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                            Error_QRS = 2
                        End If
                    End While

                    ' Obtener P_Min_Derecha
                    If 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                        While Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                            Index_Clasificacion = Index_Clasificacion + 1
                            P_Min_Derecha = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                            If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                                Error_QRS = 1
                            ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                                Error_QRS = 2
                                P_Min_Derecha = 1
                            End If
                        End While
                    End If

                    If Error_QRS = 0 Or Error_QRS = 2 Then
                        Index_Clasificacion = Index_Clasificacion_Temp_1
                        Error_QRS = 0
                    End If

                    ' Avansar a la izquierda asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Derecha
                    While PorCiento_Comparacion_Busqueda * P_Max_Derecha <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Error_QRS = 0
                        Index_Clasificacion = Index_Clasificacion - 1
                        If Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                            Error_QRS = 2
                        End If
                    End While

                    ' Avansar a la izquierda asta que el valor sea menor al 0
                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                    While m > m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                        Index_Clasificacion = Index_Clasificacion - 1
                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                        If Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                            Error_QRS = 2
                        End If
                    End While
                    'Uvicacion del inicio del lobulo positivo por si es un desnivel
                    Index_Cambio_Nivel = Index + Index_Clasificacion
                    ' Obtener P_Min_Izquierda 
                    If 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) Then
                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                        While m >= 0 And Error_QRS = 0
                            Index_Clasificacion = Index_Clasificacion - 1
                            P_Min_Izquierda = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            If Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                                Error_QRS = 2
                            End If
                        End While
                    End If
                End If



                'Obtencion del P_Min mas pegueño
                If P_Min_Izquierda < P_Min_Derecha Then
                    P_Min_Comparacion = P_Min_Izquierda
                Else
                    P_Min_Comparacion = P_Min_Derecha
                End If

                'Comprobacion si existe una Confucion de Onda T con Complejo QRS (P_Max_Derecha > P_Max_Central Or (Abs(P_Min_Comparacion) > P_Max_Central) y no es un desnivel
                If (P_Max_Derecha <= Margen_Separacion_QRS_Ruido * Valor_Promedio_P_Max And (P_Max_Derecha > P_Max_Central Or (Math.Abs(P_Min_Comparacion) > P_Max_Central And P_Min_Comparacion < 0))) Then
                    'Comprobacion si no es un desnivel
                    If (P_Max_Derecha * Margen_Separacion_Desniveles < Math.Abs(P_Min_Comparacion) And P_Max_Derecha > Margen_Separacion_Desniveles * Math.Abs(P_Min_Comparacion) And P_Min_Comparacion < 0) Then
                        Bandera_Desnivel_Detectado = 0
                        If Index + Index_Clasificacion_Temp_1 < Cantidad_Leidos - 3 Then
                            Index = Index + Index_Clasificacion_Temp_1
                            Puntero = Puntero + Index_Clasificacion_Temp_1
                            Index_Clasificacion = 0
                            Index_Clasificacion_Temp = 0
                            P_Max_Central = P_Max_Derecha
                            Error_QRS = 0
                        Else
                            Error_QRS = 1
                            Index_Clasificacion = 0
                        End If
                    Else
                        Bandera_Desnivel_Detectado = 1
                        If Index + Index_Clasificacion_Temp < Cantidad_Leidos - 3 Then
                            Index_Clasificacion = Index_Clasificacion_Temp 'Uvicacion del Maximo P_Max_Central
                            Error_QRS = 0
                        Else
                            Error_QRS = 1
                            Index_Clasificacion = 0
                        End If
                    End If
                Else
                    Bandera_Desnivel_Detectado = 0
                    If Index + Index_Clasificacion_Temp < Cantidad_Leidos - 3 Then
                        Index_Clasificacion = Index_Clasificacion_Temp 'Uvicacion del Maximo P_Max_Central
                        Error_QRS = 0
                    Else
                        Error_QRS = 1
                        Index_Clasificacion = 0
                    End If
                End If
                ' Limpiar los parametros de busqueda
                P_Max_Derecha = -1
                P_Min_Izquierda = 1
                P_Min_Derecha = 1

                ' Obtener P_Max_Central definitivo y otros
                Bandera_Cambio_Lobulo_Central_a_Derecho = 0
                While Bandera_Cambio_Lobulo_Central_a_Derecho = 0 And Error_QRS = 0

                    Bandera_Cambio_Lobulo_Central_a_Derecho = 1
                    'Obtener posicion de P_Max_Central 
                    Puntero_P_Max_Central = Puntero + Index_Clasificacion

                    Index_Inicio_Intervalo_Busqueda_Temp = Index + Index_Clasificacion - Duracion_Maxima_QRS * Frecuencia
                    Index_Fin_Intervalo_Busqueda_Temp = Index + Index_Clasificacion + Duracion_Maxima_QRS * Frecuencia
                    'Limitar la busqueda se detecta un cambio de nivel
                    If Bandera_Desnivel_Detectado = 1 And Index_Cambio_Nivel < Index_Fin_Intervalo_Busqueda_Temp Then
                        Index_Fin_Intervalo_Busqueda_Temp = Index_Cambio_Nivel
                    End If
                    ' Avansar a la Derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Central
                    While PorCiento_Comparacion_Busqueda * P_Max_Central <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Error_QRS = 0
                        Index_Clasificacion = Index_Clasificacion + 1
                        If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                            Error_QRS = 1
                        ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                            Error_QRS = 2
                        End If
                    End While

                    ' Avansar a la Derecha asta que el valor sea menor a 0
                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                    While m < -1 * m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Error_QRS = 0
                        Index_Clasificacion = Index_Clasificacion + 1
                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                        If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                            Error_QRS = 1
                        ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                            Error_QRS = 2
                        End If
                    End While
                    'Obtener posicion de S
                    Puntero_S = Puntero + Index_Clasificacion

                    ' Obtener P_Min_Derecha
                    If 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                        While Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                            Index_Clasificacion = Index_Clasificacion + 1
                            P_Min_Derecha = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                            If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                                Error_QRS = 1
                            ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                                Error_QRS = 2
                                P_Min_Derecha = 1
                            End If
                        End While
                    End If

                    'Comprobar si existe una muesca comparando contra el 30% P_Max_Central
                    If ((Math.Abs(P_Min_Derecha) < 0.3 * P_Max_Central And P_Min_Derecha < 0) Or P_Min_Derecha > 0) And Error_QRS = 0 Then
                        'Respaldo de Index_Clasificacion
                        Index_Clasificacion_Temp_2 = Index_Clasificacion
                        P_Min_Derecha_Temp = 1
                        'Buscar un P_Min_Derecha negativo o mas pequeño 
                        While Index + Index_Clasificacion < Index_Fin_Intervalo_Busqueda_Temp And Error_QRS = 0
                            Index_Clasificacion = Index_Clasificacion + 1
                            If P_Min_Derecha_Temp > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) Then
                                P_Min_Derecha_Temp = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                                Index_Clasificacion_Temp_1 = Index_Clasificacion
                            End If
                            If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                                Error_QRS = 1
                            ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                                Error_QRS = 2
                            End If
                        End While
                        ' Confirmar que el valor maximo P_Min_Derecha_Temp no esta en el limite del intervalo de busqueda, de ser asi si considera que este podria aumentar mas y por tanto pertenece a otro complejo QRS 
                        If Index + Index_Clasificacion_Temp_1 >= Index_Fin_Intervalo_Busqueda_Temp Then
                            P_Min_Derecha_Temp = 1
                        End If

                        'Confirmar que el  P_Min_Derecha_Temp detectado pertence al complejo QRS 
                        If Math.Abs(P_Min_Derecha_Temp) > 0.4 * P_Max_Central And P_Min_Derecha_Temp < 0 And Error_QRS <> 1 Then
                            'Confirmar que el P_Min_Derecha_Temp detectado es menor a P_Min_Derecha
                            If P_Min_Derecha_Temp < P_Min_Derecha Then
                                Index_Clasificacion = Index_Clasificacion_Temp_1
                                P_Min_Derecha = P_Min_Derecha_Temp
                                Error_QRS = 0
                                Bandera_Muesca_Detectada = 1
                            Else
                                Index_Clasificacion = Index_Clasificacion_Temp_2
                                Error_QRS = 0
                            End If
                        Else
                            Index_Clasificacion = Index_Clasificacion_Temp_2
                            Error_QRS = 0
                        End If

                    End If


                    'Obtener posicion de P_Min_Derecha
                    Puntero_P_Min_Derecha = Puntero + Index_Clasificacion
                    Puntero_S1 = Puntero + Index_Clasificacion

                    ' Avansar a la derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Min_Derecha
                    ' Avansar si P_Min_Derecha<0
                    If P_Min_Derecha < 0 And Error_QRS = 0 Then

                        ' Avansar a la derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Min_Derecha
                        While PorCiento_Comparacion_Busqueda * P_Min_Derecha >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Error_QRS = 0
                            Index_Clasificacion = Index_Clasificacion + 1
                            If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                                Error_QRS = 1
                            ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                                Error_QRS = 2
                            End If
                        End While

                        ' Avansar a la Derecha asta que el valor sea mayor a 0
                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                        While m > m_Comparacion_Wavelet And 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Error_QRS = 0
                            Index_Clasificacion = Index_Clasificacion + 1
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                                Error_QRS = 1
                            ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                                Error_QRS = 2
                            End If
                        End While
                        'Obtener posicion de S1
                        If Error_QRS = 2 Then
                            Puntero_S1 = Puntero_P_Min_Derecha
                        Else
                            Puntero_S1 = Puntero + Index_Clasificacion
                        End If
                        ' Obtener P_Max_Derecha
                        If 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                            While Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                                Index_Clasificacion = Index_Clasificacion + 1
                                P_Max_Derecha = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                                If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                                    Error_QRS = 1
                                ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                                    Error_QRS = 2
                                    P_Max_Derecha = -1
                                End If
                            End While
                        End If

                        'Obtener posicion de P_Max_Derecha
                        Puntero_P_Max_Derecha = Puntero + Index_Clasificacion
                        Puntero_S2 = Puntero + Index_Clasificacion
                        ' Comprobar si P_Max_Derecha > P_Max_Central, de ser asi corregir el P_Max_Central, si no es asi buscar P_Min_Derecha_1
                        If P_Max_Derecha > P_Max_Central Then
                            Puntero = Puntero + Index_Clasificacion
                            Index = Index + Index_Clasificacion
                            Puntero_P_Max_Central = Puntero_P_Max_Derecha
                            P_Max_Central = P_Max_Derecha
                            Bandera_Cambio_Lobulo_Central_a_Derecho = 0

                            P_Max_Derecha = -1
                            P_Min_Derecha = 1
                            P_Min_Derecha_1 = 1
                            Puntero_S = Puntero_P_Max_Derecha
                            Puntero_J = Puntero_P_Max_Derecha
                            Puntero_S1 = Puntero_P_Max_Derecha
                            Puntero_S2 = Puntero_P_Max_Derecha
                            Puntero_S3 = Puntero_P_Max_Derecha


                            Index_Clasificacion = 0
                            Index_Clasificacion_Temp = 0
                        ElseIf P_Max_Derecha > 0 Then
                            ' Avansar a la Derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Derecha, y P_Max_Derecha>0
                            While PorCiento_Comparacion_Busqueda_Extremos * P_Max_Derecha <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Error_QRS = 0
                                Index_Clasificacion = Index_Clasificacion + 1
                                If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                                    Error_QRS = 1
                                ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                                    Error_QRS = 2
                                End If
                            End While

                            ' Avansar a la Derecha asta que el valor sea menor a 0
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m < -1 * m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Error_QRS = 0
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                                    Error_QRS = 1
                                ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                                    Error_QRS = 2
                                End If
                            End While
                            'Obtener posicion de S2

                            Puntero_S2 = Puntero + Index_Clasificacion



                            ' Obtener P_Min_Derecha_1
                            If 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                While Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                                    Index_Clasificacion = Index_Clasificacion + 1
                                    P_Min_Derecha_1 = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                                    If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                                        Error_QRS = 1
                                    ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                                        Error_QRS = 2
                                        P_Min_Derecha_1 = 1
                                    End If
                                End While
                                'Obtener posicion de P_Min_Derecha_1
                                Puntero_P_Min_Derecha_1 = Puntero + Index_Clasificacion

                                ' Avansar a la derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Min_Derecha_1
                                While PorCiento_Comparacion_Busqueda_Extremos * P_Min_Derecha_1 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Error_QRS = 0
                                    Index_Clasificacion = Index_Clasificacion + 1
                                    If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                                        Error_QRS = 1
                                    ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                                        Error_QRS = 2
                                    End If
                                End While

                                ' Avansar a la Derecha asta que el valor sea mayor a 0
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                While m > m_Comparacion_Wavelet And 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Error_QRS = 0
                                    Index_Clasificacion = Index_Clasificacion + 1
                                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                    If Index + Index_Clasificacion > Cantidad_Leidos - 3 Then
                                        Error_QRS = 1
                                    ElseIf Index + Index_Clasificacion > Index_Fin_Intervalo_Busqueda_Temp Then
                                        Error_QRS = 2
                                    End If
                                End While
                                'Obtener posicion de S1
                                Puntero_S3 = Puntero + Index_Clasificacion
                            End If



                        End If

                    End If
                End While
                If Error_QRS = 0 Or Error_QRS = 2 Then
                    Index_Clasificacion = Index_Clasificacion_Temp
                    Error_QRS = 0
                End If

                ' Avansar a la izquierda asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Central
                While PorCiento_Comparacion_Busqueda * P_Max_Central <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Error_QRS = 0
                    Index_Clasificacion = Index_Clasificacion - 1
                    If Index + Index_Clasificacion < 2 Then
                        Error_QRS = 3
                    ElseIf Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                        Error_QRS = 2
                    End If
                End While

                ' Avansar a la izquierda asta que el valor sea menor al 0
                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                'While m > m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                While m > 0 And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                    Index_Clasificacion = Index_Clasificacion - 1
                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                    If Index + Index_Clasificacion < 2 Then
                        Error_QRS = 3
                    ElseIf Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                        Error_QRS = 2
                    End If
                End While
                'Obtener posicion de R

                Puntero_R = Puntero + Index_Clasificacion


                ' Obtener P_Min_Izquierda 
                If 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) Then
                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                    While m >= 0 And Error_QRS = 0
                        Index_Clasificacion = Index_Clasificacion - 1
                        P_Min_Izquierda = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                        If Index + Index_Clasificacion < 2 Then
                            Error_QRS = 3
                        ElseIf Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                            Error_QRS = 2
                            P_Min_Izquierda = 1
                        End If
                    End While
                End If


                'Comprobar si existe una muesca comparando contra el 30% P_Max_Central
                If ((Math.Abs(P_Min_Izquierda) < 0.3 * P_Max_Central And P_Min_Izquierda < 0) Or P_Min_Izquierda > 0) And Error_QRS = 0 Then
                    'Respaldo de Index_Clasificacion
                    Index_Clasificacion_Temp_2 = Index_Clasificacion
                    P_Min_Izquierda_Temp = 1
                    'Buscar un P_Min_Izquierda negativo o mas pequeño 
                    While Index + Index_Clasificacion > Index_Inicio_Intervalo_Busqueda_Temp And Error_QRS = 0
                        Index_Clasificacion = Index_Clasificacion - 1
                        If P_Min_Izquierda_Temp > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) Then
                            P_Min_Izquierda_Temp = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                            Index_Clasificacion_Temp_1 = Index_Clasificacion
                        End If
                        If Index + Index_Clasificacion < 2 Then
                            Error_QRS = 3
                        ElseIf Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                            Error_QRS = 2
                        End If
                    End While
                    ' Confirmar que el valor maximo P_Min_Izquierda_Temp no esta en el limite del intervalo de busqueda, de ser asi si considera que este podria aumentar mas y por tanto pertenece a otro complejo QRS 
                    If Index + Index_Clasificacion_Temp_1 <= Index_Inicio_Intervalo_Busqueda_Temp Then
                        P_Min_Izquierda_Temp = 1
                    End If

                    'Confirmar que el  P_Min_Izquierda_Temp detectado pertence al complejo QRS 
                    If Math.Abs(P_Min_Izquierda_Temp) > 0.4 * P_Max_Central And P_Min_Izquierda_Temp < 0 And Error_QRS <> 3 Then
                        'Confirmar que el P_Min_Izquierda_Temp detectado es menor a P_Min_Izquierda
                        If P_Min_Izquierda_Temp < P_Min_Izquierda Then
                            Index_Clasificacion = Index_Clasificacion_Temp_1
                            P_Min_Izquierda = P_Min_Izquierda_Temp
                            Error_QRS = 0
                            Bandera_Muesca_Detectada = Bandera_Muesca_Detectada + 2
                        Else
                            Index_Clasificacion = Index_Clasificacion_Temp_2
                            Error_QRS = 0
                        End If
                    Else
                        Index_Clasificacion = Index_Clasificacion_Temp_2
                        Error_QRS = 0
                    End If

                End If



                'Obtener posicion de P_Min_Izquierda
                Puntero_P_Min_Izquierda = Puntero + Index_Clasificacion
                Puntero_Q = Puntero + Index_Clasificacion



                ' Avansar a la izquierda asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Min_Izquierda
                ' Avansar si P_Min_Izquierda<0
                If P_Min_Izquierda < 0 And Error_QRS = 0 Then
                    ' Avansar a la izquierda asta que el valor sea mayor al PorCiento_Comparacion_Busqueda*P_Max_Central
                    While PorCiento_Comparacion_Busqueda * P_Min_Izquierda >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Error_QRS = 0
                        Index_Clasificacion = Index_Clasificacion - 1

                        If Index + Index_Clasificacion < 2 Then
                            Error_QRS = 3
                        ElseIf Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                            Error_QRS = 2
                        End If
                    End While

                    ' Avansar a la izquierda asta que el valor sea mayor al 0
                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                    While m < -1 * m_Comparacion_Wavelet And 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                        Index_Clasificacion = Index_Clasificacion - 1
                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                        If Index + Index_Clasificacion < 2 Then
                            Error_QRS = 3
                        ElseIf Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                            Error_QRS = 2
                        End If
                    End While

                    'Obtener posicion de Q
                    If Error_QRS = 2 Then
                        Puntero_Q = Puntero_P_Min_Izquierda
                    Else
                        Puntero_Q = Puntero + Index_Clasificacion + 1
                    End If


                    ' Obtener P_Max_Izquierda 
                    If 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) Then
                        While Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                            Index_Clasificacion = Index_Clasificacion - 1
                            P_Max_Izquierda = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1)
                            If Index + Index_Clasificacion < 2 Then
                                Error_QRS = 3
                            ElseIf Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                                Error_QRS = 2
                                P_Max_Izquierda = -1
                            End If
                        End While
                        'Obtener posicion de Puntero_P_Max_Izquierda 
                        Puntero_P_Max_Izquierda = Puntero + Index_Clasificacion

                        ' Avansar a la izquierda asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Izquierda o la pedendi
                        While PorCiento_Comparacion_Busqueda_Extremos * P_Max_Izquierda <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) And Error_QRS = 0
                            Index_Clasificacion = Index_Clasificacion - 1
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            If Index + Index_Clasificacion < 2 Then
                                Error_QRS = 3
                            ElseIf Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                                Error_QRS = 2
                            End If
                        End While

                        ' Avansar a la izquierda asta que el valor sea menor al 0
                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                        While m > m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Error_QRS = 0
                            Index_Clasificacion = Index_Clasificacion - 1
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            If Index + Index_Clasificacion < 2 Then
                                Error_QRS = 3
                            ElseIf Index + Index_Clasificacion < Index_Inicio_Intervalo_Busqueda_Temp Then
                                Error_QRS = 2
                            End If
                        End While

                        'Obtener posicion de Q
                        Puntero_Q_i = Puntero + Index_Clasificacion

                    End If


                End If

                '-------------------------------------------------------------------------------------------------------------
                'Identificar si en lugar de desnivel, es una posible muesca 

                If Error_QRS = 2 Or Error_QRS = 3 Then
                    Error_QRS = 0
                End If


                'Clasificar el Compelo QRS
                If Error_QRS = 0 Then
                    'Eliminar la posible muesca si la separacion entre Puntero_P_Min_Derecha y Puntero_P_Max_Central es supériore a 100 ms
                    'Si se detecta una posible muesca, se comprueba si el valor del Minimo contrario(Izquierda o Derecha) supera el 40% de P_Max_Central y que el minimo detectado no esta a mas alla 100ms   
                    If Bandera_Muesca_Detectada = 1 And (Math.Abs(P_Min_Izquierda) > 0.4 * P_Max_Central And P_Min_Izquierda < 0) And (Puntero_P_Min_Derecha - Puntero_P_Max_Central) > 0.1 * Frecuencia Then
                        P_Max_Derecha = -1
                        P_Min_Derecha = 1
                    ElseIf Bandera_Muesca_Detectada = 2 And (Math.Abs(P_Min_Derecha) > 0.4 * P_Max_Central And P_Min_Derecha < 0) And (Puntero_P_Max_Central - Puntero_P_Min_Izquierda) > 0.1 * Frecuencia Then
                        P_Max_Izquierda = -1
                        P_Min_Izquierda = 1
                    ElseIf Bandera_Muesca_Detectada = 3 Then
                        'Si se detecta una la existencia de dos posible muesca me quedo con la mas cercana a  Puntero_P_Max_Central
                        If (Puntero_P_Max_Central - Puntero_P_Min_Izquierda) > (Puntero_P_Min_Derecha - Puntero_P_Max_Central) Then
                            P_Max_Izquierda = -1
                            P_Min_Izquierda = 1
                        Else
                            P_Max_Derecha = -1
                            P_Min_Derecha = 1
                        End If
                    End If
                    'Solo de pruebaaa
                    '-----------------------------------------
                    'If Puntero_Cantidad_QRS = 30 Then
                    '    Dim preuba As Double = 0
                    'End If

                    'Si la separacion entre el punto J y el punto Q de dos QRS consecutivos es menor a 150ms y el valor absoluto de P_Min_Izquierda no supera al 50 % de P_Min_Derecha se elimina P_Max_Izquierda por ser parte de la Onda P
                    If Puntero_Q - Puntero_Ultimo_J < Frecuencia * Separacion_Minima_QRS And P_Min_Derecha * 0.3 < P_Min_Izquierda Then
                        P_Max_Izquierda = -1
                    ElseIf P_Min_Derecha * PorCiento_Rechazo_Extremos < P_Min_Izquierda Then
                        'Si el valor absoluto de P_Min_Izquierda no supera al 7 % de P_Min_Derecha se elimina P_Max_Izquierda y P_Min_Izquierda por ser ruido
                        P_Max_Izquierda = -1
                        P_Min_Izquierda = 1
                    End If


                    'Si el valor absoluto de  P_Min_Derecha no supera al 7 % de P_Min_Izquierda se elimina P_Max_Derecha y P_Min_Derecha por ser ruido
                    If P_Min_Izquierda * PorCiento_Rechazo_Extremos < P_Min_Derecha Then
                        P_Max_Derecha = -1
                        P_Min_Derecha = 1
                    End If



                    If P_Max_Derecha < P_Max_Central * PorCiento_Rechazo_Extremos Or 0 < P_Min_Derecha Then
                        P_Max_Derecha = -1
                    End If

                    If P_Max_Izquierda < P_Max_Central * PorCiento_Rechazo_Extremos Or 0 < P_Min_Izquierda Then
                        P_Max_Izquierda = -1
                    End If

                    'If P_Min_Izquierda * 0.02 < P_Min_Derecha And P_Max_Derecha <= 0 Then
                    '    P_Min_Derecha = 1
                    'ElseIf P_Min_Izquierda * 0.02 < P_Min_Derecha And P_Max_Derecha <= P_Max_Central * 0.03 Then
                    '    P_Min_Derecha = 1
                    '    P_Max_Derecha = -1
                    'End If

                    '-----------------------------------------

                    If P_Max_Izquierda <= 0 And P_Max_Derecha <= 0 Then
                        If P_Min_Izquierda > 0 And P_Min_Derecha > 0 Then
                            Tipo_QRS = Tipos_QRS.Sin_QRS
                        ElseIf P_Min_Izquierda > 0 And P_Min_Derecha < 0 Then
                            Tipo_QRS = Tipos_QRS.QS_0
                        ElseIf P_Min_Izquierda < 0 And P_Min_Derecha > 0 Then
                            Tipo_QRS = Tipos_QRS.R_0
                        Else
                            Tipo_QRS = Tipos_QRS.Rs_0
                        End If
                    ElseIf P_Max_Izquierda > 0 And P_Max_Derecha < 0 Then
                        If P_Min_Izquierda < 0 And P_Min_Derecha < 0 Then
                            Tipo_QRS = Tipos_QRS.qRs_1
                        ElseIf P_Min_Izquierda < 0 And P_Min_Derecha > 0 Then
                            Tipo_QRS = Tipos_QRS.qR_1
                        End If
                    ElseIf P_Max_Izquierda < 0 And P_Max_Derecha > 0 Then

                        If P_Min_Izquierda > 0 Then
                            If P_Min_Derecha_1 < 0 Then
                                Tipo_QRS = Tipos_QRS.Qrs_0
                            ElseIf P_Min_Derecha_1 > 0 Then
                                Tipo_QRS = Tipos_QRS.Qr_0
                            End If
                        ElseIf P_Min_Izquierda < 0 And P_Min_Izquierda > P_Min_Derecha_1 * 0.5 Then
                            Tipo_QRS = Tipos_QRS.Qrs_E_0
                        Else
                            Tipo_QRS = Tipos_QRS.RS_E_0
                        End If

                    ElseIf P_Max_Izquierda > 0 And P_Max_Derecha > 0 Then
                        If P_Max_Derecha > P_Max_Central * 0.75 And P_Max_Izquierda > P_Max_Central * 0.75 Then
                            Tipo_QRS = Tipos_QRS.Sin_QRS
                        ElseIf P_Max_Derecha > P_Max_Izquierda And P_Min_Derecha < P_Min_Izquierda Then
                            If P_Min_Derecha_1 < 0 Then
                                Tipo_QRS = Tipos_QRS.Qrs_E_0
                            ElseIf P_Min_Derecha_1 > 0 Then
                                Tipo_QRS = Tipos_QRS.Qr_E_0
                            End If
                        Else
                            Tipo_QRS = Tipos_QRS.qRs_E_1
                        End If
                        'If P_Max_Derecha / P_Max_Central > 0.5 Then
                        '    If P_Min_Derecha_1 < 0 Then
                        '        Tipo_QRS = Tipos_QRS.Qrs_E_0
                        '    ElseIf P_Min_Derecha_1 > 0 Then
                        '        Tipo_QRS = Tipos_QRS.Qr_E_0
                        '    End If
                        'Else
                        '    Tipo_QRS = Tipos_QRS.qRs_E_1
                        'End If
                    End If

                    'Obtener las uvicaciones de Puntero_Q_i, Puntero_Q, Puntero_R, Puntero_S, Puntero_J

                    Select Case Tipo_QRS

                        Case Tipos_QRS.Qr_0
                            'Avansar a la izquierda asta actualizar el valor
                            Index_Final = Puntero_R - Puntero
                            If Index + Index_Final < 1 Then
                                Index_Final = 2 - Index
                            End If
                            Index_Clasificacion = Puntero_P_Max_Central - Puntero - (Puntero_P_Max_Central - Puntero_R) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                Index_Clasificacion = Index_Clasificacion - 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While

                            If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                Puntero_R = Puntero + Index_Clasificacion + 1
                            Else
                                Puntero_R = Puntero + Index_Clasificacion
                            End If

                            ' Avansar a la derecha asta actualizar el valor
                            Index_Final = Puntero_S2 - Puntero
                            Index_Clasificacion = Puntero_P_Max_Derecha - Puntero + (Puntero_S2 - Puntero_P_Max_Derecha) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m < -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While

                            If m > -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                Puntero_S2 = Puntero + Index_Clasificacion - 1
                            Else
                                Puntero_S2 = Puntero + Index_Clasificacion
                            End If

                            Puntero_Q_i = Puntero_R
                            Puntero_Q = Puntero_S
                            Puntero_R = Puntero_S1
                            Puntero_S = Puntero_S2
                            Puntero_J = Puntero_S2

                        Case Tipos_QRS.qR_1
                            'Avansar a la izquierda asta actualizar el valor
                            Index_Final = Puntero_Q_i - Puntero
                            If Index + Index_Final < 1 Then
                                Index_Final = 2 - Index
                            End If
                            Index_Clasificacion = Puntero_P_Max_Izquierda - Puntero - (Puntero_P_Max_Izquierda - Puntero_Q_i) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                Index_Clasificacion = Index_Clasificacion - 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While

                            If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                Puntero_Q_i = Puntero + Index_Clasificacion + 1
                            Else
                                Puntero_Q_i = Puntero + Index_Clasificacion
                            End If

                            ' Avansar a la derecha asta actualizar el valor
                            Index_Final = Puntero_S - Puntero
                            Index_Clasificacion = Puntero_P_Max_Central - Puntero + (Puntero_S - Puntero_P_Max_Central) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m < -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While

                            If m > -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                Puntero_S = Puntero + Index_Clasificacion - 1
                            Else
                                Puntero_S = Puntero + Index_Clasificacion
                            End If
                            Puntero_Q_i = Puntero_Q_i
                            Puntero_Q = Puntero_Q
                            Puntero_R = Puntero_R
                            Puntero_S = Puntero_S
                            Puntero_J = Puntero_S
                        Case Tipos_QRS.Qrs_0
                            'Avansar a la izquierda asta actualizar el valor
                            Index_Final = Puntero_R - Puntero
                            If Index + Index_Final < 1 Then
                                Index_Final = 2 - Index
                            End If
                            Index_Clasificacion = Puntero_P_Max_Central - Puntero - (Puntero_P_Max_Central - Puntero_R) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                Index_Clasificacion = Index_Clasificacion - 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While
                            If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                Puntero_R = Puntero + Index_Clasificacion + 1
                            Else
                                Puntero_R = Puntero + Index_Clasificacion
                            End If

                            ' Avansar a la derecha asta actualizar el valor
                            Index_Final = Puntero_S3 - Puntero
                            Index_Clasificacion = Puntero_P_Min_Derecha_1 - Puntero + (Puntero_S3 - Puntero_P_Min_Derecha_1) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While

                            If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                Puntero_S3 = Puntero + Index_Clasificacion - 1
                            Else
                                Puntero_S3 = Puntero + Index_Clasificacion
                            End If

                            Puntero_Q_i = Puntero_R
                            Puntero_Q = Puntero_S
                            Puntero_R = Puntero_S1
                            Puntero_S = Puntero_S2
                            Puntero_J = Puntero_S3
                        Case Tipos_QRS.qRs_1
                            'Avansar a la izquierda asta actualizar el valor
                            Index_Final = Puntero_Q_i - Puntero
                            If Index + Index_Final < 1 Then
                                Index_Final = 2 - Index
                            End If
                            Index_Clasificacion = Puntero_P_Max_Izquierda - Puntero - (Puntero_P_Max_Izquierda - Puntero_Q_i) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                Index_Clasificacion = Index_Clasificacion - 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While

                            If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                Puntero_Q_i = Puntero + Index_Clasificacion + 1
                            Else
                                Puntero_Q_i = Puntero + Index_Clasificacion
                            End If

                            ' Avansar a la derecha asta actualizar el valor
                            Index_Final = Puntero_S1 - Puntero
                            Index_Clasificacion = Puntero_P_Min_Derecha - Puntero + (Puntero_S1 - Puntero_P_Min_Derecha) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While
                            If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                Puntero_S1 = Puntero + Index_Clasificacion - 1
                            Else
                                Puntero_S1 = Puntero + Index_Clasificacion
                            End If


                            Puntero_Q_i = Puntero_Q_i
                            Puntero_Q = Puntero_Q
                            Puntero_R = Puntero_R
                            Puntero_S = Puntero_S
                            Puntero_J = Puntero_S1
                        Case Tipos_QRS.R_0
                            'Avansar a la izquierda asta actualizar el valor
                            Index_Final = Puntero_Q - Puntero
                            If Index + Index_Final < 1 Then
                                Index_Final = 2 - Index
                            End If
                            Index_Clasificacion = Puntero_P_Min_Izquierda - Puntero - (Puntero_P_Min_Izquierda - Puntero_Q) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m < -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                Index_Clasificacion = Index_Clasificacion - 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While

                            If m > -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                Puntero_Q = Puntero + Index_Clasificacion + 1
                            Else
                                Puntero_Q = Puntero + Index_Clasificacion
                            End If

                            ' Avansar a la derecha asta actualizar el valor
                            Index_Final = Puntero_S - Puntero
                            Index_Clasificacion = Puntero_P_Max_Central - Puntero + (Puntero_S - Puntero_P_Max_Central) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m < -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While
                            If m > -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                Puntero_S = Puntero + Index_Clasificacion - 1
                            Else
                                Puntero_S = Puntero + Index_Clasificacion
                            End If

                            Puntero_Q_i = Puntero_Q
                            Puntero_Q = Puntero_Q
                            Puntero_R = Puntero_R
                            Puntero_S = Puntero_S
                            Puntero_J = Puntero_S
                        Case Tipos_QRS.Rs_0
                            'Avansar a la izquierda asta actualizar el valor
                            Index_Final = Puntero_Q - Puntero
                            If Index + Index_Final < 1 Then
                                Index_Final = 2 - Index - Index
                            End If
                            Index_Clasificacion = Puntero_P_Min_Izquierda - Puntero - (Puntero_P_Min_Izquierda - Puntero_Q) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m < -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                Index_Clasificacion = Index_Clasificacion - 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While
                            If m > -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                Puntero_Q = Puntero + Index_Clasificacion + 1
                            Else
                                Puntero_Q = Puntero + Index_Clasificacion
                            End If

                            ' Avansar a la derecha asta actualizar el valor
                            Index_Final = Puntero_S1 - Puntero
                            Index_Clasificacion = Puntero_P_Min_Derecha - Puntero + (Puntero_S1 - Puntero_P_Min_Derecha) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While
                            If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                Puntero_S1 = Puntero + Index_Clasificacion - 1
                            Else
                                Puntero_S1 = Puntero + Index_Clasificacion
                            End If


                            Puntero_Q_i = Puntero_Q
                            Puntero_Q = Puntero_Q
                            Puntero_R = Puntero_R
                            Puntero_S = Puntero_S
                            Puntero_J = Puntero_S1
                        Case Tipos_QRS.QS_0
                            'Avansar a la izquierda asta actualizar el valor
                            Index_Final = Puntero_R - Puntero
                            If Index + Index_Final < 1 Then
                                Index_Final = 2 - Index
                            End If
                            Index_Clasificacion = Puntero_P_Max_Central - Puntero - (Puntero_P_Max_Central - Puntero_R) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                Index_Clasificacion = Index_Clasificacion - 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While
                            If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                Puntero_R = Puntero + Index_Clasificacion + 1
                            Else
                                Puntero_R = Puntero + Index_Clasificacion
                            End If

                            ' Avansar a la derecha asta actualizar el valor
                            Index_Final = Puntero_S1 - Puntero
                            Index_Clasificacion = Puntero_P_Min_Derecha - Puntero + (Puntero_S1 - Puntero_P_Min_Derecha) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While
                            If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                Puntero_S1 = Puntero + Index_Clasificacion - 1
                            Else
                                Puntero_S1 = Puntero + Index_Clasificacion
                            End If

                            Puntero_Q_i = Puntero_R
                            Puntero_Q = Puntero_S
                            Puntero_R = Puntero_S
                            Puntero_S = Puntero_S
                            Puntero_J = Puntero_S1
                        Case Tipos_QRS.Qr_E_0
                            'Avansar a la izquierda asta actualizar el valor
                            Index_Final = Puntero_R - Puntero
                            If Index + Index_Final < 1 Then
                                Index_Final = 2 - Index
                            End If
                            Index_Clasificacion = Puntero_P_Max_Central - Puntero - (Puntero_P_Max_Central - Puntero_R) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                Index_Clasificacion = Index_Clasificacion - 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While
                            If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                Puntero_R = Puntero + Index_Clasificacion + 1
                            Else
                                Puntero_R = Puntero + Index_Clasificacion
                            End If

                            ' Avansar a la derecha asta actualizar el valor
                            Index_Final = Puntero_S2 - Puntero
                            Index_Clasificacion = Puntero_P_Max_Derecha - Puntero + (Puntero_S2 - Puntero_P_Max_Derecha) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m < -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While

                            If m > -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                Puntero_S2 = Puntero + Index_Clasificacion - 1
                            Else
                                Puntero_S2 = Puntero + Index_Clasificacion
                            End If

                            Puntero_Q_i = Puntero_R
                            Puntero_Q = Puntero_S
                            Puntero_R = Puntero_S1
                            Puntero_S = Puntero_S2
                            Puntero_J = Puntero_S2
                        Case Tipos_QRS.Qrs_E_0
                            'Avansar a la izquierda asta actualizar el valor
                            Index_Final = Puntero_R - Puntero
                            If Index + Index_Final < 1 Then
                                Index_Final = 2 - Index
                            End If
                            Index_Clasificacion = Puntero_P_Max_Central - Puntero - (Puntero_P_Max_Central - Puntero_R) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                Index_Clasificacion = Index_Clasificacion - 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While
                            If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                Puntero_R = Puntero + Index_Clasificacion + 1
                            Else
                                Puntero_R = Puntero + Index_Clasificacion
                            End If

                            ' Avansar a la derecha asta actualizar el valor
                            Index_Final = Puntero_S3 - Puntero
                            Index_Clasificacion = Puntero_P_Min_Derecha_1 - Puntero + (Puntero_S3 - Puntero_P_Min_Derecha_1) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While

                            If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                Puntero_S3 = Puntero + Index_Clasificacion - 1
                            Else
                                Puntero_S3 = Puntero + Index_Clasificacion
                            End If


                            Puntero_Q_i = Puntero_R
                            Puntero_Q = Puntero_S
                            Puntero_R = Puntero_S1
                            Puntero_S = Puntero_S2
                            Puntero_J = Puntero_S3
                        Case Tipos_QRS.qRs_E_1
                            'Avansar a la izquierda asta actualizar el valor
                            Index_Final = Puntero_Q_i - Puntero
                            If Index + Index_Final < 1 Then
                                Index_Final = 2 - Index
                            End If
                            Index_Clasificacion = Puntero_P_Max_Izquierda - Puntero - (Puntero_P_Max_Izquierda - Puntero_Q_i) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                Index_Clasificacion = Index_Clasificacion - 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While


                            If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                Puntero_Q_i = Puntero + Index_Clasificacion + 1
                            Else
                                Puntero_Q_i = Puntero + Index_Clasificacion
                            End If

                            ' Avansar a la derecha asta actualizar el valor
                            Index_Final = Puntero_S1 - Puntero
                            Index_Clasificacion = Puntero_P_Min_Derecha - Puntero + (Puntero_S1 - Puntero_P_Min_Derecha) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While

                            If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                Puntero_S1 = Puntero + Index_Clasificacion - 1
                            Else
                                Puntero_S1 = Puntero + Index_Clasificacion
                            End If

                            Puntero_Q_i = Puntero_Q_i
                            Puntero_Q = Puntero_Q
                            Puntero_R = Puntero_R
                            Puntero_S = Puntero_S
                            Puntero_J = Puntero_S1
                        Case Tipos_QRS.RS_E_0
                            'Avansar a la izquierda asta actualizar el valor
                            Index_Final = Puntero_Q - Puntero
                            If Index + Index_Final < 1 Then
                                Index_Final = 2 - Index - Index
                            End If
                            Index_Clasificacion = Puntero_P_Min_Izquierda - Puntero - (Puntero_P_Min_Izquierda - Puntero_Q) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m < -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                Index_Clasificacion = Index_Clasificacion - 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While
                            If m > -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                Puntero_Q = Puntero + Index_Clasificacion + 1
                            Else
                                Puntero_Q = Puntero + Index_Clasificacion
                            End If

                            ' Avansar a la derecha asta actualizar el valor
                            Index_Final = Puntero_S1 - Puntero
                            Index_Clasificacion = Puntero_P_Min_Derecha - Puntero + (Puntero_S1 - Puntero_P_Min_Derecha) / 2
                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                Index_Clasificacion = Index_Clasificacion + 1
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                            End While
                            If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                Puntero_S1 = Puntero + Index_Clasificacion - 1
                            Else
                                Puntero_S1 = Puntero + Index_Clasificacion
                            End If


                            Puntero_Q_i = Puntero_Q
                            Puntero_Q = Puntero_Q
                            Puntero_R = Puntero_R
                            Puntero_S = Puntero_S
                            Puntero_J = Puntero_S1
                        Case Else
                            Puntero_Q_i = Puntero_R
                            Puntero_Q = Puntero_R
                            Puntero_R = Puntero_P_Max_Central
                            Puntero_S = Puntero_S
                            Puntero_J = Puntero_S

                    End Select

                End If
                'Actulizando un nuevo QRS
                Select Case Error_QRS
                    Case 0
                        'Obtencion del P_Min mas pegueño
                        If P_Min_Izquierda < P_Min_Derecha Then
                            P_Min_Comparacion = P_Min_Izquierda
                        Else
                            P_Min_Comparacion = P_Min_Derecha
                        End If
                        'Comprobacion de posible ruido, Fluter o desnivel
                        If Tipo_QRS <> Tipos_QRS.Sin_QRS And Puntero_J - Puntero_Q_i > Duracion_Minima_QRS * Frecuencia Then
                            'Comprobacion de posible confucion de la onda T con un complejo QRS:
                            'Se resta la uvicacion del punto R del RR anterior menos la del punto R del RR calculado y 
                            'el intervalo tiene que ser mayor al 50% (1.5/3=0.5)del Segmentos_RR_Promedio o mayor a la Separacion_Minima_QRS 
                            If ((Segmentos_RR_Promedio * 0.2 >= Frecuencia * Separacion_Minima_QRS And Puntero_R - Puntero_Ultimo_R >= Segmentos_RR_Promedio * 0.2) Or (Segmentos_RR_Promedio * 0.2 < Frecuencia * Separacion_Minima_QRS And Puntero_R - Puntero_Ultimo_R >= Frecuencia * Separacion_Minima_QRS)) Or Bandera_Primera_Lectura_Datos = 1 Then
                                'If Puntero_Q - Puntero_Ultimo_J > Frecuencia * Separacion_Minima_QRS Then
                                'Comprobacion de posible desnivel
                                If P_Max_Central * Margen_Separacion_Desniveles < Math.Abs(P_Min_Comparacion) And P_Max_Central > Margen_Separacion_Desniveles * Math.Abs(P_Min_Comparacion) And P_Min_Comparacion < 0 Then
                                    'Comprobacion de posible ruido
                                    If (P_Max_Central <= Margen_Separacion_QRS_Ruido * Valor_Promedio_P_Max And P_Max_Central >= Valor_Promedio_P_Max / 3) Then
                                        'No actualizar Valor_Promedio_P_Max si el nuevo P_Max_Central lo super en 2.5 porque es muy probla que sea un latido ectópico y puede dificultar lasDetecciones siguientes    
                                        ' O se presentan 4 latidos consecutivos con las mismas  caracteristicas Bandera_Latido_Ectopico >3 se 
                                        If (P_Max_Central <= Margen_Actualizacion_R_Promedio * Valor_Promedio_P_Max And P_Max_Central >= Valor_Promedio_P_Max / 3) Or Bandera_Latido_Ectopico >= Cantidad_Latido_Ectopico Then
                                            Vector_Valor_P_Max(0) = Vector_Valor_P_Max(1)
                                            Vector_Valor_P_Max(1) = Vector_Valor_P_Max(2)
                                            Vector_Valor_P_Max(2) = Vector_Valor_P_Max(3)
                                            Vector_Valor_P_Max(3) = Vector_Valor_P_Max(4)
                                            Vector_Valor_P_Max(4) = Vector_Valor_P_Max(5)
                                            Vector_Valor_P_Max(5) = Vector_Valor_P_Max(6)
                                            Vector_Valor_P_Max(6) = Vector_Valor_P_Max(7)
                                            Vector_Valor_P_Max(7) = Vector_Valor_P_Max(8)
                                            Vector_Valor_P_Max(8) = Vector_Valor_P_Max(9)
                                            'Validar si se detecto un aunmento de la la amplitud de P_Max_Central superior al 2.5 de Valor_Promedio_P_Max, no ser asi se borra Vector_Valor_P_Max_Ectopico si se dectecto algun latido Ectopico
                                            If Bandera_Latido_Ectopico >= Cantidad_Latido_Ectopico Then
                                                For i = 0 To Vector_Valor_P_Max_Ectopico.Count - 1
                                                    Vector_Valor_P_Max(9 - Vector_Valor_P_Max_Ectopico.Count + i) = Vector_Valor_P_Max_Ectopico(i)
                                                    Vector_Valor_P_Max_Ectopico(i) = 0
                                                Next
                                            ElseIf Bandera_Latido_Ectopico > 0 Then
                                                For i = 0 To Vector_Valor_P_Max_Ectopico.Count - 1
                                                    Vector_Valor_P_Max_Ectopico(i) = 0
                                                Next
                                            End If
                                            Vector_Valor_P_Max(9) = P_Max_Central
                                            Valor_Promedio_P_Max = (Vector_Valor_P_Max(0) + Vector_Valor_P_Max(1) + Vector_Valor_P_Max(2) + Vector_Valor_P_Max(3) + Vector_Valor_P_Max(4) + Vector_Valor_P_Max(5) + Vector_Valor_P_Max(6) + Vector_Valor_P_Max(7) + Vector_Valor_P_Max(8) + Vector_Valor_P_Max(9)) / 10
                                            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                                            Bandera_Latido_Ectopico = 0
                                        Else
                                            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                                            Bandera_Latido_Ectopico = Bandera_Latido_Ectopico + 1
                                            For i = 1 To Vector_Valor_P_Max_Ectopico.Count - 1
                                                Vector_Valor_P_Max_Ectopico(i - 1) = Vector_Valor_P_Max_Ectopico(i)
                                            Next
                                            Vector_Valor_P_Max_Ectopico(Vector_Valor_P_Max_Ectopico.Count - 1) = P_Max_Central
                                        End If
                                        Bandera_Primera_Lectura_Datos = 0
                                        Segmentos_RR(0) = Segmentos_RR(1)
                                        Segmentos_RR(1) = Segmentos_RR(2)
                                        Segmentos_RR(2) = Segmentos_RR(3)
                                        Segmentos_RR(3) = Segmentos_RR(4)
                                        Segmentos_RR(4) = Segmentos_RR(5)
                                        Segmentos_RR(5) = Segmentos_RR(6)
                                        Segmentos_RR(6) = Segmentos_RR(7)
                                        Segmentos_RR(7) = Segmentos_RR(8)
                                        Segmentos_RR(8) = Segmentos_RR(9)
                                        Segmentos_RR(9) = Puntero_R - Puntero_Onda_R
                                        'Validar que el segmento RR no sea superior a 2s ni inferior a 0.24s
                                        If Segmentos_RR(9) > 2 * Frecuencia Then
                                            Segmentos_RR(9) = 2 * Frecuencia
                                        ElseIf Segmentos_RR(9) < 0.24 * Frecuencia Then
                                            Segmentos_RR(9) = 0.24 * Frecuencia
                                        End If
                                        Puntero_Onda_R = Puntero_R
                                        Segmentos_RR_Promedio = (Segmentos_RR(0) + Segmentos_RR(1) + Segmentos_RR(2) + Segmentos_RR(3) + Segmentos_RR(4) + Segmentos_RR(5) + Segmentos_RR(6) + Segmentos_RR(7) + Segmentos_RR(8) + Segmentos_RR(9)) * (1.5) / 10
                                        Puntero_Cantidad_QRS = Puntero_Cantidad_QRS + 1
                                        Tabla_Datos.Rows.Add(Puntero_Cantidad_QRS, Puntero_Q_i, Puntero_Q, Puntero_R, Puntero_S, Puntero_J, Tipo_QRS)
                                        Puntero_Ultimo_R = Puntero_R
                                        'If Puntero_Cantidad_QRS = 938 Then
                                        '    Dim a As Double = 0
                                        'End If

                                    Else
                                        'Rectificacion de "Valor_Promedio_P_Max" y "Valor_P_Max" se niega la escritura pr "P_Max_Central <= 2 * Valor_Promedio_P_Max" y no se escrito nada por mas de 2s  
                                        If Puntero_R - Puntero_Onda_R > 2 * Frecuencia Then
                                            Vector_Valor_P_Max(0) = Vector_Valor_P_Max(0) * 1.5
                                            Vector_Valor_P_Max(1) = Vector_Valor_P_Max(1) * 1.5
                                            Vector_Valor_P_Max(2) = Vector_Valor_P_Max(2) * 1.5
                                            Vector_Valor_P_Max(3) = Vector_Valor_P_Max(3) * 1.5
                                            Vector_Valor_P_Max(4) = Vector_Valor_P_Max(4) * 1.5
                                            Vector_Valor_P_Max(5) = Vector_Valor_P_Max(5) * 1.5
                                            Vector_Valor_P_Max(6) = Vector_Valor_P_Max(6) * 1.5
                                            Vector_Valor_P_Max(7) = Vector_Valor_P_Max(7) * 1.5
                                            Vector_Valor_P_Max(8) = Vector_Valor_P_Max(8) * 1.5
                                            Vector_Valor_P_Max(9) = Vector_Valor_P_Max(9) * 1.5
                                            Valor_Promedio_P_Max = Valor_Promedio_P_Max * 1.5
                                            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                                        Else
                                            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                                        End If
                                    End If
                                Else
                                    Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                                    Bandera_Desnivel_Detectado = 1
                                End If
                            Else
                                Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                                Bandera_Desnivel_Detectado = 1
                            End If
                        Else
                            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                            Bandera_Desnivel_Detectado = 1
                        End If
                        If Bandera_Desnivel_Detectado = 1 Then
                            Bandera_Desnivel_Detectado = 0
                            'Puntero = Puntero + Math.Floor(Frecuencia * Demora_Despues_QRS)
                            'Index = Index + Math.Floor(Frecuencia * Demora_Despues_QRS)

                            If Puntero_S = Puntero Then
                                Index = Index + Math.Floor(Frecuencia * Demora_Despues_QRS)
                                Puntero = Puntero + Math.Floor(Frecuencia * Demora_Despues_QRS)
                                Puntero_S = Puntero
                            Else
                                Index = Index + Puntero_S - Puntero
                                Puntero = Puntero_S
                            End If
                        Else
                            Puntero_Ultimo_J = Puntero_J
                            Index = Index + Math.Floor(Frecuencia * Demora_Despues_QRS)
                            Puntero = Puntero + Math.Floor(Frecuencia * Demora_Despues_QRS)
                        End If
                        If Puntero > 9136 Then
                            Dim prueba = 5
                        End If
                        'Validar si se puede reliasr mas busquedas de complejos QRS 
                        If Index > Cantidad_Leidos - 2 Then
                            Error_QRS = 1
                        End If
                    Case 1
                        'Error_QRS = 0
                        Index = Cantidad_Leidos
                    Case 2
                        'Error_QRS = 0
                        'Puntero_Cantidad_QRS = Puntero_Cantidad_QRS + 1
                        'Tabla_Datos.Rows.Add(Puntero_Cantidad_QRS, Onda_Q, Onda_Q_0, Onda_R, Onda_R_0, Onda_S, Onda_S_0)
                        'Index = Index + Math.Floor(Frecuencia * Demora_Despues_QRS)
                        'Puntero = Puntero + Math.Floor(Frecuencia * Demora_Despues_QRS)

                        'If Index > Cantidad_Leidos - 2 Then
                        '    Error_QRS = 1
                        'End If
                        Error_QRS = 0
                    Case 3
                        Puntero = Puntero + Math.Floor(Frecuencia * Demora_Despues_QRS)
                        Index = Index + Math.Floor(Frecuencia * Demora_Despues_QRS)
                        Error_QRS = 0
                        Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion
                    Case 4
                        Puntero = Puntero + 1
                        Index = Index + 1
                        Error_QRS = 0
                    Case Else
                End Select
            End While

            If Coneccion_Salida.State = 0 Then
                Coneccion_Salida.Open()
                Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                Tabla_Datos.Clear()
            Else
                Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                Tabla_Datos.Clear()
            End If

            'If Coneccion.State Then
            '    Cmd_Copiar.DestinationTableName = Tabla_Almacenamiento_Resultados
            '    Cmd_Copiar.WriteToServer(Tabla_Datos)
            '    Tabla_Datos.Rows.Clear()
            '    Tabla_Datos.AcceptChanges()
            'Else
            '    Coneccion.Open()
            '    Cmd_Copiar.DestinationTableName = Tabla_Almacenamiento_Resultados
            '    Cmd_Copiar.WriteToServer(Tabla_Datos)
            '    Tabla_Datos.Rows.Clear()
            '    Tabla_Datos.AcceptChanges()
            '    Coneccion.Close()
            'End If


            'Para analisis y salir de la funcion si se emite la orden de cancelar 
            If Progreso.CancellationPending = True Then
                Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
                Datos_Transformada_Wavelet.Clear()
                Datos_Transformada_Wavelet.Dispose()
                Datos_Transformada_Wavelet.AcceptChanges()

                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()

                Return False
            End If

            'Leer nuevos datos
            Bandera_Primera_Lectura_Datos = 0
            If (Cantidad_Leidos >= Cantida_Datos) Then
                Datos_Transformada_Wavelet.Clear()
                Datos_Transformada_Wavelet.Dispose()
                Datos_Transformada_Wavelet.AcceptChanges()
                Datos_Transformada_Wavelet = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Transformada_Wavelet, Nombre_Columna, Convert.ToString(Puntero - Math.Floor(Frecuencia * Cantida_Datos_Retenidos)), Convert.ToString(Puntero + Cantida_Datos))
                Index = Math.Floor(Frecuencia * Cantida_Datos_Retenidos) - (Puntero - Puntero_Ultimo_J) + Math.Floor(Frecuencia * Demora_Despues_QRS)
                Puntero = Puntero_Ultimo_J + Math.Floor(Frecuencia * Demora_Despues_QRS)
                Cantidad_Leidos = Datos_Transformada_Wavelet.Tables(0).Rows.Count
            Else
                Cantidad_Leidos = Math.Floor(Frecuencia * Cantida_Datos_Retenidos)
            End If

            Progreso.ReportProgress(Procedimiento_Deteccion_QRS * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - 1) / Max_Puntero * 100)
            Error_QRS = 0
        End While
        Datos_Transformada_Wavelet.Clear()
        Datos_Transformada_Wavelet.Dispose()
        Datos_Transformada_Wavelet.AcceptChanges()
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()



        Return True
    End Function

    Public Function Correccion_Puntos_QRS_En_Señal(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Registro As String, Tabla_Complejo_QRS As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Frecuencia As Double, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        'En esta funcion se ulilisa Coneccion_Entrada para obtner las señla en la que se va reliazar la correcion y Coneccion_Salida para consultar las los QRS detectados y guardar los  corregidos QRS
        Dim PorCiento_Comparacion_Busqueda As Double = Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_QRS  'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW entre P_Max_Izquierda y P_Max_Derecha 
        Dim PorCiento_Comparacion_Busqueda_Extremos As Double = Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_Extremos_QRS 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW fuera de lso puntos P_Max_Izquierda y P_Max_Derecha 

        Const Qi = 1 'Punto Qi en el complejo QRS
        Const Q = 2 'Punto Q en el complejo QRS
        Const R = 3 'Punto R en el complejo QRS
        Const S = 4 'Punto S en el complejo QRS
        Const J = 5 'Punto J en el complejo QRS
        Const Tipo_Complejo_QRS = 6 'Tipo de Complejo QRS

        Const Cantida_Datos = 400 'Cantidad Maxima de datos alamcenadades para ser prosesada         Static Reset_Limite_Max_Min As Int32    'Limite de tiempo sin detectar un QRS para resetear  Limite_Max y Limite_Min

        Dim m As Double 'Pendiente de la rectas
        Dim Datos_Tabla_Registro As DataSet
        Dim Datos_Tabla_Complejo_QRS As DataSet
        Dim Max_Puntero As Int64 = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Salida, Tabla_Complejo_QRS)


        Dim Puntero As Int64 = 1
        Dim Puntero_Qi As Int64
        Dim Puntero_Q As Int64
        Dim Puntero_R As Int64
        Dim Puntero_S As Int64
        Dim Puntero_J As Int64
        Dim Puntero_Complejo_QRS As Int64 = 0
        Dim Puntero_Base As Int64
        Dim Index_Tabla_Complejo_QRS As Int64
        Dim Index As Int64
        Dim Index_Inicio_Intervalo_Busqueda As Int64
        Dim Index_Fin_Intervalo_Busqueda As Int64

        Dim Cantidad_Leidos_Tabla_QRS As Int64
        Dim Valor_Temp As Double
        Dim Valor_Comparacion_Temp As Double

        '------------------------------------------------
        'Creacion de Tabla de almacenamiento
        '------------------------------------------------
        Class_Funciones_Base_Datos.Registros_Crear_Tabla_QRS(Coneccion_Salida, Tabla_Almacenamiento_Resultados)

        '------------------------------------------------

        If Max_Puntero > 1 Then

            If Progreso.CancellationPending = True Then

                Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)

                Return False
            End If
            Progreso.ReportProgress(Procedimiento_Correcion_Puntos_Complejo_QRS * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero_Complejo_QRS / Max_Puntero * 100)

            '------------------------------------------------
            'Creacion de Tabla de almacenamiento Temporal
            '------------------------------------------------
            Dim Tabla_Datos As New DataTable()
            Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
            Tabla_Datos.Columns.Add(New DataColumn("Q_i", GetType(System.Int32)))
            Tabla_Datos.Columns.Add(New DataColumn("Q", GetType(System.Int32)))
            Tabla_Datos.Columns.Add(New DataColumn("R", GetType(System.Int32)))
            Tabla_Datos.Columns.Add(New DataColumn("S", GetType(System.Int32)))
            Tabla_Datos.Columns.Add(New DataColumn("J", GetType(System.Int32)))
            Tabla_Datos.Columns.Add(New DataColumn("Tipo_QRS", GetType(System.Int32)))

            '------------------------------------------------
            'Analisis de deteccion de los puntos
            '------------------------------------------------
            Datos_Tabla_Complejo_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Salida, Tabla_Complejo_QRS, "Q_i, Q, R, S, J,Tipo_QRS", Convert.ToString(Puntero_Complejo_QRS), Convert.ToString(Puntero_Complejo_QRS + Cantida_Datos))
            Cantidad_Leidos_Tabla_QRS = Datos_Tabla_Complejo_QRS.Tables(0).Rows.Count

            If Cantidad_Leidos_Tabla_QRS > 0 Then
                Puntero_Base = Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(Qi)
            End If

            If Cantidad_Leidos_Tabla_QRS > 0 Then
                Datos_Tabla_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Registro, Nombre_Columna, Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(Qi)), Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows.Count - 1)(J)))
            End If

            Puntero_Complejo_QRS = Cantidad_Leidos_Tabla_QRS

            While Cantidad_Leidos_Tabla_QRS > 0
                Index_Tabla_Complejo_QRS = 0

                While (Cantidad_Leidos_Tabla_QRS) > Index_Tabla_Complejo_QRS

                    'Obtengo el intervalo de busqueda para rectificar el punto R 
                    If Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) <> Tipos_QRS.Sin_QRS And Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) <> Tipos_QRS.QS_0 Then
                        Index_Fin_Intervalo_Busqueda = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S) - Puntero_Base
                        Index_Inicio_Intervalo_Busqueda = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi) - Puntero_Base
                        Index = Index_Inicio_Intervalo_Busqueda

                        Puntero_R = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R)
                        Valor_Temp = -99999999

                        While Index < Index_Fin_Intervalo_Busqueda
                            Index = Index + 1
                            If Datos_Tabla_Registro.Tables(0).Rows(Index)(1) > Valor_Temp Then
                                Valor_Temp = Datos_Tabla_Registro.Tables(0).Rows(Index)(1)
                                Puntero_R = Puntero_Base + Index
                            End If

                        End While

                    Else
                        Puntero_R = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R)
                    End If

                    'Obtengo el intervalo de busqueda para rectificar el punto Q 
                    If Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) <> Tipos_QRS.Sin_QRS And Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) <> Tipos_QRS.QS_0 Then
                        Index_Fin_Intervalo_Busqueda = Puntero_R - Puntero_Base
                        Index_Inicio_Intervalo_Busqueda = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi) - Puntero_Base
                        Puntero_Q = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q)

                        If Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.Qr_0 Or Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.qR_1 Or Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.Qrs_0 Or Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.qRs_1 Or Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.Qr_E_0 Or Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.Qrs_E_0 Or Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.qRs_E_1 Then

                            Valor_Temp = 99999999
                            Index = Index_Inicio_Intervalo_Busqueda

                            While Index < Index_Fin_Intervalo_Busqueda
                                Index = Index + 1
                                If Datos_Tabla_Registro.Tables(0).Rows(Index)(1) < Valor_Temp Then
                                    Valor_Temp = Datos_Tabla_Registro.Tables(0).Rows(Index)(1)
                                    Puntero_Q = Puntero_Base + Index
                                End If

                            End While
                        Else
                            Index = Index_Fin_Intervalo_Busqueda - 1
                            'Dezplazarse asta que el la diferencia entre R y Q_i se menor a al 40%
                            'Valor_Comparacion_Temp = Datos_Tabla_Registro.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q) - Puntero_Base)(1) + 0.35 * (Datos_Tabla_Registro.Tables(0).Rows(Puntero_R - Puntero_Base)(1) - Datos_Tabla_Registro.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q) - Puntero_Base)(1))
                            Valor_Comparacion_Temp = Datos_Tabla_Registro.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q) - Puntero_Base)(1) + PorCiento_Comparacion_Busqueda_Extremos * (Datos_Tabla_Registro.Tables(0).Rows(Puntero_R - Puntero_Base)(1) - Datos_Tabla_Registro.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q) - Puntero_Base)(1))
                            While Index > Index_Inicio_Intervalo_Busqueda And Valor_Comparacion_Temp < Datos_Tabla_Registro.Tables(0).Rows(Index)(1)
                                Index = Index - 1
                            End While

                            'Dezplazarse asta que la pendiente sea negativo 
                            m = Frecuencia * (Datos_Tabla_Registro.Tables(0).Rows(Index + 1)(1) - Datos_Tabla_Registro.Tables(0).Rows(Index)(1))
                            While m > 0 And Index > Index_Inicio_Intervalo_Busqueda
                                Index = Index - 1
                                m = Frecuencia * (Datos_Tabla_Registro.Tables(0).Rows(Index + 1)(1) - Datos_Tabla_Registro.Tables(0).Rows(Index)(1))
                            End While

                            If Index = Index_Fin_Intervalo_Busqueda - 1 Then
                                Puntero_Q = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q)
                            ElseIf m < 0 Then
                                Puntero_Q = Puntero_Base + Index + 1
                            Else
                                Puntero_Q = Puntero_Base + Index
                            End If

                        End If

                    Else
                        Puntero_Q = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q)
                    End If

                    'Obtengo el intervalo de busqueda para rectificar el punto Q_i 
                    If Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) <> Tipos_QRS.Sin_QRS And Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) <> Tipos_QRS.QS_0 Then
                        Index_Fin_Intervalo_Busqueda = Puntero_Q - Puntero_Base
                        Index_Inicio_Intervalo_Busqueda = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi) - Puntero_Base

                        If Index_Inicio_Intervalo_Busqueda < Index_Fin_Intervalo_Busqueda Then

                            Index = Index_Fin_Intervalo_Busqueda
                            'Dezplazarse asta que el la diferencia entre Q_i y Q se menor a al 40%
                            Valor_Comparacion_Temp = Datos_Tabla_Registro.Tables(0).Rows(Puntero_Q - Puntero_Base)(1) + 0.65 * (Datos_Tabla_Registro.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi) - Puntero_Base)(1) - Datos_Tabla_Registro.Tables(0).Rows(Puntero_Q - Puntero_Base)(1))
                            While Index > Index_Inicio_Intervalo_Busqueda And Valor_Comparacion_Temp > Datos_Tabla_Registro.Tables(0).Rows(Index)(1)
                                Index = Index - 1
                            End While
                            If Index = Index_Fin_Intervalo_Busqueda And Index > 0 Then
                                Index = Index - 1
                            End If
                            'Dezplazarse asta que la pendiente sea negativo 
                            m = Frecuencia * (Datos_Tabla_Registro.Tables(0).Rows(Index + 1)(1) - Datos_Tabla_Registro.Tables(0).Rows(Index)(1))
                            While m < -1 And Index > Index_Inicio_Intervalo_Busqueda
                                Index = Index - 1
                                m = Frecuencia * (Datos_Tabla_Registro.Tables(0).Rows(Index + 1)(1) - Datos_Tabla_Registro.Tables(0).Rows(Index)(1))
                            End While

                            If m > 0 Then
                                Puntero_Qi = Puntero_Base + Index + 1
                            Else
                                Puntero_Qi = Puntero_Base + Index
                            End If
                        Else
                            Puntero_Qi = Puntero_Q
                        End If

                    Else
                        Puntero_Qi = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi)
                    End If


                    'Obtengo el intervalo de busqueda para rectificar el punto S
                    If Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) <> Tipos_QRS.Sin_QRS And Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) <> Tipos_QRS.QS_0 Then
                        Index_Fin_Intervalo_Busqueda = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J) - Puntero_Base
                        Index_Inicio_Intervalo_Busqueda = Puntero_R - Puntero_Base
                        Puntero_S = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S)

                        If Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.Qrs_0 Or Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.qRs_1 Or Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.Rs_0 Or Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.Qrs_E_0 Or Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.qRs_E_1 Or Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) = Tipos_QRS.RS_E_0 Then

                            Index = Index_Inicio_Intervalo_Busqueda

                            Valor_Temp = 99999999

                            While Index < Index_Fin_Intervalo_Busqueda
                                Index = Index + 1
                                If Datos_Tabla_Registro.Tables(0).Rows(Index)(1) < Valor_Temp Then
                                    Valor_Temp = Datos_Tabla_Registro.Tables(0).Rows(Index)(1)
                                    Puntero_S = Puntero_Base + Index
                                End If

                            End While
                        Else

                            Index = Index_Inicio_Intervalo_Busqueda
                            'Dezplazarse asta que el la diferencia entre R y Q_i se menor a al 40%
                            Dim prueba1 = Datos_Tabla_Registro.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S) - Puntero_Base)(1)
                            Valor_Comparacion_Temp = Datos_Tabla_Registro.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S) - Puntero_Base)(1) + PorCiento_Comparacion_Busqueda_Extremos * (Datos_Tabla_Registro.Tables(0).Rows(Puntero_R - Puntero_Base)(1) - Datos_Tabla_Registro.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S) - Puntero_Base)(1))
                            While Index < Index_Fin_Intervalo_Busqueda And Valor_Comparacion_Temp < Datos_Tabla_Registro.Tables(0).Rows(Index)(1)
                                Index = Index + 1
                                Dim prueba As Double = Datos_Tabla_Registro.Tables(0).Rows(Index)(1)
                            End While

                            'Dezplazarse asta que la pendiente sea negativo 
                            m = Frecuencia * (Datos_Tabla_Registro.Tables(0).Rows(Index)(1) - Datos_Tabla_Registro.Tables(0).Rows(Index - 1)(1))
                            While m < 0 And Index < Index_Fin_Intervalo_Busqueda
                                Index = Index + 1
                                m = Frecuencia * (Datos_Tabla_Registro.Tables(0).Rows(Index)(1) - Datos_Tabla_Registro.Tables(0).Rows(Index - 1)(1))
                            End While


                            If Index = Index_Inicio_Intervalo_Busqueda Then
                                Puntero_S = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S)
                            ElseIf m > 0 Then
                                Puntero_S = Puntero_Base + Index - 1
                            Else
                                Puntero_S = Puntero_Base + Index
                            End If
                        End If
                    Else
                        Puntero_S = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S)
                    End If

                    'Obtengo el intervalo de busqueda para rectificar el punto J
                    If Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) <> Tipos_QRS.Sin_QRS And Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS) <> Tipos_QRS.QS_0 Then
                        Index_Fin_Intervalo_Busqueda = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J) - Puntero_Base
                        Index_Inicio_Intervalo_Busqueda = Puntero_S - Puntero_Base
                        If Index_Fin_Intervalo_Busqueda > Index_Inicio_Intervalo_Busqueda Then
                            Index = Index_Inicio_Intervalo_Busqueda
                            'Dezplazarse asta que el la diferencia entre R y Q_i se menor a al 40%
                            Valor_Comparacion_Temp = Datos_Tabla_Registro.Tables(0).Rows(Puntero_S - Puntero_Base)(1) + 0.65 * (Datos_Tabla_Registro.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J) - Puntero_Base)(1) - Datos_Tabla_Registro.Tables(0).Rows(Puntero_S - Puntero_Base)(1))
                            While Index < Index_Fin_Intervalo_Busqueda And Valor_Comparacion_Temp > Datos_Tabla_Registro.Tables(0).Rows(Index)(1)
                                Index = Index + 1
                            End While
                            If Index = Index_Inicio_Intervalo_Busqueda And Index < Index_Fin_Intervalo_Busqueda Then
                                Index = Index + 1
                            End If

                            'Dezplazarse asta que la pendiente sea negativo 
                            m = Frecuencia * (Datos_Tabla_Registro.Tables(0).Rows(Index)(1) - Datos_Tabla_Registro.Tables(0).Rows(Index - 1)(1))
                            While m > 1 And Index < Index_Fin_Intervalo_Busqueda
                                Index = Index + 1
                                m = Frecuencia * (Datos_Tabla_Registro.Tables(0).Rows(Index)(1) - Datos_Tabla_Registro.Tables(0).Rows(Index - 1)(1))
                            End While

                            If m < 0 Then
                                Puntero_J = Puntero_Base + Index - 1
                            Else
                                Puntero_J = Puntero_Base + Index
                            End If
                        Else
                            Puntero_J = Puntero_S
                        End If
                    Else
                        Puntero_J = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J)
                    End If

                    Tabla_Datos.Rows.Add(Puntero, Puntero_Qi, Puntero_Q, Puntero_R, Puntero_S, Puntero_J, Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS))
                    Puntero = Puntero + 1
                    Index_Tabla_Complejo_QRS = Index_Tabla_Complejo_QRS + 1
                    If Puntero = 512 Then
                        Dim prueba = 0
                    End If

                End While
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If


                'If Coneccion.State = 0 Then
                '    Coneccion.Open()
                '    Cmd_Copiar.DestinationTableName = Tabla_Almacenamiento_Resultados
                '    Cmd_Copiar.WriteToServer(Tabla_Datos)
                '    Tabla_Datos.Clear()
                '    Tabla_Datos.AcceptChanges()
                '    Coneccion.Close()
                'Else
                '    Cmd_Copiar.DestinationTableName = Tabla_Almacenamiento_Resultados
                '    Cmd_Copiar.WriteToServer(Tabla_Datos)
                '    Tabla_Datos.Clear()
                '    Tabla_Datos.AcceptChanges()
                'End If

                Datos_Tabla_Complejo_QRS.Clear()
                Datos_Tabla_Complejo_QRS.Dispose()
                Datos_Tabla_Complejo_QRS.AcceptChanges()
                Datos_Tabla_Complejo_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Salida, Tabla_Complejo_QRS, "Q_i, Q, R, S, J,Tipo_QRS", Convert.ToString(Puntero_Complejo_QRS + 1), Convert.ToString(Puntero_Complejo_QRS + Cantida_Datos))
                Cantidad_Leidos_Tabla_QRS = Datos_Tabla_Complejo_QRS.Tables(0).Rows.Count
                If Cantidad_Leidos_Tabla_QRS > 0 Then
                    Datos_Tabla_Registro.Clear()
                    Datos_Tabla_Registro.Dispose()
                    Datos_Tabla_Registro.AcceptChanges()
                    Datos_Tabla_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Registro, Nombre_Columna, Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(Qi)), Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows.Count - 1)(J)))
                    Puntero_Base = Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(Qi)
                End If
                Puntero_Complejo_QRS = Puntero_Complejo_QRS + Cantidad_Leidos_Tabla_QRS
                'Analisis par los casos cuando Q o S0 san igual a -1 

                If Progreso.CancellationPending = True Then
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)

                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Datos_Tabla_Complejo_QRS.Clear()
                    Datos_Tabla_Complejo_QRS.Dispose()
                    Datos_Tabla_Complejo_QRS.AcceptChanges()

                    Datos_Tabla_Registro.Clear()
                    Datos_Tabla_Registro.Dispose()
                    Datos_Tabla_Registro.AcceptChanges()

                    Return False
                End If
                Progreso.ReportProgress(Procedimiento_Correcion_Puntos_Complejo_QRS * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero_Complejo_QRS / Max_Puntero * 100)

            End While

            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()

            Datos_Tabla_Complejo_QRS.Clear()
            Datos_Tabla_Complejo_QRS.Dispose()
            Datos_Tabla_Complejo_QRS.AcceptChanges()

            Datos_Tabla_Registro.Clear()
            Datos_Tabla_Registro.Dispose()
            Datos_Tabla_Registro.AcceptChanges()
        End If

        Return True

    End Function
    Public Function Busqueda_Complejos_QRS_NO_Detectados_En_Transformada_Wavelet(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Transformada_Wavelet As String, Tabla_Complejo_QRS As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, Frecuencia As Double, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        'En esta funcion se ulilisa Coneccion_Entrada para obtner las trasnfomras wavele y Coneccion_Salida para consultar las los QRS detectados y guardar los  nuevos QRS


        Dim m_Comparacion_Wavelet As Double = Configuracion_Deteccion_QRS.m_Comparacion_Wavelet_QRS 'tang 45°=1 Pendiente de comparacion Para deterla busqueda de punos significativos  
        'Const PorCiento_Comparacion_Busqueda = 0.15 'Detarmian el margen minimo para un cambio de estado entre P_I_min y P_D_min  
        Dim PorCiento_Comparacion_Busqueda As Double = Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_QRS 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW entre P_Max_Izquierda y P_Max_Derecha 
        Dim PorCiento_Comparacion_Busqueda_Extremos As Double = Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_Extremos_QRS 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW fuera de lso puntos P_Max_Izquierda y P_Max_Derecha 
        Dim Margen_Separacion_QRS_Ruido As Double = Configuracion_Deteccion_QRS.Margen_Separacion_QRS_Ruido 'Establece el limite de cuanto pude crecer la amplitud de P_Max_Central con respecto a Valor_Promedio_P_Max sin considerarse ruido 
        Dim Margen_Separacion_Desniveles As Double = Configuracion_Deteccion_QRS.Margen_Separacion_Desniveles 'Establece  la relacion minima entre P_Max_Central y uno de los minimos para direnciar los cambios de nivel en la señal y un QRS
        Dim Duracion_Maxima_QRS As Double = Configuracion_Deteccion_QRS.Duracion_Maxima_QRS  'Duracion Maxima que puede tener un QRS
        Dim Duracion_Minima_QRS As Double = Configuracion_Deteccion_QRS.Duracion_Minima_QRS 'Duracion Minima que puede tener un QRS
        Dim Separacion_Minima_QRS As Double = Configuracion_Deteccion_QRS.Separacion_Minima_QRS 'En segundos =200ms Separacion minima de debe existir entre dos QRS consecutivos de 200 ms 


        Const PorCiento_Comparacion_P_min = 0.65 'Margen de comparacion contra el Valor_Promedio_P_Max cuando en el intervalo de busqueda  esta entre 480 ms y 2000 ms
        Const PorCiento_Comparacion_P_max = 0.5 'Margen de comparacion contra el Valor_Promedio_P_Max cuando en el intervalo de busqueda  esta entre 480 ms y 2000 ms
        Const PorCiento_Comparacion_P_max_2s = 0.25 'Margen de comparacion contra el Valor_Promedio_P_Max cuando en el intervalo de busqueda supera los 2 s
        Const Limite_Repeticion_PorCiento_Comparacion_P_max_2s = 3 'Margen de comparacion contra el Valor_Promedio_P_Max cuando en el intervalo de busqueda supera los 2 s

        Dim Cont_Limite_Repeticion_PorCiento_Comparacion_P_max_2s As Int16

        Dim Tipo_QRS As Tipos_QRS

        Dim Bandera_Cambio_Lobulo_Central_a_Derecho As Double
        Dim Bandera_Desnivel_Detectado As Double
        Dim Bandera_Muesca_Detectada As Double
        Const Qi = 1 'Punto Qi en el complejo QRS
        Const Q = 2 'Punto Q en el complejo QRS
        Const R = 3 'Punto R en el complejo QRS
        Const S = 4 'Punto S en el complejo QRS
        Const J = 5 'Punto J en el complejo QRS
        Const Tipo_Complejo_QRS = 6 'Tipo de Complejo QRS

        Const Cantida_Datos = 400 'Cantidad Maxima de datos alamcenadades para ser prosesada         Static Reset_Limite_Max_Min As Int32    'Limite de tiempo sin detectar un QRS para resetear  Limite_Max y Limite_Min

        Dim m As Double 'Pendiente de la rectas

        Dim Datos_Tabla_Complejo_QRS As DataSet
        Dim Datos_Transformada_Wavelet As DataSet
        Dim Max_Puntero As Int64 = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Salida, Tabla_Complejo_QRS)
        If Max_Puntero > 1 Then
            Dim Valor_P_Max As Double
            Dim Valor_Promedio_P_Max As Double = 0
            Dim Vector_Valor_P_Max() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

            Dim Valor_P_Min As Double
            Dim Valor_Promedio_P_Min As Double = 0
            Dim Vector_Valor_P_Min() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

            Dim Segmentos_RR As Int64() = {3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia, 3 * Frecuencia}
            Dim Segmentos_RR_Promedio As Int64 = 0 'Almacena 1.5 del promedio de los ulimos 10 segmentos RR 


            Dim Puntero As Int64 = 1
            Dim P_Max_Central As Double
            Dim P_Max_Izquierda As Double
            Dim P_Max_Derecha As Double
            Dim P_Min_Izquierda As Double
            Dim P_Min_Izquierda_Temp As Double
            Dim P_Min_Derecha As Double
            Dim P_Min_Derecha_Temp As Double
            Dim P_Min_Derecha_1 As Double

            Dim Puntero_P_Max_Central As Double = 0
            Dim Puntero_P_Max_Izquierda As Double = 0
            Dim Puntero_P_Max_Derecha As Double = 0
            Dim Puntero_P_Min_Izquierda As Double = 0
            Dim Puntero_P_Min_Derecha As Double = 0
            Dim Puntero_P_Min_Derecha_1 As Double = 0
            Dim P_Min_Comparacion As Double = 0

            Dim Puntero_Q_i As Double = 0
            Dim Puntero_Q As Double = 0
            Dim Puntero_R As Double = 0
            Dim Puntero_S As Double = 0
            Dim Puntero_J As Double = 0
            Dim Puntero_S1 As Double = 0
            Dim Puntero_S2 As Double = 0
            Dim Puntero_S3 As Double = 0
            Dim Puntero_Ultimo_J As Double = 0

            Dim Puntero_Complejo_QRS As Int64 = 0
            Dim Puntero_Base As Int64
            Dim Index_Tabla_Complejo_QRS As Int64
            Dim Index As Int64

            Dim Index_Temp, Index_Temp_1, Index_Temp_2 As Int64
            Dim Index_Inicio_Intervalo_Busqueda_temp As Int64
            Dim Index_Fin_Intervalo_Busqueda_temp As Int64
            Dim Index_Inicio_Intervalo_Busqueda_Entre_QRS As Int64
            Dim Index_Fin_Intervalo_Busqueda_Entre_QRS As Int64
            Dim Index_Cambio_Nivel As Double = 0
            Dim Error_QRS As Int64 = 0
            'Error_QRS=0 no hay erroes 
            'Error_QRS=1 Index > Cantidad_Leidos Hay que leer nuevos datos
            'Error_QRS=2 Se superaron los tiempos posible de un QRS
            'Error_QRS=3 Index <0 no se puede retroceder mas en el vector de busqueda
            'Error_QRS=4 no se detecto P_Max_Central
            'Error_QRS=5 Hay que cargar nuevos QRS

            Dim Cantidad_Leidos_Tabla_QRS As Int64
            '------------------------------------------------
            'Creacion de Tabla de almacenamiento
            '------------------------------------------------
            Class_Funciones_Base_Datos.Registros_Crear_Tabla_QRS(Coneccion_Salida, Tabla_Almacenamiento_Resultados)

            If Max_Puntero > 1 Then

                If PorCiento_Comparacion_Busqueda_Extremos < 1 Then
                    If PorCiento_Comparacion_Busqueda_Extremos > 0.8 And PorCiento_Comparacion_Busqueda_Extremos < 1 Then
                        PorCiento_Comparacion_Busqueda_Extremos = 0.8
                    ElseIf PorCiento_Comparacion_Busqueda_Extremos < 0.8 Then
                        PorCiento_Comparacion_Busqueda_Extremos = PorCiento_Comparacion_Busqueda_Extremos / 100
                    Else
                        PorCiento_Comparacion_Busqueda_Extremos = 0.8
                    End If
                Else
                    If PorCiento_Comparacion_Busqueda_Extremos > 80 And PorCiento_Comparacion_Busqueda_Extremos < 100 Then
                        PorCiento_Comparacion_Busqueda_Extremos = 0.8
                    ElseIf PorCiento_Comparacion_Busqueda_Extremos < 80 Then
                        PorCiento_Comparacion_Busqueda_Extremos = PorCiento_Comparacion_Busqueda_Extremos / 100
                    Else
                        PorCiento_Comparacion_Busqueda_Extremos = 0.8
                    End If
                End If

                If Progreso.CancellationPending = True Then

                    'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)

                    Return False
                End If

                Progreso.ReportProgress(Procedimiento_Busqueda_Complejo_QRS_No_Detectados * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero_Complejo_QRS / Max_Puntero * 100)
                '------------------------------------------------
                'Creacion de Tabla de almacenamiento Temporal
                '------------------------------------------------

                Dim Tabla_Datos As New DataTable()
                Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
                Tabla_Datos.Columns.Add(New DataColumn("Q_i", GetType(System.Int32)))
                Tabla_Datos.Columns.Add(New DataColumn("Q", GetType(System.Int32)))
                Tabla_Datos.Columns.Add(New DataColumn("R", GetType(System.Int32)))
                Tabla_Datos.Columns.Add(New DataColumn("S", GetType(System.Int32)))
                Tabla_Datos.Columns.Add(New DataColumn("J", GetType(System.Int32)))
                Tabla_Datos.Columns.Add(New DataColumn("Tipo_QRS", GetType(System.Int32)))

                '------------------------------------------------
                'Obtencion del valor maximo promedio 
                '------------------------------------------------
                Datos_Tabla_Complejo_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Salida, Tabla_Complejo_QRS, "Q_i, J", Convert.ToString(2), Convert.ToString(11))
                Index = 0
                While Index_Tabla_Complejo_QRS <= Datos_Tabla_Complejo_QRS.Tables(0).Rows.Count - 1
                    Valor_P_Max = Class_Funciones_Base_Datos.Registro_Maximo_Valor(Coneccion_Entrada, Tabla_Transformada_Wavelet, Nombre_Columna, Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(1)), Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(2)))
                    If (Valor_P_Max > 0) Then
                        Valor_Promedio_P_Max = Valor_Promedio_P_Max + Valor_P_Max
                        Vector_Valor_P_Max(Index) = Valor_P_Max
                        Index = Index + 1
                    End If
                    Index_Tabla_Complejo_QRS = Index_Tabla_Complejo_QRS + 1
                End While
                Valor_Promedio_P_Max = Valor_Promedio_P_Max / Index
                Valor_P_Max = 0.5 * Valor_Promedio_P_Max
                For i = Index To 9
                    Vector_Valor_P_Max(Index) = Valor_Promedio_P_Max
                Next
                '------------------------------------------------
                'Obtencion del valor minimo promedio 
                '------------------------------------------------
                Datos_Tabla_Complejo_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Salida, Tabla_Complejo_QRS, "Q_i, J", Convert.ToString(2), Convert.ToString(11))
                Index = 0
                Index_Tabla_Complejo_QRS = 0
                While Index_Tabla_Complejo_QRS <= Datos_Tabla_Complejo_QRS.Tables(0).Rows.Count - 1

                    Valor_P_Min = Class_Funciones_Base_Datos.Registro_Minimo_Valor(Coneccion_Entrada, Tabla_Transformada_Wavelet, Nombre_Columna, Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(1)), Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(2)))
                    If (Valor_P_Min < 0) Then
                        Valor_Promedio_P_Min = Valor_Promedio_P_Min + Valor_P_Min
                        Vector_Valor_P_Min(Index) = Valor_P_Min
                        Index = Index + 1
                    End If
                    Index_Tabla_Complejo_QRS = Index_Tabla_Complejo_QRS + 1
                End While
                Valor_Promedio_P_Min = Valor_Promedio_P_Min / Index
                Valor_P_Min = 0.5 * Valor_Promedio_P_Min
                For i = Index To 9
                    Vector_Valor_P_Min(Index) = Valor_Promedio_P_Min
                Next
                '------------------------------------------------
                'Cargar los datos de analisis 
                Datos_Tabla_Complejo_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Salida, Tabla_Complejo_QRS, "Q_i, Q, R, S, J,Tipo_QRS", Convert.ToString(Puntero_Complejo_QRS), Convert.ToString(Puntero_Complejo_QRS + Cantida_Datos))
                Cantidad_Leidos_Tabla_QRS = Datos_Tabla_Complejo_QRS.Tables(0).Rows.Count
                If Cantidad_Leidos_Tabla_QRS > 0 Then
                    Datos_Transformada_Wavelet = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Transformada_Wavelet, Nombre_Columna, Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(Qi)), Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows.Count - 1)(J)))
                    Puntero_Base = Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(1)
                    'Obtencion del los 10 primeros intervalos RR
                    Index_Tabla_Complejo_QRS = 10
                    While Index_Tabla_Complejo_QRS <= 1 And Index_Tabla_Complejo_QRS <= Datos_Tabla_Complejo_QRS.Tables(0).Rows.Count - 1
                        Segmentos_RR(Index_Tabla_Complejo_QRS - 1) = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(R)
                        If Segmentos_RR(Index_Tabla_Complejo_QRS - 1) > 2 * Frecuencia Then
                            Segmentos_RR(Index_Tabla_Complejo_QRS - 1) = 2 * Frecuencia
                        ElseIf Segmentos_RR(9) < 0.24 * Frecuencia Then
                            Segmentos_RR(Index_Tabla_Complejo_QRS - 1) = 0.24 * Frecuencia
                        End If
                        Index_Tabla_Complejo_QRS = Index_Tabla_Complejo_QRS - 1
                    End While
                    Segmentos_RR_Promedio = (Segmentos_RR(0) + Segmentos_RR(1) + Segmentos_RR(2) + Segmentos_RR(3) + Segmentos_RR(4) + Segmentos_RR(5) + Segmentos_RR(6) + Segmentos_RR(7) + Segmentos_RR(8) + Segmentos_RR(9)) / Index_Tabla_Complejo_QRS
                    'Si se tienen menos de 10 intervalos RR se completan los los que falten con Segmentos_RR_Promedio
                    For i = Segmentos_RR_Promedio - 1 To 0 Step -1
                        Segmentos_RR(Index_Tabla_Complejo_QRS - 1) = Segmentos_RR_Promedio
                    Next
                End If
                Puntero_Complejo_QRS = Cantidad_Leidos_Tabla_QRS
                '------------------------------------------------
                'Analisis de deteccion de los puntos
                '------------------------------------------------
                If Cantidad_Leidos_Tabla_QRS > 1 Then
                    Tabla_Datos.Rows.Add(Puntero, Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(Qi), Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(Q), Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(R), Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(S), Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(J), Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(Tipo_Complejo_QRS))
                    Puntero_Ultimo_J = Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(J)
                    Puntero = Puntero + 1

                End If
                While Cantidad_Leidos_Tabla_QRS > 1
                    Index_Tabla_Complejo_QRS = 1
                    'Tabla_Datos.Rows.Add(Puntero, Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(Qi), Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(Q), Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(R), Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(S), Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(J), Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(Tipo_Complejo_QRS))
                    'Puntero = Puntero + 1
                    Error_QRS = 0
                    While Error_QRS <> 5
                        Error_QRS = 0
                        If Puntero = 179 Then
                            Dim a As Double = 0
                        End If
                        '------------------------------------------------
                        'Descartar los segmentos de Busqueda cuando el intervalo RR sea menor a 480 ms
                        '------------------------------------------------
                        'Tabla_Datos.Rows.Add(Puntero, Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS))
                        While (Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(R)) / Frecuencia < 2 * Separacion_Minima_QRS And Index_Tabla_Complejo_QRS < Cantidad_Leidos_Tabla_QRS And Error_QRS = 0
                            'Obtencio de Valor_P_Max 
                            Index = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi) - Puntero_Base
                            Valor_P_Max = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                            For Index_P_Max = 0 To Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi)
                                If Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Max)(1) > Valor_P_Max Then
                                    Valor_P_Max = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Max)(1)
                                End If
                            Next
                            Vector_Valor_P_Max(0) = Vector_Valor_P_Max(1)
                            Vector_Valor_P_Max(1) = Vector_Valor_P_Max(2)
                            Vector_Valor_P_Max(2) = Vector_Valor_P_Max(3)
                            Vector_Valor_P_Max(3) = Vector_Valor_P_Max(4)
                            Vector_Valor_P_Max(4) = Vector_Valor_P_Max(5)
                            Vector_Valor_P_Max(5) = Vector_Valor_P_Max(6)
                            Vector_Valor_P_Max(6) = Vector_Valor_P_Max(7)
                            Vector_Valor_P_Max(7) = Vector_Valor_P_Max(8)
                            Vector_Valor_P_Max(8) = Vector_Valor_P_Max(9)
                            Vector_Valor_P_Max(9) = Valor_P_Max
                            Valor_Promedio_P_Max = (Vector_Valor_P_Max(0) + Vector_Valor_P_Max(1) + Vector_Valor_P_Max(2) + Vector_Valor_P_Max(3) + Vector_Valor_P_Max(4) + Vector_Valor_P_Max(5) + Vector_Valor_P_Max(6) + Vector_Valor_P_Max(7) + Vector_Valor_P_Max(8) + Vector_Valor_P_Max(9)) / 10
                            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion_P_max


                            'Obtencio de Valor_P_Min 
                            Index = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi) - Puntero_Base
                            Valor_P_Min = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                            For Index_P_Min = 0 To Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi)
                                If Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Min)(1) < Valor_P_Min Then
                                    Valor_P_Min = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Min)(1)
                                End If
                            Next
                            Vector_Valor_P_Min(0) = Vector_Valor_P_Min(1)
                            Vector_Valor_P_Min(1) = Vector_Valor_P_Min(2)
                            Vector_Valor_P_Min(2) = Vector_Valor_P_Min(3)
                            Vector_Valor_P_Min(3) = Vector_Valor_P_Min(4)
                            Vector_Valor_P_Min(4) = Vector_Valor_P_Min(5)
                            Vector_Valor_P_Min(5) = Vector_Valor_P_Min(6)
                            Vector_Valor_P_Min(6) = Vector_Valor_P_Min(7)
                            Vector_Valor_P_Min(7) = Vector_Valor_P_Min(8)
                            Vector_Valor_P_Min(8) = Vector_Valor_P_Min(9)
                            Vector_Valor_P_Min(9) = Valor_P_Min
                            Valor_Promedio_P_Min = (Vector_Valor_P_Min(0) + Vector_Valor_P_Min(1) + Vector_Valor_P_Min(2) + Vector_Valor_P_Min(3) + Vector_Valor_P_Min(4) + Vector_Valor_P_Min(5) + Vector_Valor_P_Min(6) + Vector_Valor_P_Min(7) + Vector_Valor_P_Min(8) + Vector_Valor_P_Min(9)) / 10
                            Valor_P_Min = Valor_Promedio_P_Min * PorCiento_Comparacion_P_min


                            If Index_Tabla_Complejo_QRS + 1 < Cantidad_Leidos_Tabla_QRS Then
                                Tabla_Datos.Rows.Add(Puntero, Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS))
                                'Actualizar Segmentos_RR_Promedio 
                                Segmentos_RR(0) = Segmentos_RR(1)
                                Segmentos_RR(1) = Segmentos_RR(2)
                                Segmentos_RR(2) = Segmentos_RR(3)
                                Segmentos_RR(3) = Segmentos_RR(4)
                                Segmentos_RR(4) = Segmentos_RR(5)
                                Segmentos_RR(5) = Segmentos_RR(6)
                                Segmentos_RR(6) = Segmentos_RR(7)
                                Segmentos_RR(7) = Segmentos_RR(8)
                                Segmentos_RR(8) = Segmentos_RR(9)
                                Segmentos_RR(9) = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(R)

                                'Validar que el segmento RR no sea superior a 2s ni inferior a 0.24s
                                If Segmentos_RR(9) > 2 * Frecuencia Then
                                    Segmentos_RR(9) = 2 * Frecuencia
                                ElseIf Segmentos_RR(9) < 0.24 * Frecuencia Then
                                    Segmentos_RR(9) = 0.24 * Frecuencia
                                End If
                                Segmentos_RR_Promedio = (Segmentos_RR(0) + Segmentos_RR(1) + Segmentos_RR(2) + Segmentos_RR(3) + Segmentos_RR(4) + Segmentos_RR(5) + Segmentos_RR(6) + Segmentos_RR(7) + Segmentos_RR(8) + Segmentos_RR(9)) / 10

                                Puntero_Ultimo_J = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J)
                                Index_Tabla_Complejo_QRS = Index_Tabla_Complejo_QRS + 1
                                Puntero = Puntero + 1
                            Else
                                Error_QRS = 5
                            End If
                        End While
                        If (Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(R)) / Frecuencia > 2 * Separacion_Minima_QRS And (Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(R)) / Frecuencia < 2 And Index_Tabla_Complejo_QRS < Cantidad_Leidos_Tabla_QRS And Error_QRS <> 5 Then
                            'Cuando el intervalo RR esta entre los 480 ms y 2000 ms
                            'Obtencio de Valor_P_Max 
                            Index = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi) - Puntero_Base
                            Valor_P_Max = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                            For Index_P_Max = 0 To Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi)
                                If Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Max)(1) > Valor_P_Max Then
                                    Valor_P_Max = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Max)(1)
                                End If
                            Next
                            Vector_Valor_P_Max(0) = Vector_Valor_P_Max(1)
                            Vector_Valor_P_Max(1) = Vector_Valor_P_Max(2)
                            Vector_Valor_P_Max(2) = Vector_Valor_P_Max(3)
                            Vector_Valor_P_Max(3) = Vector_Valor_P_Max(4)
                            Vector_Valor_P_Max(4) = Vector_Valor_P_Max(5)
                            Vector_Valor_P_Max(5) = Vector_Valor_P_Max(6)
                            Vector_Valor_P_Max(6) = Vector_Valor_P_Max(7)
                            Vector_Valor_P_Max(7) = Vector_Valor_P_Max(8)
                            Vector_Valor_P_Max(8) = Vector_Valor_P_Max(9)
                            Vector_Valor_P_Max(9) = Valor_P_Max
                            Valor_Promedio_P_Max = (Vector_Valor_P_Max(0) + Vector_Valor_P_Max(1) + Vector_Valor_P_Max(2) + Vector_Valor_P_Max(3) + Vector_Valor_P_Max(4) + Vector_Valor_P_Max(5) + Vector_Valor_P_Max(6) + Vector_Valor_P_Max(7) + Vector_Valor_P_Max(8) + Vector_Valor_P_Max(9)) / 10
                            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion_P_max

                            'Obtencio de Valor_P_Min 
                            Index = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi) - Puntero_Base
                            Valor_P_Min = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                            For Index_P_Min = 0 To Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi)
                                If Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Min)(1) < Valor_P_Min Then
                                    Valor_P_Min = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Min)(1)
                                End If
                            Next
                            Vector_Valor_P_Min(0) = Vector_Valor_P_Min(1)
                            Vector_Valor_P_Min(1) = Vector_Valor_P_Min(2)
                            Vector_Valor_P_Min(2) = Vector_Valor_P_Min(3)
                            Vector_Valor_P_Min(3) = Vector_Valor_P_Min(4)
                            Vector_Valor_P_Min(4) = Vector_Valor_P_Min(5)
                            Vector_Valor_P_Min(5) = Vector_Valor_P_Min(6)
                            Vector_Valor_P_Min(6) = Vector_Valor_P_Min(7)
                            Vector_Valor_P_Min(7) = Vector_Valor_P_Min(8)
                            Vector_Valor_P_Min(8) = Vector_Valor_P_Min(9)
                            Vector_Valor_P_Min(9) = Valor_P_Min
                            Valor_Promedio_P_Min = (Vector_Valor_P_Min(0) + Vector_Valor_P_Min(1) + Vector_Valor_P_Min(2) + Vector_Valor_P_Min(3) + Vector_Valor_P_Min(4) + Vector_Valor_P_Min(5) + Vector_Valor_P_Min(6) + Vector_Valor_P_Min(7) + Vector_Valor_P_Min(8) + Vector_Valor_P_Min(9)) / 10
                            Valor_P_Min = Valor_Promedio_P_Min * PorCiento_Comparacion_P_min

                        ElseIf (Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(R)) / Frecuencia > 2 And Index_Tabla_Complejo_QRS < Cantidad_Leidos_Tabla_QRS And Error_QRS <> 5 Then
                            'Cuando el intervalo RR es mayor 2000 ms 
                            'Obtencio de Valor_P_Max 
                            Index = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi) - Puntero_Base
                            Valor_P_Max = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                            For Index_P_Max = 0 To Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi)
                                If Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Max)(1) > Valor_P_Max Then
                                    Valor_P_Max = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Max)(1)
                                End If
                            Next
                            Vector_Valor_P_Max(0) = Vector_Valor_P_Max(1)
                            Vector_Valor_P_Max(1) = Vector_Valor_P_Max(2)
                            Vector_Valor_P_Max(2) = Vector_Valor_P_Max(3)
                            Vector_Valor_P_Max(3) = Vector_Valor_P_Max(4)
                            Vector_Valor_P_Max(4) = Vector_Valor_P_Max(5)
                            Vector_Valor_P_Max(5) = Vector_Valor_P_Max(6)
                            Vector_Valor_P_Max(6) = Vector_Valor_P_Max(7)
                            Vector_Valor_P_Max(7) = Vector_Valor_P_Max(8)
                            Vector_Valor_P_Max(8) = Vector_Valor_P_Max(9)
                            Vector_Valor_P_Max(9) = Valor_P_Max
                            Valor_Promedio_P_Max = (Vector_Valor_P_Max(0) + Vector_Valor_P_Max(1) + Vector_Valor_P_Max(2) + Vector_Valor_P_Max(3) + Vector_Valor_P_Max(4) + Vector_Valor_P_Max(5) + Vector_Valor_P_Max(6) + Vector_Valor_P_Max(7) + Vector_Valor_P_Max(8) + Vector_Valor_P_Max(9)) / 10
                            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion_P_max_2s

                            'Obtencio de Valor_P_Min 
                            Index = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi) - Puntero_Base
                            Valor_P_Min = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                            For Index_P_Min = 0 To Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi)
                                If Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Min)(1) < Valor_P_Min Then
                                    Valor_P_Min = Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_P_Min)(1)
                                End If
                            Next
                            Vector_Valor_P_Min(0) = Vector_Valor_P_Min(1)
                            Vector_Valor_P_Min(1) = Vector_Valor_P_Min(2)
                            Vector_Valor_P_Min(2) = Vector_Valor_P_Min(3)
                            Vector_Valor_P_Min(3) = Vector_Valor_P_Min(4)
                            Vector_Valor_P_Min(4) = Vector_Valor_P_Min(5)
                            Vector_Valor_P_Min(5) = Vector_Valor_P_Min(6)
                            Vector_Valor_P_Min(6) = Vector_Valor_P_Min(7)
                            Vector_Valor_P_Min(7) = Vector_Valor_P_Min(8)
                            Vector_Valor_P_Min(8) = Vector_Valor_P_Min(9)
                            Vector_Valor_P_Min(9) = Valor_P_Min
                            Valor_Promedio_P_Min = (Vector_Valor_P_Min(0) + Vector_Valor_P_Min(1) + Vector_Valor_P_Min(2) + Vector_Valor_P_Min(3) + Vector_Valor_P_Min(4) + Vector_Valor_P_Min(5) + Vector_Valor_P_Min(6) + Vector_Valor_P_Min(7) + Vector_Valor_P_Min(8) + Vector_Valor_P_Min(9)) / 10
                            Valor_P_Min = Valor_Promedio_P_Min * PorCiento_Comparacion_P_min
                            Cont_Limite_Repeticion_PorCiento_Comparacion_P_max_2s = 0
                        End If

                        'Obtencion del intervalo de busqueda 
                        If Index_Tabla_Complejo_QRS < Cantidad_Leidos_Tabla_QRS And Error_QRS = 0 Then
                            Index = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(J) - Puntero_Base + Duracion_Maxima_QRS * Frecuencia
                            Index_Inicio_Intervalo_Busqueda_Entre_QRS = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(J) - Puntero_Base + Duracion_Maxima_QRS * Frecuencia
                            Index_Fin_Intervalo_Busqueda_Entre_QRS = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi) - Puntero_Base - Duracion_Maxima_QRS * Frecuencia

                            ''Obtencion Index_Inicio_Intervalo_Busqueda_Entre_QRS apartir de la uvicacion del punto S mas 240 ms siempre que  este despues de 100 ms del punto J 
                            'Index_Inicio_Intervalo_Busqueda_Entre_QRS = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(R) + Separacion_Minima_QRS * Frecuencia - Puntero_Base
                            'If Index_Inicio_Intervalo_Busqueda_Entre_QRS < Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(J) + 0.1 * Frecuencia - Puntero_Base Then
                            '    Index_Inicio_Intervalo_Busqueda_Entre_QRS = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(J) + 0.1 * Frecuencia - Puntero_Base
                            'End If
                            'Index = Index_Inicio_Intervalo_Busqueda_Entre_QRS
                            ''Obtencion Index_Fin_Intervalo_Busqueda_Entre_QRS apartir de la uvicacion del punto Q menos 240 ms siempre que  este antes de 100 ms del punto Qi
                            'Index_Fin_Intervalo_Busqueda_Entre_QRS = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R) - Puntero_Base - Separacion_Minima_QRS * Frecuencia
                            'If Index_Fin_Intervalo_Busqueda_Entre_QRS > Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q) - 0.15 * Frecuencia - Puntero_Base Then
                            '    Index_Fin_Intervalo_Busqueda_Entre_QRS = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q) - 0.15 * Frecuencia - Puntero_Base
                            'End If
                        End If

                        While Error_QRS = 0
                            'Obtencion de la primera aproximacio de P_Max_Central
                            While Error_QRS = 0 And Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) <= Valor_P_Max
                                Index = Index + 1
                                If Index >= Index_Fin_Intervalo_Busqueda_Entre_QRS Then
                                    Error_QRS = 1
                                End If
                            End While

                            'Si no se detecto P_Max_Central se relisa la busqueda de un posible Valor_P_Min
                            If Error_QRS = 1 Then
                                Error_QRS = 0
                                Index = Index_Inicio_Intervalo_Busqueda_Entre_QRS
                                'Deteccion de un posible Valor_P_Min
                                'While Error_QRS = 0 And Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) >= Valor_P_Min
                                P_Min_Izquierda = 1
                                While Error_QRS = 0 And Index <= Index_Fin_Intervalo_Busqueda_Entre_QRS
                                    Index = Index + 1
                                    If P_Min_Izquierda > Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                                        P_Min_Izquierda = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                        Index_Temp = Index
                                    End If
                                    If Index >= Index_Fin_Intervalo_Busqueda_Entre_QRS Then
                                        Error_QRS = 1
                                    End If
                                End While

                                If Valor_P_Min > P_Min_Izquierda Then
                                    Index = Index_Temp
                                    Index_Temp_1 = Index_Temp
                                    Error_QRS = 0
                                Else
                                    Error_QRS = 1
                                End If


                                'Deteccion de un posible P_Max_Central 
                                If Error_QRS = 0 Then
                                    ' Avansar a la izquierda asta que el valor sea mayor al 0
                                    While 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                        Index = Index - 1
                                        If Index <= Index_Inicio_Intervalo_Busqueda_Entre_QRS Then
                                            Error_QRS = 2
                                        End If
                                    End While

                                    'Busqueda del mayor valor de P_Max_Central en el lobulo despues de la primera aproximacion  
                                    P_Max_Central = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                    Index_Temp = Index
                                    While 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                        Index = Index - 1
                                        If P_Max_Central < Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                                            P_Max_Central = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                            Index_Temp = Index
                                        End If
                                        If Index <= Index_Inicio_Intervalo_Busqueda_Entre_QRS Then
                                            Error_QRS = 2
                                        End If
                                    End While
                                    If P_Max_Central > 0 And Math.Abs(P_Min_Izquierda) * 0.4 < P_Max_Central Then
                                        Index = Index_Temp
                                        Error_QRS = 0
                                    Else
                                        Error_QRS = 2
                                    End If
                                End If


                                'Deteccion de un posible P_Max_Central por que no se detecto nada al izquierda de Valor_P_Min
                                If Error_QRS = 2 Then
                                    Index = Index_Temp_1
                                    ' Avansar a la Derecha asta que el valor sea mayor al 0
                                    While 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                        Index = Index + 1
                                        If Index >= Index_Fin_Intervalo_Busqueda_Entre_QRS Then
                                            Error_QRS = 1
                                        End If
                                    End While

                                    'Busqueda del mayor valor de P_Max_Central en el lobulo despues de la primera aproximacion  
                                    P_Max_Central = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                    Index_Temp = Index
                                    While 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                        Index = Index + 1
                                        If P_Max_Central < Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                                            P_Max_Central = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                            Index_Temp = Index
                                        End If
                                        If Index >= Index_Fin_Intervalo_Busqueda_Entre_QRS Then
                                            Error_QRS = 1
                                        End If
                                    End While
                                    If P_Max_Central > 0 And Math.Abs(P_Min_Izquierda) * 0.4 < P_Max_Central Then
                                        Index = Index_Temp
                                        Error_QRS = 0
                                    Else
                                        Error_QRS = 1
                                    End If
                                End If
                            End If

                            If Error_QRS = 0 Then

                                P_Max_Central = -1
                                P_Max_Izquierda = -1
                                P_Max_Derecha = -1
                                P_Min_Izquierda = 1
                                P_Min_Derecha = 1
                                P_Min_Derecha_1 = 1
                                Bandera_Muesca_Detectada = 0

                                'Busqueda del mayor valor de P_Max_Central en el lobulo despues de la primera aproximacion  
                                P_Max_Central = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                Index_Temp = Index
                                While 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                    Index = Index + 1
                                    If P_Max_Central < Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                                        P_Max_Central = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                        Index_Temp = Index
                                    End If
                                    If Index >= Index_Fin_Intervalo_Busqueda_Entre_QRS Then
                                        Error_QRS = 1
                                    End If
                                End While
                                'Actulizar la uvicacion 
                                Index = Index_Temp

                                ' Corregir posible Confucion entre Onda P y un complejo QRS  
                                If Index_Fin_Intervalo_Busqueda_Entre_QRS - Index > 0.3 * Frecuencia Then
                                    Index_Fin_Intervalo_Busqueda_temp = Index + 0.3 * Frecuencia
                                    'ElseIf Index_Fin_Intervalo_Busqueda_Entre_QRS - Index < 0.1 * Frecuencia Then
                                    '    Index_Fin_Intervalo_Busqueda_temp = Index + 0.1 * Frecuencia
                                Else
                                    Index_Fin_Intervalo_Busqueda_temp = Index_Fin_Intervalo_Busqueda_Entre_QRS
                                End If

                                ' Busqueda de un P_Max_Derecha mayor a P_Max_Central
                                P_Max_Derecha = P_Max_Central
                                While Index < Index_Fin_Intervalo_Busqueda_temp
                                    Index = Index + 1
                                    If P_Max_Derecha < Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                                        P_Max_Derecha = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                        Index_Temp_1 = Index
                                    End If
                                End While
                                ' Confirmar que el valor maximo P_Max_Derecha no esta en el limite del intervalo de busqueda, de ser asi si considera que este podria aumentar mas y por tanto pertenece a otro complejo QRS 
                                If Index_Temp_1 >= Index_Fin_Intervalo_Busqueda_temp Then
                                    P_Max_Derecha = -1
                                End If

                                ' Validar que no es un cambio de Nivel ¯¯\__
                                If P_Max_Derecha > P_Max_Central And Error_QRS = 0 Then
                                    Index = Index_Temp_1
                                    'Corregir el intervalo de busqueda
                                    If Index_Fin_Intervalo_Busqueda_temp > Index + 0.2 * Frecuencia Then
                                        Index_Fin_Intervalo_Busqueda_temp = Index + 0.2 * Frecuencia
                                    End If
                                    If Index_Inicio_Intervalo_Busqueda_Entre_QRS < Index - 0.2 * Frecuencia Then
                                        Index_Inicio_Intervalo_Busqueda_temp = Index - 0.2 * Frecuencia
                                    Else
                                        Index_Inicio_Intervalo_Busqueda_temp = Index_Inicio_Intervalo_Busqueda_Entre_QRS
                                    End If

                                    ' Obtener posible P_Max_Derecha 
                                    While Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1) <= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                        Index = Index + 1
                                        Index_Temp_1 = Index
                                        P_Max_Derecha = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                        If Index >= Index_Fin_Intervalo_Busqueda_temp Then
                                            Error_QRS = 2
                                        End If
                                    End While

                                    ' Avansar a la Derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Central
                                    While PorCiento_Comparacion_Busqueda * P_Max_Derecha <= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) And Error_QRS = 0
                                        Index = Index + 1
                                        If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                            Error_QRS = 2
                                        End If
                                    End While
                                    ' Avansar a la Derecha asta que el valor sea menor a 0
                                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                    While m < -1 * m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) And Error_QRS = 0
                                        Index = Index + 1
                                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                        If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                            Error_QRS = 2
                                        End If
                                    End While

                                    ' Obtener P_Min_Derecha
                                    If 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) Then
                                        While Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1) >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                            Index = Index + 1
                                            P_Min_Derecha = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                            If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                                Error_QRS = 2
                                                P_Min_Derecha = 1
                                            End If
                                        End While
                                    End If

                                    If Error_QRS = 0 Or Error_QRS = 2 Then
                                        Index = Index_Temp_1
                                        Error_QRS = 0
                                    End If

                                    ' Avansar a la izquierda asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Central
                                    While PorCiento_Comparacion_Busqueda * P_Max_Derecha <= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1) And Error_QRS = 0
                                        Index = Index - 1
                                        If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                            Error_QRS = 2
                                        End If
                                    End While

                                    ' Avansar a la izquierda asta que el valor sea menor al 0
                                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                    While m > m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                        Index = Index - 1
                                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                        If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                            Error_QRS = 2
                                        End If
                                    End While
                                    'Uvicacion del inicio del lobulo positivo por si es un desnivel
                                    Index_Cambio_Nivel = Index
                                    ' Obtener P_Min_Izquierda 
                                    If 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                        While m >= 0 And Error_QRS = 0
                                            Index = Index - 1
                                            P_Min_Izquierda = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                            If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                                Error_QRS = 2
                                            End If
                                        End While
                                    End If

                                End If

                                'Obtencion del P_Min mas pegueño
                                If P_Min_Izquierda < P_Min_Derecha Then
                                    P_Min_Comparacion = P_Min_Izquierda
                                Else
                                    P_Min_Comparacion = P_Min_Derecha
                                End If

                                'Comprobacion si existe una Confucion de Onda T con Complejo QRS (P_Max_Derecha > P_Max_Central) y no es un desnivel
                                If (P_Max_Derecha <= Margen_Separacion_QRS_Ruido * Valor_Promedio_P_Max And P_Max_Derecha > P_Max_Central) Then
                                    'Comprobacion si no es un desnivel
                                    If (P_Max_Derecha * Margen_Separacion_Desniveles < Math.Abs(P_Min_Comparacion) And P_Max_Derecha > Margen_Separacion_Desniveles * Math.Abs(P_Min_Comparacion) And P_Min_Comparacion < 0) Then
                                        Bandera_Desnivel_Detectado = 0
                                        P_Max_Central = P_Max_Derecha
                                        Index = Index_Temp_1
                                        Index_Temp = Index_Temp_1
                                        Error_QRS = 0
                                    Else
                                        Bandera_Desnivel_Detectado = 1
                                        Index = Index_Temp
                                        Error_QRS = 0
                                    End If
                                Else
                                    Bandera_Desnivel_Detectado = 0
                                    Index = Index_Temp
                                    Error_QRS = 0
                                End If
                                ' Limpiar los parametros de busqueda
                                P_Max_Derecha = -1
                                P_Min_Izquierda = 1
                                P_Min_Derecha = 1

                                ' Obtener P_Max_Central definitivo y otros
                                Bandera_Cambio_Lobulo_Central_a_Derecho = 0
                                While Bandera_Cambio_Lobulo_Central_a_Derecho = 0 And Error_QRS = 0

                                    Bandera_Cambio_Lobulo_Central_a_Derecho = 1
                                    'Obtener posicion de P_Max_Central 
                                    Puntero_P_Max_Central = Puntero_Base + Index
                                    'Definir los Intervalos de Busqueda
                                    Index_Fin_Intervalo_Busqueda_temp = Index + Duracion_Maxima_QRS * Frecuencia
                                    Index_Inicio_Intervalo_Busqueda_temp = Index - Duracion_Maxima_QRS * Frecuencia
                                    If Index_Fin_Intervalo_Busqueda_temp > Index_Fin_Intervalo_Busqueda_Entre_QRS Then
                                        Index_Fin_Intervalo_Busqueda_temp = Index_Fin_Intervalo_Busqueda_Entre_QRS
                                        'Index_Fin_Intervalo_Busqueda_temp = Index + 0.1 * Frecuencia
                                    End If
                                    If Bandera_Desnivel_Detectado = 1 And Index_Cambio_Nivel < Index_Fin_Intervalo_Busqueda_temp Then
                                        Index_Fin_Intervalo_Busqueda_temp = Index_Cambio_Nivel
                                    End If
                                    If Index_Inicio_Intervalo_Busqueda_temp < Index_Inicio_Intervalo_Busqueda_Entre_QRS Then
                                        'Index_Fin_Intervalo_Busqueda_temp = Index_Inicio_Intervalo_Busqueda_Entre_QRS
                                        Index_Inicio_Intervalo_Busqueda_temp = Index_Inicio_Intervalo_Busqueda_Entre_QRS
                                        'Index_Inicio_Intervalo_Busqueda_temp = Index - 0.1 * Frecuencia
                                    End If
                                    ' Avansar a la Derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Central
                                    While PorCiento_Comparacion_Busqueda * P_Max_Central <= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) And Error_QRS = 0
                                        Index = Index + 1
                                        If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                            Error_QRS = 2
                                        End If
                                    End While

                                    ' Avansar a la Derecha asta que el valor sea menor a 0
                                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                    While m < -1 * m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) And Error_QRS = 0
                                        Index = Index + 1
                                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                        If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                            Error_QRS = 2
                                        End If
                                    End While

                                    'Obtener posicion de S
                                    Puntero_S = Puntero_Base + Index

                                    ' Obtener P_Min_Derecha
                                    If 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) Then
                                        While Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1) >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                            Index = Index + 1
                                            P_Min_Derecha = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                            If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                                Error_QRS = 2
                                                P_Min_Derecha = 1
                                            End If
                                        End While
                                    End If

                                    'Comprobar si existe una muesca comparando contra el 30% P_Max_Central
                                    If ((Math.Abs(P_Min_Derecha) < 0.3 * P_Max_Central And P_Min_Derecha < 0) Or P_Min_Derecha > 0) And Error_QRS = 0 Then
                                        'Respaldo de Index_Clasificacion
                                        Index_Temp_2 = Index
                                        P_Min_Derecha_Temp = 1
                                        'Buscar un P_Min_Derecha negativo o mas pequeño 
                                        While Index < Index_Fin_Intervalo_Busqueda_temp And Error_QRS = 0
                                            Index = Index + 1
                                            If P_Min_Derecha_Temp > Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                                                P_Min_Derecha_Temp = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                                Index_Temp_1 = Index
                                            End If
                                            If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                                Error_QRS = 2
                                                P_Min_Derecha = 1
                                            End If
                                        End While

                                        ' Confirmar que el valor maximo P_Max_Derecha no esta en el limite del intervalo de busqueda, de ser asi si considera que este podria aumentar mas y por tanto pertenece a otro complejo QRS 
                                        If Index_Temp_1 >= Index_Fin_Intervalo_Busqueda_temp Then
                                            P_Min_Derecha_Temp = 1
                                        End If
                                        'Confirmar que el  P_Min_Derecha_Temp detectado pertence al complejo QRS 
                                        If Math.Abs(P_Min_Derecha_Temp) > 0.4 * P_Max_Central And P_Min_Derecha_Temp < 0 And Error_QRS <> 1 Then
                                            'Confirmar que el P_Min_Derecha_Temp detectado es menor a P_Min_Derecha
                                            If P_Min_Derecha_Temp < P_Min_Derecha Then
                                                Index = Index_Temp_1
                                                P_Min_Derecha = P_Min_Derecha_Temp
                                                Error_QRS = 0
                                                Bandera_Muesca_Detectada = 1
                                            Else
                                                Index = Index_Temp_2
                                                Error_QRS = 0
                                            End If
                                        Else
                                            Index = Index_Temp_2
                                            Error_QRS = 0
                                        End If

                                    End If


                                    'Obtener posicion de P_Min_Derecha
                                    Puntero_P_Min_Derecha = Puntero_Base + Index
                                    Puntero_S1 = Puntero_Base + Index

                                    ' Avansar a la derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Min_Derecha
                                    ' Avansar si P_Min_Derecha<0
                                    If P_Min_Derecha < 0 And Error_QRS = 0 Then

                                        ' Avansar a la derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Min_Derecha
                                        While PorCiento_Comparacion_Busqueda * P_Min_Derecha >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) And Error_QRS = 0
                                            Index = Index + 1
                                            If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                                Error_QRS = 2
                                            End If
                                        End While

                                        ' Avansar a la Derecha asta que el valor sea mayor a 0
                                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                        While m > m_Comparacion_Wavelet And 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) And Error_QRS = 0
                                            Index = Index + 1
                                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                            If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                                Error_QRS = 2
                                            End If
                                        End While
                                        'Obtener posicion de S1


                                        If Error_QRS = 2 Then
                                            Puntero_S1 = Puntero_P_Min_Derecha
                                        Else
                                            Puntero_S1 = Puntero_Base + Index
                                        End If


                                        ' Obtener P_Max_Derecha
                                        If 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) Then
                                            While Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1) <= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                                Index = Index + 1
                                                P_Max_Derecha = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                                If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                                    Error_QRS = 2
                                                    P_Max_Derecha = -1
                                                End If
                                            End While
                                        End If

                                        'Obtener posicion de P_Max_Derecha
                                        Puntero_P_Max_Derecha = Puntero_Base + Index
                                        Puntero_S2 = Puntero_Base + Index
                                        ' Comprobar si P_Max_Derecha > P_Max_Central, de ser asi corregir el P_Max_Central, si no es asi buscar P_Min_Derecha_1
                                        If P_Max_Derecha > P_Max_Central Then
                                            'Puntero = Puntero + Index_Clasificacion
                                            'Index = Index + Index_Clasificacion
                                            Index_Temp = Index
                                            Puntero_P_Max_Central = Puntero_P_Max_Derecha
                                            P_Max_Central = P_Max_Derecha
                                            Bandera_Cambio_Lobulo_Central_a_Derecho = 0
                                            P_Max_Derecha = -1

                                        ElseIf P_Max_Derecha > 0 Then
                                            ' Avansar a la Derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Derecha, y P_Max_Derecha>0
                                            While PorCiento_Comparacion_Busqueda_Extremos * P_Max_Derecha <= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) And Error_QRS = 0
                                                Index = Index + 1
                                                If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                                    Error_QRS = 2
                                                End If
                                            End While

                                            ' Avansar a la Derecha asta que el valor sea menor a 0
                                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                            While m < -1 * m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) And Error_QRS = 0
                                                Index = Index + 1
                                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                                If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                                    Error_QRS = 2
                                                End If
                                            End While
                                            'Obtener posicion de S2
                                            Puntero_S2 = Puntero_Base + Index

                                            ' Obtener P_Min_Derecha_1
                                            If 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) Then
                                                While Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1) >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                                    Index = Index + 1
                                                    P_Min_Derecha_1 = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                                    If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                                        Error_QRS = 2
                                                        P_Min_Derecha_1 = 1
                                                    End If
                                                End While
                                                'Obtener posicion de P_Min_Derecha_1
                                                Puntero_P_Min_Derecha_1 = Puntero_Base + Index

                                                ' Avansar a la derecha asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Min_Derecha_1
                                                While PorCiento_Comparacion_Busqueda_Extremos * P_Min_Derecha_1 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) And Error_QRS = 0
                                                    Index = Index + 1
                                                    If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                                        Error_QRS = 2
                                                    End If
                                                End While

                                                ' Avansar a la Derecha asta que el valor sea mayor a 0
                                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                                While m > m_Comparacion_Wavelet And 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index + 1)(1) And Error_QRS = 0
                                                    Index = Index + 1
                                                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                                    If Index > Index_Fin_Intervalo_Busqueda_temp Then
                                                        Error_QRS = 2
                                                    End If
                                                End While
                                                'Obtener posicion de S1
                                                Puntero_S3 = Puntero_Base + Index
                                            End If



                                        End If

                                    End If
                                End While

                                If Error_QRS = 0 Or Error_QRS = 2 Then
                                    Index = Index_Temp
                                    Error_QRS = 0
                                End If

                                ' Avansar a la izquierda asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Central
                                While PorCiento_Comparacion_Busqueda * P_Max_Central <= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1) And Error_QRS = 0
                                    Index = Index - 1
                                    If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                        Error_QRS = 2
                                    End If
                                End While

                                ' Avansar a la izquierda asta que el valor sea menor al 0
                                m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                While m > m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                    Index = Index - 1
                                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                    If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                        Error_QRS = 2
                                    End If
                                End While
                                'Obtener posicion de R

                                Puntero_R = Puntero_Base + Index

                                ' Obtener P_Min_Izquierda 
                                If 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                    While m >= 0 And Error_QRS = 0
                                        Index = Index - 1
                                        P_Min_Izquierda = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                        If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                            Error_QRS = 2
                                            P_Min_Izquierda = 1
                                        End If
                                    End While
                                End If

                                'Comprobar si existe una muesca comparando contra el 30% P_Max_Central
                                If ((Math.Abs(P_Min_Izquierda) < 0.3 * P_Max_Central And P_Min_Izquierda < 0) Or P_Min_Izquierda > 0) And Error_QRS = 0 Then
                                    'Respaldo de Index_Clasificacion
                                    Index_Temp_2 = Index
                                    P_Min_Izquierda_Temp = 1
                                    'Buscar un P_Min_Izquierda negativo o mas pequeño 
                                    While Index > Index_Inicio_Intervalo_Busqueda_temp And Error_QRS = 0
                                        Index = Index - 1
                                        If P_Min_Izquierda_Temp > Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                                            P_Min_Izquierda_Temp = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                            Index_Temp_1 = Index
                                        End If
                                        If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                            Error_QRS = 2
                                        End If
                                    End While

                                    ' Confirmar que el valor maximo P_Max_Derecha no esta en el limite del intervalo de busqueda, de ser asi si considera que este podria aumentar mas y por tanto pertenece a otro complejo QRS 
                                    If Index_Temp_1 <= Index_Inicio_Intervalo_Busqueda_temp Then
                                        P_Min_Izquierda_Temp = 1
                                    End If
                                    'Confirmar que el  P_Min_Izquierda_Temp detectado pertence al complejo QRS 
                                    If Math.Abs(P_Min_Izquierda_Temp) > 0.4 * P_Max_Central And P_Min_Izquierda_Temp < 0 And Error_QRS <> 1 Then
                                        'Confirmar que el P_Min_Izquierda_Temp detectado es menor a P_Min_Izquierda
                                        If P_Min_Izquierda_Temp < P_Min_Izquierda Then
                                            Index = Index_Temp_1
                                            P_Min_Izquierda = P_Min_Izquierda_Temp
                                            Error_QRS = 0
                                            Bandera_Muesca_Detectada = 1
                                        Else
                                            Index = Index_Temp_2
                                            Error_QRS = 0
                                        End If
                                    Else
                                        Index = Index_Temp_2
                                        Error_QRS = 0
                                    End If

                                End If

                                'Obtener posicion de P_Min_Izquierda
                                Puntero_P_Min_Izquierda = Puntero_Base + Index
                                Puntero_Q = Puntero_Base + Index

                                ' Avansar a la izquierda asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Min_Izquierda
                                ' Avansar si P_Min_Izquierda<0
                                If P_Min_Izquierda < 0 And Error_QRS = 0 Then
                                    ' Avansar a la izquierda asta que el valor sea mayor al PorCiento_Comparacion_Busqueda*P_Max_Central
                                    While PorCiento_Comparacion_Busqueda * P_Min_Izquierda >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1) And Error_QRS = 0
                                        Index = Index - 1
                                        If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                            Error_QRS = 2
                                        End If
                                    End While

                                    ' Avansar a la izquierda asta que el valor sea mayor al 0
                                    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                    While m < -1 * m_Comparacion_Wavelet And 0 >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                        Index = Index - 1
                                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                        If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                            Error_QRS = 2
                                        End If
                                    End While


                                    'Obtener posicion de Q
                                    If Error_QRS = 2 Then
                                        Puntero_Q = Puntero_P_Min_Izquierda
                                    Else
                                        Puntero_Q = Puntero_Base + Index
                                    End If


                                    ' Obtener P_Max_Izquierda 
                                    If 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) Then
                                        While Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1) >= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                            Index = Index - 1
                                            P_Max_Izquierda = Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1)
                                            If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                                Error_QRS = 2
                                                P_Max_Izquierda = -1
                                            End If
                                        End While
                                        'Obtener posicion de Puntero_P_Max_Izquierda 
                                        Puntero_P_Max_Izquierda = Puntero_Base + Index

                                        ' Avansar a la izquierda asta que el valor sea menor al PorCiento_Comparacion_Busqueda*P_Max_Izquierda o la pedendi
                                        While PorCiento_Comparacion_Busqueda_Extremos * P_Max_Izquierda <= Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) And Error_QRS = 0
                                            Index = Index - 1
                                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                            If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                                Error_QRS = 2
                                            End If
                                        End While

                                        ' Avansar a la izquierda asta que el valor sea menor al 0
                                        m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                        While m > m_Comparacion_Wavelet And 0 <= Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1) And Error_QRS = 0
                                            Index = Index - 1
                                            m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index - 1)(1))
                                            If Index < Index_Inicio_Intervalo_Busqueda_temp Then
                                                Error_QRS = 2
                                            End If
                                        End While

                                        'Obtener posicion de Q
                                        Puntero_Q_i = Puntero_Base + Index
                                    End If


                                End If
                                'Revisarrrrrr
                                If Error_QRS = 2 Or Error_QRS = 3 Then
                                    Error_QRS = 0
                                End If
                            End If
                            'Clasificar el Compelo QRS
                            If Error_QRS = 0 Then
                                'Eliminar la posible muesca si la separacion entre Puntero_P_Min_Derecha y Puntero_P_Max_Central es supériore a 100 ms
                                'Si se detecta una posible muesca, se comprueba si el valor del Minimo contrario(Izquierda o Derecha) supera el 40% de P_Max_Central y que el minimo detectado no esta a mas alla 100ms   
                                If Bandera_Muesca_Detectada = 1 And (Math.Abs(P_Min_Izquierda) > 0.4 * P_Max_Central And P_Min_Izquierda < 0) And (Puntero_P_Min_Derecha - Puntero_P_Max_Central) > 0.1 * Frecuencia Then
                                    P_Max_Derecha = -1
                                    P_Min_Derecha = 1
                                ElseIf Bandera_Muesca_Detectada = 2 And (Math.Abs(P_Min_Derecha) > 0.4 * P_Max_Central And P_Min_Derecha < 0) And (Puntero_P_Max_Central - Puntero_P_Min_Izquierda) > 0.1 * Frecuencia Then
                                    P_Max_Izquierda = -1
                                    P_Min_Izquierda = 1
                                ElseIf Bandera_Muesca_Detectada = 3 Then
                                    'Si se detecta una la existencia de dos posible muesca me quedo con la mas cercana a  Puntero_P_Max_Central
                                    If (Puntero_P_Max_Central - Puntero_P_Min_Izquierda) > (Puntero_P_Min_Derecha - Puntero_P_Max_Central) Then
                                        P_Max_Izquierda = -1
                                        P_Min_Izquierda = 1
                                    Else
                                        P_Max_Derecha = -1
                                        P_Min_Derecha = 1
                                    End If
                                End If

                                'Solo de pruebaaa
                                '-----------------------------------------
                                'Si la separacion entre el punto J y el punto Q de dos QRS consecutivos es menor a 150ms y el valor absoluto de P_Min_Izquierda no supera al 50 % de P_Min_Derecha se elimina P_Max_Izquierda por ser parte de la Onda P
                                If Puntero_Q - Puntero_Ultimo_J < Frecuencia * Separacion_Minima_QRS And P_Min_Derecha * 0.5 < P_Min_Izquierda Then
                                    P_Max_Izquierda = -1
                                ElseIf P_Min_Derecha * 0.07 < P_Min_Izquierda Then
                                    'Si el valor absoluto de P_Min_Izquierda no supera al 7 % de P_Min_Derecha se elimina P_Max_Izquierda y P_Min_Izquierda por ser ruido
                                    P_Max_Izquierda = -1
                                    P_Min_Izquierda = 1
                                End If
                                'Si el valor absoluto de  P_Min_Derecha no supera al 7 % de P_Min_Izquierda se elimina P_Max_Derecha y P_Min_Derecha por ser ruido
                                If P_Min_Izquierda * 0.07 < P_Min_Derecha Then
                                    P_Max_Derecha = -1
                                    P_Min_Derecha = 1
                                End If



                                If P_Max_Derecha < P_Max_Central * 0.07 Or 0 < P_Min_Derecha Then
                                    P_Max_Derecha = -1
                                End If

                                If P_Max_Izquierda < P_Max_Central * 0.07 Or 0 < P_Min_Izquierda Then
                                    P_Max_Izquierda = -1
                                End If


                                If P_Max_Izquierda <= 0 And P_Max_Derecha <= 0 Then
                                    If P_Min_Izquierda > 0 And P_Min_Derecha > 0 Then
                                        Tipo_QRS = Tipos_QRS.Sin_QRS
                                    ElseIf P_Min_Izquierda > 0 And P_Min_Derecha < 0 Then
                                        Tipo_QRS = Tipos_QRS.QS_0
                                    ElseIf P_Min_Izquierda < 0 And P_Min_Derecha > 0 Then
                                        Tipo_QRS = Tipos_QRS.R_0
                                    Else
                                        Tipo_QRS = Tipos_QRS.Rs_0
                                    End If
                                ElseIf P_Max_Izquierda > 0 And P_Max_Derecha < 0 Then
                                    If P_Min_Izquierda < 0 And P_Min_Derecha < 0 Then
                                        Tipo_QRS = Tipos_QRS.qRs_1
                                    ElseIf P_Min_Izquierda < 0 And P_Min_Derecha > 0 Then
                                        Tipo_QRS = Tipos_QRS.qR_1
                                    End If
                                ElseIf P_Max_Izquierda < 0 And P_Max_Derecha > 0 Then

                                    If P_Min_Izquierda > 0 Then
                                        If P_Min_Derecha_1 < 0 Then
                                            Tipo_QRS = Tipos_QRS.Qrs_0
                                        ElseIf P_Min_Derecha_1 > 0 Then
                                            Tipo_QRS = Tipos_QRS.Qr_0
                                        End If
                                    ElseIf P_Min_Izquierda < 0 And P_Min_Izquierda > P_Min_Derecha_1 * 0.5 Then
                                        Tipo_QRS = Tipos_QRS.Qrs_E_0
                                    Else
                                        Tipo_QRS = Tipos_QRS.RS_E_0
                                    End If
                                ElseIf P_Max_Izquierda > 0 And P_Max_Derecha > 0 Then
                                    If P_Max_Derecha > P_Max_Central * 0.75 And P_Max_Izquierda > P_Max_Central * 0.75 Then
                                        Tipo_QRS = Tipos_QRS.Sin_QRS
                                    ElseIf P_Max_Derecha > P_Max_Izquierda And P_Min_Derecha < P_Min_Izquierda Then
                                        If P_Min_Derecha_1 < 0 Then
                                            Tipo_QRS = Tipos_QRS.Qrs_E_0
                                        ElseIf P_Min_Derecha_1 > 0 Then
                                            Tipo_QRS = Tipos_QRS.Qr_E_0
                                        End If
                                    Else
                                        Tipo_QRS = Tipos_QRS.qRs_E_1
                                    End If

                                    'If P_Max_Derecha / P_Max_Central > 0.5 Then
                                    '    If P_Min_Derecha_1 < 0 Then
                                    '        Tipo_QRS = Tipos_QRS.Qrs_E_0
                                    '    ElseIf P_Min_Derecha_1 > 0 Then
                                    '        Tipo_QRS = Tipos_QRS.Qr_E_0
                                    '    End If
                                    'Else
                                    '    Tipo_QRS = Tipos_QRS.qRs_E_1
                                    'End If
                                End If

                                'Obtener las uvicaciones de Puntero_Q_i, Puntero_Q, Puntero_R, Puntero_S, Puntero_J

                                Select Case Tipo_QRS

                                    Case Tipos_QRS.Qr_0
                                        'Avansar a la izquierda asta actualizar el valor

                                        'Index_Final = Puntero_R - Puntero
                                        'If Index + Index_Final < 1 Then
                                        '    Index_Final = 2 - Index
                                        'End If
                                        'Index_Clasificacion = Puntero_P_Max_Central - Puntero - (Puntero_P_Max_Central - Puntero_R) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion - 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While

                                        'If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                        '    Puntero_R = Puntero + Index_Clasificacion + 1
                                        'Else
                                        '    Puntero_R = Puntero + Index_Clasificacion
                                        'End If

                                        '' Avansar a la derecha asta actualizar el valor
                                        'Index_Final = Puntero_S2 - Puntero
                                        'Index_Clasificacion = Puntero_P_Max_Derecha - Puntero + (Puntero_S2 - Puntero_P_Max_Derecha) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m < -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion + 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While

                                        'If m > -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                        '    Puntero_S2 = Puntero + Index_Clasificacion - 1
                                        'Else
                                        '    Puntero_S2 = Puntero + Index_Clasificacion
                                        'End If

                                        Puntero_Q_i = Puntero_R
                                        Puntero_Q = Puntero_S
                                        Puntero_R = Puntero_S1
                                        Puntero_S = Puntero_S2
                                        Puntero_J = Puntero_S2

                                    Case Tipos_QRS.qR_1
                                        ''Avansar a la izquierda asta actualizar el valor
                                        'Index_Final = Puntero_Q_i - Puntero
                                        'If Index + Index_Final < 1 Then
                                        '    Index_Final = 2 - Index
                                        'End If
                                        'Index_Clasificacion = Puntero_P_Max_Izquierda - Puntero - (Puntero_P_Max_Izquierda - Puntero_Q_i) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion - 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While

                                        'If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                        '    Puntero_Q_i = Puntero + Index_Clasificacion + 1
                                        'Else
                                        '    Puntero_Q_i = Puntero + Index_Clasificacion
                                        'End If

                                        '' Avansar a la derecha asta actualizar el valor
                                        'Index_Final = Puntero_S - Puntero
                                        'Index_Clasificacion = Puntero_P_Max_Central - Puntero + (Puntero_S - Puntero_P_Max_Central) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m < -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion + 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While

                                        'If m > -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                        '    Puntero_S = Puntero + Index_Clasificacion - 1
                                        'Else
                                        '    Puntero_S = Puntero + Index_Clasificacion
                                        'End If
                                        Puntero_Q_i = Puntero_Q_i
                                        Puntero_Q = Puntero_Q
                                        Puntero_R = Puntero_R
                                        Puntero_S = Puntero_S
                                        Puntero_J = Puntero_S
                                    Case Tipos_QRS.Qrs_0
                                        ''Avansar a la izquierda asta actualizar el valor
                                        'Index_Final = Puntero_R - Puntero
                                        'If Index + Index_Final < 1 Then
                                        '    Index_Final = 2 - Index
                                        'End If
                                        'Index_Clasificacion = Puntero_P_Max_Central - Puntero - (Puntero_P_Max_Central - Puntero_R) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion - 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While
                                        'If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                        '    Puntero_R = Puntero + Index_Clasificacion + 1
                                        'Else
                                        '    Puntero_R = Puntero + Index_Clasificacion
                                        'End If

                                        '' Avansar a la derecha asta actualizar el valor
                                        'Index_Final = Puntero_S3 - Puntero
                                        'Index_Clasificacion = Puntero_P_Min_Derecha_1 - Puntero + (Puntero_S3 - Puntero_P_Min_Derecha_1) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion + 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While

                                        'If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                        '    Puntero_S3 = Puntero + Index_Clasificacion - 1
                                        'Else
                                        '    Puntero_S3 = Puntero + Index_Clasificacion
                                        'End If

                                        Puntero_Q_i = Puntero_R
                                        Puntero_Q = Puntero_S
                                        Puntero_R = Puntero_S1
                                        Puntero_S = Puntero_S2
                                        Puntero_J = Puntero_S3
                                    Case Tipos_QRS.qRs_1
                                        ''Avansar a la izquierda asta actualizar el valor
                                        'Index_Final = Puntero_Q_i - Puntero
                                        'If Index + Index_Final < 1 Then
                                        '    Index_Final = 2 - Index
                                        'End If
                                        'Index_Clasificacion = Puntero_P_Max_Izquierda - Puntero - (Puntero_P_Max_Izquierda - Puntero_Q_i) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion - 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While

                                        'If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                        '    Puntero_Q_i = Puntero + Index_Clasificacion + 1
                                        'Else
                                        '    Puntero_Q_i = Puntero + Index_Clasificacion
                                        'End If

                                        '' Avansar a la derecha asta actualizar el valor
                                        'Index_Final = Puntero_S1 - Puntero
                                        'Index_Clasificacion = Puntero_P_Min_Derecha - Puntero + (Puntero_S1 - Puntero_P_Min_Derecha) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion + 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While
                                        'If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                        '    Puntero_S1 = Puntero + Index_Clasificacion - 1
                                        'Else
                                        '    Puntero_S1 = Puntero + Index_Clasificacion
                                        'End If


                                        Puntero_Q_i = Puntero_Q_i
                                        Puntero_Q = Puntero_Q
                                        Puntero_R = Puntero_R
                                        Puntero_S = Puntero_S
                                        Puntero_J = Puntero_S1
                                    Case Tipos_QRS.R_0
                                        ''Avansar a la izquierda asta actualizar el valor
                                        'Index_Final = Puntero_Q - Puntero
                                        'If Index + Index_Final < 1 Then
                                        '    Index_Final = 2 - Index
                                        'End If
                                        'Index_Clasificacion = Puntero_P_Min_Izquierda - Puntero - (Puntero_P_Min_Izquierda - Puntero_Q) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m < -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion - 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While

                                        'If m > -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                        '    Puntero_Q = Puntero + Index_Clasificacion + 1
                                        'Else
                                        '    Puntero_Q = Puntero + Index_Clasificacion
                                        'End If

                                        '' Avansar a la derecha asta actualizar el valor
                                        'Index_Final = Puntero_S - Puntero
                                        'Index_Clasificacion = Puntero_P_Max_Central - Puntero + (Puntero_S - Puntero_P_Max_Central) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m < -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion + 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While
                                        'If m > -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                        '    Puntero_S = Puntero + Index_Clasificacion - 1
                                        'Else
                                        '    Puntero_S = Puntero + Index_Clasificacion
                                        'End If

                                        Puntero_Q_i = Puntero_Q
                                        Puntero_Q = Puntero_Q
                                        Puntero_R = Puntero_R
                                        Puntero_S = Puntero_S
                                        Puntero_J = Puntero_S
                                    Case Tipos_QRS.Rs_0
                                        ''Avansar a la izquierda asta actualizar el valor
                                        'Index_Final = Puntero_Q - Puntero
                                        'If Index + Index_Final < 1 Then
                                        '    Index_Final = 2 - Index - Index
                                        'End If
                                        'Index_Clasificacion = Puntero_P_Min_Izquierda - Puntero - (Puntero_P_Min_Izquierda - Puntero_Q) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m < -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion - 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While
                                        'If m > -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                        '    Puntero_Q = Puntero + Index_Clasificacion + 1
                                        'Else
                                        '    Puntero_Q = Puntero + Index_Clasificacion
                                        'End If

                                        '' Avansar a la derecha asta actualizar el valor
                                        'Index_Final = Puntero_S1 - Puntero
                                        'Index_Clasificacion = Puntero_P_Min_Derecha - Puntero + (Puntero_S1 - Puntero_P_Min_Derecha) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion + 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While
                                        'If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                        '    Puntero_S1 = Puntero + Index_Clasificacion - 1
                                        'Else
                                        '    Puntero_S1 = Puntero + Index_Clasificacion
                                        'End If


                                        Puntero_Q_i = Puntero_Q
                                        Puntero_Q = Puntero_Q
                                        Puntero_R = Puntero_R
                                        Puntero_S = Puntero_S
                                        Puntero_J = Puntero_S1
                                    Case Tipos_QRS.QS_0
                                        ''Avansar a la izquierda asta actualizar el valor
                                        'Index_Final = Puntero_R - Puntero
                                        'If Index + Index_Final < 1 Then
                                        '    Index_Final = 2 - Index
                                        'End If
                                        'Index_Clasificacion = Puntero_P_Max_Central - Puntero - (Puntero_P_Max_Central - Puntero_R) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion - 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While
                                        'If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                        '    Puntero_R = Puntero + Index_Clasificacion + 1
                                        'Else
                                        '    Puntero_R = Puntero + Index_Clasificacion
                                        'End If

                                        '' Avansar a la derecha asta actualizar el valor
                                        'Index_Final = Puntero_S1 - Puntero
                                        'Index_Clasificacion = Puntero_P_Min_Derecha - Puntero + (Puntero_S1 - Puntero_P_Min_Derecha) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion + 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While
                                        'If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                        '    Puntero_S1 = Puntero + Index_Clasificacion - 1
                                        'Else
                                        '    Puntero_S1 = Puntero + Index_Clasificacion
                                        'End If

                                        Puntero_Q_i = Puntero_R
                                        Puntero_Q = Puntero_S
                                        Puntero_R = Puntero_S
                                        Puntero_S = Puntero_S
                                        Puntero_J = Puntero_S1
                                    Case Tipos_QRS.Qr_E_0
                                        ''Avansar a la izquierda asta actualizar el valor
                                        'Index_Final = Puntero_R - Puntero
                                        'If Index + Index_Final < 1 Then
                                        '    Index_Final = 2 - Index
                                        'End If
                                        'Index_Clasificacion = Puntero_P_Max_Central - Puntero - (Puntero_P_Max_Central - Puntero_R) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion - 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While
                                        'If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                        '    Puntero_R = Puntero + Index_Clasificacion + 1
                                        'Else
                                        '    Puntero_R = Puntero + Index_Clasificacion
                                        'End If

                                        '' Avansar a la derecha asta actualizar el valor
                                        'Index_Final = Puntero_S2 - Puntero
                                        'Index_Clasificacion = Puntero_P_Max_Derecha - Puntero + (Puntero_S2 - Puntero_P_Max_Derecha) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m < -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion + 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While

                                        'If m > -1 * m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                        '    Puntero_S2 = Puntero + Index_Clasificacion - 1
                                        'Else
                                        '    Puntero_S2 = Puntero + Index_Clasificacion
                                        'End If

                                        Puntero_Q_i = Puntero_R
                                        Puntero_Q = Puntero_S
                                        Puntero_R = Puntero_S1
                                        Puntero_S = Puntero_S2
                                        Puntero_J = Puntero_S2
                                    Case Tipos_QRS.Qrs_E_0
                                        ''Avansar a la izquierda asta actualizar el valor
                                        'Index_Final = Puntero_R - Puntero
                                        'If Index + Index_Final < 1 Then
                                        '    Index_Final = 2 - Index
                                        'End If
                                        'Index_Clasificacion = Puntero_P_Max_Central - Puntero - (Puntero_P_Max_Central - Puntero_R) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion - 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While
                                        'If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                        '    Puntero_R = Puntero + Index_Clasificacion + 1
                                        'Else
                                        '    Puntero_R = Puntero + Index_Clasificacion
                                        'End If

                                        '' Avansar a la derecha asta actualizar el valor
                                        'Index_Final = Puntero_S3 - Puntero
                                        'Index_Clasificacion = Puntero_P_Min_Derecha_1 - Puntero + (Puntero_S3 - Puntero_P_Min_Derecha_1) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion + 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While

                                        'If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                        '    Puntero_S3 = Puntero + Index_Clasificacion - 1
                                        'Else
                                        '    Puntero_S3 = Puntero + Index_Clasificacion
                                        'End If


                                        Puntero_Q_i = Puntero_R
                                        Puntero_Q = Puntero_S
                                        Puntero_R = Puntero_S1
                                        Puntero_S = Puntero_S2
                                        Puntero_J = Puntero_S3
                                    Case Tipos_QRS.qRs_E_1
                                        ''Avansar a la izquierda asta actualizar el valor
                                        'Index_Final = Puntero_Q_i - Puntero
                                        'If Index + Index_Final < 1 Then
                                        '    Index_Final = 2 - Index
                                        'End If
                                        'Index_Clasificacion = Puntero_P_Max_Izquierda - Puntero - (Puntero_P_Max_Izquierda - Puntero_Q_i) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion - 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While


                                        'If m < m_Comparacion_Wavelet And 0 < Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                        '    Puntero_Q_i = Puntero + Index_Clasificacion + 1
                                        'Else
                                        '    Puntero_Q_i = Puntero + Index_Clasificacion
                                        'End If

                                        '' Avansar a la derecha asta actualizar el valor
                                        'Index_Final = Puntero_S1 - Puntero
                                        'Index_Clasificacion = Puntero_P_Min_Derecha - Puntero + (Puntero_S1 - Puntero_P_Min_Derecha) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion + 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While

                                        'If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                        '    Puntero_S1 = Puntero + Index_Clasificacion - 1
                                        'Else
                                        '    Puntero_S1 = Puntero + Index_Clasificacion
                                        'End If

                                        Puntero_Q_i = Puntero_Q_i
                                        Puntero_Q = Puntero_Q
                                        Puntero_R = Puntero_R
                                        Puntero_S = Puntero_S
                                        Puntero_J = Puntero_S1
                                    Case Tipos_QRS.RS_E_0
                                        ''Avansar a la izquierda asta actualizar el valor
                                        'Index_Final = Puntero_Q - Puntero
                                        'If Index + Index_Final < 1 Then
                                        '    Index_Final = 2 - Index - Index
                                        'End If
                                        'Index_Clasificacion = Puntero_P_Min_Izquierda - Puntero - (Puntero_P_Min_Izquierda - Puntero_Q) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m < -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) And Index_Clasificacion > Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion - 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While
                                        'If m > -1 * m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1) Then
                                        '    Puntero_Q = Puntero + Index_Clasificacion + 1
                                        'Else
                                        '    Puntero_Q = Puntero + Index_Clasificacion
                                        'End If

                                        '' Avansar a la derecha asta actualizar el valor
                                        'Index_Final = Puntero_S1 - Puntero
                                        'Index_Clasificacion = Puntero_P_Min_Derecha - Puntero + (Puntero_S1 - Puntero_P_Min_Derecha) / 2
                                        'm = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'While m > m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) And Index_Clasificacion <= Index_Final
                                        '    Index_Clasificacion = Index_Clasificacion + 1
                                        '    m = Frecuencia * (Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion)(1) - Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion - 1)(1))
                                        'End While
                                        'If m < m_Comparacion_Wavelet And 0 > Datos_Transformada_Wavelet.Tables(0).Rows(Index + Index_Clasificacion + 1)(1) Then
                                        '    Puntero_S1 = Puntero + Index_Clasificacion - 1
                                        'Else
                                        '    Puntero_S1 = Puntero + Index_Clasificacion
                                        'End If


                                        Puntero_Q_i = Puntero_Q
                                        Puntero_Q = Puntero_Q
                                        Puntero_R = Puntero_R
                                        Puntero_S = Puntero_S
                                        Puntero_J = Puntero_S1
                                    Case Else
                                        Puntero_Q_i = Puntero_R
                                        Puntero_Q = Puntero_R
                                        Puntero_R = Puntero_P_Max_Central
                                        Puntero_S = Puntero_S
                                        Puntero_J = Puntero_S

                                End Select

                            End If
                            'Actulizando un nuevo QRS
                            Select Case Error_QRS
                                Case 0

                                    'Comprobacion de posible desnivel
                                    'Obtencion del P_Min mas pegueño
                                    If P_Min_Izquierda < P_Min_Derecha Then
                                        P_Min_Comparacion = P_Min_Izquierda
                                    Else
                                        P_Min_Comparacion = P_Min_Derecha
                                    End If
                                    'Comprobacion de posible desnivel
                                    'Comprobacion de posible ruido o Fluter
                                    If Tipo_QRS <> Tipos_QRS.Sin_QRS And Puntero_J - Puntero_Q_i > Duracion_Minima_QRS * Frecuencia Then
                                        'Comprobacion de posible confucion de la onda T con un complejo QRS:
                                        'Se resta la uvicacion del punto R del RR anterior menos la del punto R del RR calculado y 
                                        'el intervalo tiene que ser mayor al 40% (0.6) del Segmentos_RR_Promedio o mayor a la Separacion_Minima_QRS 
                                        If (Segmentos_RR_Promedio * 0.4 > Frecuencia * Separacion_Minima_QRS And Puntero_R - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(R) > Segmentos_RR_Promedio * 0.4) Or (Segmentos_RR_Promedio * 0.4 < Frecuencia * Separacion_Minima_QRS And Puntero_R - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(R) > Frecuencia * Separacion_Minima_QRS) Then
                                            'Comprobacion de posible desnivel
                                            If P_Max_Central * Margen_Separacion_Desniveles < Math.Abs(P_Min_Comparacion) And P_Max_Central > Margen_Separacion_Desniveles * Math.Abs(P_Min_Comparacion) And P_Min_Comparacion < 0 Then
                                                'Comprobacion de posible no confucion en la onda T o P (Validacion de que se cumpla la Separacion_Minima_QRS antes y despues de lso cumplejos QRS ya Obtenidos)   
                                                'If ((Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R) - Puntero_R) / Frecuencia > 0.8 * Separacion_Minima_QRS And (Puntero_R - Puntero_Ultimo_J) / Frecuencia > Separacion_Minima_QRS * 0.8) Then

                                                'Cuando el intervalo de busqueda supera los dos segundos
                                                If (Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(R)) / Frecuencia > 2 Then
                                                    'Comprobacion de posible ruido
                                                    If ((P_Max_Central <= Margen_Separacion_QRS_Ruido * Valor_Promedio_P_Max And P_Min_Comparacion >= Margen_Separacion_QRS_Ruido * Valor_Promedio_P_Min) And (P_Max_Central >= Valor_Promedio_P_Max * PorCiento_Comparacion_P_max_2s Or P_Min_Comparacion <= Valor_Promedio_P_Min * PorCiento_Comparacion_P_min)) Then
                                                        Vector_Valor_P_Max(0) = Vector_Valor_P_Max(1)
                                                        Vector_Valor_P_Max(1) = Vector_Valor_P_Max(2)
                                                        Vector_Valor_P_Max(2) = Vector_Valor_P_Max(3)
                                                        Vector_Valor_P_Max(3) = Vector_Valor_P_Max(4)
                                                        Vector_Valor_P_Max(4) = Vector_Valor_P_Max(5)
                                                        Vector_Valor_P_Max(5) = Vector_Valor_P_Max(6)
                                                        Vector_Valor_P_Max(6) = Vector_Valor_P_Max(7)
                                                        Vector_Valor_P_Max(7) = Vector_Valor_P_Max(8)
                                                        Vector_Valor_P_Max(8) = Vector_Valor_P_Max(9)
                                                        Vector_Valor_P_Max(9) = P_Max_Central
                                                        Valor_Promedio_P_Max = (Vector_Valor_P_Max(0) + Vector_Valor_P_Max(1) + Vector_Valor_P_Max(2) + Vector_Valor_P_Max(3) + Vector_Valor_P_Max(4) + Vector_Valor_P_Max(5) + Vector_Valor_P_Max(6) + Vector_Valor_P_Max(7) + Vector_Valor_P_Max(8) + Vector_Valor_P_Max(9)) / 10
                                                        If Cont_Limite_Repeticion_PorCiento_Comparacion_P_max_2s < Limite_Repeticion_PorCiento_Comparacion_P_max_2s Then
                                                            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion_P_max_2s
                                                        Else
                                                            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion_P_max
                                                        End If
                                                        Cont_Limite_Repeticion_PorCiento_Comparacion_P_max_2s = Cont_Limite_Repeticion_PorCiento_Comparacion_P_max_2s + 1

                                                        Tabla_Datos.Rows.Add(Puntero, Puntero_Q_i, Puntero_Q, Puntero_R, Puntero_S, Puntero_J, Tipo_QRS)
                                                        Puntero_Ultimo_J = Puntero_J
                                                        Puntero = Puntero + 1

                                                    Else
                                                        Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion_P_max_2s
                                                    End If
                                                Else
                                                    'Cuando el intervalo de busqueda esta entre  480ms y 2000ms 
                                                    If ((P_Max_Central <= Margen_Separacion_QRS_Ruido * Valor_Promedio_P_Max And P_Min_Comparacion >= Margen_Separacion_QRS_Ruido * Valor_Promedio_P_Min) And (P_Max_Central >= Valor_Promedio_P_Max * PorCiento_Comparacion_P_max Or P_Min_Comparacion <= Valor_Promedio_P_Min * PorCiento_Comparacion_P_min)) Then

                                                        Vector_Valor_P_Max(0) = Vector_Valor_P_Max(1)
                                                        Vector_Valor_P_Max(1) = Vector_Valor_P_Max(2)
                                                        Vector_Valor_P_Max(2) = Vector_Valor_P_Max(3)
                                                        Vector_Valor_P_Max(3) = Vector_Valor_P_Max(4)
                                                        Vector_Valor_P_Max(4) = Vector_Valor_P_Max(5)
                                                        Vector_Valor_P_Max(5) = Vector_Valor_P_Max(6)
                                                        Vector_Valor_P_Max(6) = Vector_Valor_P_Max(7)
                                                        Vector_Valor_P_Max(7) = Vector_Valor_P_Max(8)
                                                        Vector_Valor_P_Max(8) = Vector_Valor_P_Max(9)
                                                        Vector_Valor_P_Max(9) = P_Max_Central
                                                        Valor_Promedio_P_Max = (Vector_Valor_P_Max(0) + Vector_Valor_P_Max(1) + Vector_Valor_P_Max(2) + Vector_Valor_P_Max(3) + Vector_Valor_P_Max(4) + Vector_Valor_P_Max(5) + Vector_Valor_P_Max(6) + Vector_Valor_P_Max(7) + Vector_Valor_P_Max(8) + Vector_Valor_P_Max(9)) / 10
                                                        Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion_P_max
                                                        Tabla_Datos.Rows.Add(Puntero, Puntero_Q_i, Puntero_Q, Puntero_R, Puntero_S, Puntero_J, Tipo_QRS)
                                                        Puntero_Ultimo_J = Puntero_J
                                                        Puntero = Puntero + 1
                                                    Else
                                                        Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion_P_max
                                                    End If
                                                End If
                                            Else
                                                Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion_P_max
                                                Bandera_Desnivel_Detectado = 1
                                            End If
                                        Else
                                            Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion_P_max
                                            Bandera_Desnivel_Detectado = 1
                                        End If
                                    Else
                                        Valor_P_Max = Valor_Promedio_P_Max * PorCiento_Comparacion_P_max
                                        Bandera_Desnivel_Detectado = 1
                                    End If

                                    If Bandera_Desnivel_Detectado = 1 Then
                                        Bandera_Desnivel_Detectado = 0
                                        If Puntero_S = Puntero Then
                                            Index = Puntero_J - Puntero_Base + Separacion_Minima_QRS * Frecuencia
                                            Index_Inicio_Intervalo_Busqueda_Entre_QRS = Puntero_J - Puntero_Base + Separacion_Minima_QRS * Frecuencia
                                        Else
                                            Index = Puntero_J - Puntero_Base
                                            Index_Inicio_Intervalo_Busqueda_Entre_QRS = Puntero_J - Puntero_Base
                                        End If
                                    Else
                                        Index = Puntero_J - Puntero_Base + Separacion_Minima_QRS * Frecuencia
                                        Index_Inicio_Intervalo_Busqueda_Entre_QRS = Puntero_J - Puntero_Base + Separacion_Minima_QRS * Frecuencia
                                    End If


                                    If Puntero_Ultimo_J + Separacion_Minima_QRS * Frecuencia > 39488 Then
                                        Dim prueba = 0

                                    End If
                                    'Validar si se puede relisar mas busquedas de complejos QRS en ese intervalo
                                    If ((Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R) - Puntero_R) / Frecuencia < 0.48) Or (Index > Index_Fin_Intervalo_Busqueda_Entre_QRS) Then
                                        If Index_Tabla_Complejo_QRS + 1 < Cantidad_Leidos_Tabla_QRS Then
                                            Error_QRS = 1
                                        Else
                                            Error_QRS = 5
                                        End If
                                    End If
                                Case 1
                                    'Error_QRS = 0
                                    If Index_Tabla_Complejo_QRS + 1 < Cantidad_Leidos_Tabla_QRS Then
                                        Error_QRS = 1
                                    Else
                                        Error_QRS = 5
                                    End If

                                Case 2
                                    If Index_Tabla_Complejo_QRS + 1 < Cantidad_Leidos_Tabla_QRS Then
                                        Error_QRS = 1
                                    Else
                                        Error_QRS = 5
                                    End If

                                Case Else
                                    If Index_Tabla_Complejo_QRS + 1 < Cantidad_Leidos_Tabla_QRS Then
                                        Error_QRS = 1
                                    Else
                                        Error_QRS = 5
                                    End If
                            End Select
                        End While
                        'Error_QRS = 0

                        'If Error_QRS <> 5 Then
                        Tabla_Datos.Rows.Add(Puntero, Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS))
                        'Actualizar Segmentos_RR_Promedio 
                        Segmentos_RR(0) = Segmentos_RR(1)
                        Segmentos_RR(1) = Segmentos_RR(2)
                        Segmentos_RR(2) = Segmentos_RR(3)
                        Segmentos_RR(3) = Segmentos_RR(4)
                        Segmentos_RR(4) = Segmentos_RR(5)
                        Segmentos_RR(5) = Segmentos_RR(6)
                        Segmentos_RR(6) = Segmentos_RR(7)
                        Segmentos_RR(7) = Segmentos_RR(8)
                        Segmentos_RR(8) = Segmentos_RR(9)
                        Segmentos_RR(9) = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R) - Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS - 1)(R)

                        'Validar que el segmento RR no sea superior a 2s ni inferior a 0.24s
                        If Segmentos_RR(9) > 2 * Frecuencia Then
                            Segmentos_RR(9) = 2 * Frecuencia
                        ElseIf Segmentos_RR(9) < 0.24 * Frecuencia Then
                            Segmentos_RR(9) = 0.24 * Frecuencia
                        End If
                        Segmentos_RR_Promedio = (Segmentos_RR(0) + Segmentos_RR(1) + Segmentos_RR(2) + Segmentos_RR(3) + Segmentos_RR(4) + Segmentos_RR(5) + Segmentos_RR(6) + Segmentos_RR(7) + Segmentos_RR(8) + Segmentos_RR(9)) / 10

                        Puntero_Ultimo_J = Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J)
                        Puntero = Puntero + 1
                        Index_Tabla_Complejo_QRS = Index_Tabla_Complejo_QRS + 1

                        'Else
                        '    Tabla_Datos.Rows.Add(Puntero, Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS))
                        '    Puntero = Puntero + 1
                        '    Index_Tabla_Complejo_QRS = Index_Tabla_Complejo_QRS + 1

                        'End If



                    End While
                    'Index_Tabla_Complejo_QRS = Index_Tabla_Complejo_QRS + 1
                    'Tabla_Datos.Rows.Add(Puntero, Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Qi), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Q), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(R), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(S), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(J), Datos_Tabla_Complejo_QRS.Tables(0).Rows(Index_Tabla_Complejo_QRS)(Tipo_Complejo_QRS))
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If

                    'If Coneccion.State = 0 Then
                    '    Coneccion.Open()
                    '    Cmd_Copiar.DestinationTableName = Tabla_Almacenamiento_Resultados
                    '    Cmd_Copiar.WriteToServer(Tabla_Datos)
                    '    Tabla_Datos.Clear()
                    '    Tabla_Datos.AcceptChanges()
                    '    Coneccion.Close()
                    'Else
                    '    Cmd_Copiar.DestinationTableName = Tabla_Almacenamiento_Resultados
                    '    Cmd_Copiar.WriteToServer(Tabla_Datos)
                    '    Tabla_Datos.Clear()
                    '    Tabla_Datos.AcceptChanges()
                    'End If

                    Datos_Tabla_Complejo_QRS.Clear()
                    Datos_Tabla_Complejo_QRS.Dispose()
                    Datos_Tabla_Complejo_QRS.AcceptChanges()

                    Datos_Transformada_Wavelet.Clear()
                    Datos_Transformada_Wavelet.Dispose()
                    Datos_Transformada_Wavelet.AcceptChanges()

                    Datos_Tabla_Complejo_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Salida, Tabla_Complejo_QRS, "Q_i, Q, R, S, J,Tipo_QRS", Convert.ToString(Puntero_Complejo_QRS), Convert.ToString(Puntero_Complejo_QRS + Cantida_Datos))
                    Cantidad_Leidos_Tabla_QRS = Datos_Tabla_Complejo_QRS.Tables(0).Rows.Count
                    If Cantidad_Leidos_Tabla_QRS > 0 Then
                        Datos_Transformada_Wavelet = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Transformada_Wavelet, Nombre_Columna, Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(1)), Convert.ToString(Datos_Tabla_Complejo_QRS.Tables(0).Rows(Datos_Tabla_Complejo_QRS.Tables(0).Rows.Count - 1)(J)))
                        Puntero_Base = Datos_Tabla_Complejo_QRS.Tables(0).Rows(0)(1)
                    End If
                    Puntero_Complejo_QRS = Puntero_Complejo_QRS + Cantidad_Leidos_Tabla_QRS - 1
                    'Analisis par los casos cuando Q o S0 san igual a -1 

                    If Progreso.CancellationPending = True Then
                        'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
                        Tabla_Datos.Clear()
                        Tabla_Datos.Dispose()
                        Tabla_Datos.AcceptChanges()

                        Datos_Tabla_Complejo_QRS.Clear()
                        Datos_Tabla_Complejo_QRS.Dispose()
                        Datos_Tabla_Complejo_QRS.AcceptChanges()

                        Datos_Transformada_Wavelet.Clear()
                        Datos_Transformada_Wavelet.Dispose()
                        Datos_Transformada_Wavelet.AcceptChanges()

                        Return False
                    End If
                    Progreso.ReportProgress(Procedimiento_Busqueda_Complejo_QRS_No_Detectados * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + Puntero_Complejo_QRS / Max_Puntero * 100)

                End While


                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()

                Datos_Tabla_Complejo_QRS.Clear()
                Datos_Tabla_Complejo_QRS.Dispose()
                Datos_Tabla_Complejo_QRS.AcceptChanges()

                Datos_Transformada_Wavelet.Clear()
                Datos_Transformada_Wavelet.Dispose()
                Datos_Transformada_Wavelet.AcceptChanges()
            End If

            Return True
        End If
        Return True
    End Function
    Public Function Calculo_Intervalo_En_Una_Tabla(Coneccion As SqlConnection, Tabla_Origen_Principal As String, Columna_Tabla_Origen_Principal As String, Tabla_Almacenamiento_Resultados As String, Derivada As String, Frecuencia As Double, ByRef Progreso As BackgroundWorker)
        '------------------------------------------------
        'Calculo del intervalo en una misma Tabla(Tabla_Origen_Principal)
        'Esta funcion se utilisa para cacular la diferecia entre dos elementos
        'consecutivos de una columna(Columna_Tabla_Origen_Principal) idealmente el intervalo R-R
        '------------------------------------------------
        Const Cantida_Datos = 400 'Cantidad Maxima de datos alamcenadades para ser prosesada         Static Reset_Limite_Max_Min As Int32    'Limite de tiempo sin detectar un QRS para resetear  Limite_Max y Limite_Min

        Dim Datos_Tabla_Origen_Principal As DataSet
        Dim Max_Puntero As Int64 = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Origen_Principal)


        Dim Puntero As Int64 = 1
        Dim Puntero_Intervalo As Int64 = 0

        Dim Cantidad_Leidos_Tabla_QRS As Int64


        If Max_Puntero > 1 Then
            '------------------------------------------------
            'Creacion de Tabla de almacenamiento
            '------------------------------------------------
            Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
            Class_Funciones_Base_Datos.Registros_Crear_Tabla_Intervalo(Coneccion, Tabla_Almacenamiento_Resultados, Columna_Tabla_Origen_Principal, Columna_Tabla_Origen_Principal)
            '------------------------------------------------

            If Progreso.CancellationPending = True Then
                Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)
                Return False
            End If
            If Columna_Tabla_Origen_Principal = "R" Then
                Progreso.ReportProgress(Procedimiento_Calculo_Intervalo_RR * 100000 + Derivada_To_int(Derivada) * 1000 + Puntero_Intervalo / Max_Puntero * 100)
            Else
                Progreso.ReportProgress(Procedimiento_Calculo_Intervalo * 100000 + Derivada_To_int(Derivada) * 1000 + Puntero_Intervalo / Max_Puntero * 100)
            End If

            '------------------------------------------------
            'Creacion de Tabla de almacenamiento Temporal
            '------------------------------------------------
            Dim Cmd_Copiar As New SqlBulkCopy(Coneccion)
            Dim Tabla_Datos As New DataTable()
            Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
            Tabla_Datos.Columns.Add(New DataColumn("Inicio_" + Columna_Tabla_Origen_Principal + "_" + Columna_Tabla_Origen_Principal, GetType(System.Int32)))
            Tabla_Datos.Columns.Add(New DataColumn("Final_" + Columna_Tabla_Origen_Principal + "_" + Columna_Tabla_Origen_Principal, GetType(System.Int32)))
            Tabla_Datos.Columns.Add(New DataColumn(Columna_Tabla_Origen_Principal + "_" + Columna_Tabla_Origen_Principal, GetType(System.Int32)))
            '------------------------------------------------
            'Analisis de deteccion de los puntos
            '------------------------------------------------
            Datos_Tabla_Origen_Principal = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion, Tabla_Origen_Principal, Columna_Tabla_Origen_Principal, Convert.ToString(Puntero_Intervalo), Convert.ToString(Puntero_Intervalo + Cantida_Datos))
            Cantidad_Leidos_Tabla_QRS = Datos_Tabla_Origen_Principal.Tables(0).Rows.Count
            Puntero_Intervalo = 0
            Puntero = 0

            While Cantidad_Leidos_Tabla_QRS > 2
                '------------------------------------------------
                'Calculo del intervalo
                '------------------------------------------------
                While Puntero < Cantidad_Leidos_Tabla_QRS - 1
                    Puntero = Puntero + 1
                    Puntero_Intervalo = Puntero_Intervalo + 1
                    Tabla_Datos.Rows.Add(Puntero_Intervalo, Datos_Tabla_Origen_Principal.Tables(0).Rows(Puntero - 1)(1), Datos_Tabla_Origen_Principal.Tables(0).Rows(Puntero)(1), Datos_Tabla_Origen_Principal.Tables(0).Rows(Puntero)(1) - Datos_Tabla_Origen_Principal.Tables(0).Rows(Puntero - 1)(1))
                End While
                '------------------------------------------------
                'Almacenar Intervalos en la Base de datos
                '------------------------------------------------
                If Coneccion.State = 0 Then
                    Coneccion.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
                'If Coneccion.State = 0 Then
                '    Coneccion.Open()
                '    Cmd_Copiar.DestinationTableName = Tabla_Almacenamiento_Resultados
                '    Cmd_Copiar.WriteToServer(Tabla_Datos)
                '    Tabla_Datos.Clear()
                '    Tabla_Datos.AcceptChanges()
                '    Coneccion.Close()
                'Else
                '    Cmd_Copiar.DestinationTableName = Tabla_Almacenamiento_Resultados
                '    Cmd_Copiar.WriteToServer(Tabla_Datos)
                '    Tabla_Datos.Clear()
                '    Tabla_Datos.AcceptChanges()
                'End If
                '------------------------------------------------
                'Obtener nuevos datos para calcular el intervalo
                '------------------------------------------------
                Datos_Tabla_Origen_Principal.Clear()
                Datos_Tabla_Origen_Principal.Dispose()
                Datos_Tabla_Origen_Principal.AcceptChanges()
                Datos_Tabla_Origen_Principal = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion, Tabla_Origen_Principal, Columna_Tabla_Origen_Principal, Convert.ToString(Puntero_Intervalo), Convert.ToString(Puntero_Intervalo + Cantida_Datos))
                Cantidad_Leidos_Tabla_QRS = Datos_Tabla_Origen_Principal.Tables(0).Rows.Count

                Puntero = 1
                '------------------------------------------------
                'Validar si se canselo el procedimiento
                '------------------------------------------------
                If Progreso.CancellationPending = True Then
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados)

                    Cmd_Copiar.Close()

                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()

                    Datos_Tabla_Origen_Principal.Clear()
                    Datos_Tabla_Origen_Principal.Dispose()
                    Datos_Tabla_Origen_Principal.AcceptChanges()

                    Return False
                End If
                If Columna_Tabla_Origen_Principal = "R" Then
                    Progreso.ReportProgress(Procedimiento_Calculo_Intervalo_RR * 100000 + Derivada_To_int(Derivada) * 1000 + Puntero_Intervalo / Max_Puntero * 100)
                Else
                    Progreso.ReportProgress(Procedimiento_Calculo_Intervalo * 100000 + Derivada_To_int(Derivada) * 1000 + Puntero_Intervalo / Max_Puntero * 100)
                End If
            End While
            '------------------------------------------------
            'Liberar el espacio de las Tablas 
            '------------------------------------------------
            Cmd_Copiar.Close()

            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()

            Datos_Tabla_Origen_Principal.Clear()
            Datos_Tabla_Origen_Principal.Dispose()
            Datos_Tabla_Origen_Principal.AcceptChanges()

        End If

        Return True

    End Function
    Public Function Diseño_Filtro_Hamming(Tipo As Int16, Orden As Int16, Frecuencia_Muestreo As Double, Frecuencia_Corte_Baja As Double, Frecuencia_Corte_Alta As Double)
        'Elmargan de frecuencias esta modificado
        'Tipo=0 Filtro Pasa Baja 
        'Tipo=1 Filtro Pasa Alto 
        'Tipo=2 Filtro Pasa Banda 
        'Tipo=3 Filtro Para Banda 
        'Tipo=4 Filtro Notching
        Const Filtro_Pasa_Baja = 0
        Const Filtro_Pasa_Alto = 1
        Const Filtro_Pasa_Banda = 2
        Const Filtro_Para_Banda = 3
        Const Filtro_Notching = 4
        Dim fpa, fpb, wca, wcb As Double
        Dim hd(), h(), w() As Double
        Dim n() As Int16

        ReDim hd(Orden) 'Respuesta Infinita al Impulso
        ReDim h(Orden) 'Respuesta Finita al Impulso
        ReDim w(Orden) 'ventana  de  observación
        ReDim n(Orden) 'ventana  de  observación


        n(0) = -1 * Math.Floor(Orden / 2)
        For Index = 1 To Orden
            n(Index) = n(Index - 1) + 1
        Next Index


        Select Case Tipo
            Case Filtro_Pasa_Baja
                fpb = Frecuencia_Corte_Baja / Frecuencia_Muestreo + 0.25 / (2 * (Orden + 1))
                wcb = 2 * Math.PI * fpb 'Frecuencia de corte en radianes
                For Index = 0 To Orden
                    w(Index) = 0.54 - 0.46 * Math.Cos(2 * Math.PI * (Index) / (Orden + 1))
                    If (n(Index)) = 0 Then
                        hd(Index) = 2 * fpb
                    Else
                        hd(Index) = Math.Sin((n(Index)) * wcb) / ((n(Index)) * Math.PI)
                    End If
                    h(Index) = w(Index) * hd(Index)
                Next Index

            Case Filtro_Pasa_Alto
                fpb = Frecuencia_Corte_Baja / Frecuencia_Muestreo - 0.25 / (2 * (Orden + 1))
                wcb = 2 * Math.PI * fpb 'Frecuencia de corte en radianes

                For Index = 0 To Orden
                    w(Index) = 0.54 - 0.46 * Math.Cos(2 * Math.PI * (Index) / (Orden + 1))

                    If (n(Index)) = 0 Then
                        hd(Index) = 1 - 2 * fpb
                    Else

                        hd(Index) = (-1) * Math.Sin(n(Index) * wcb) / (n(Index) * Math.PI)
                    End If
                    h(Index) = w(Index) * hd(Index)
                Next Index

            Case Filtro_Pasa_Banda
                fpb = Frecuencia_Corte_Baja / Frecuencia_Muestreo - 0.25 / (2 * (Orden + 1))
                wcb = 2 * Math.PI * fpb 'Frecuencia de corte en radianes

                fpa = Frecuencia_Corte_Alta / Frecuencia_Muestreo + 0.25 / (2 * (Orden + 1))
                wca = 2 * Math.PI * fpa 'Frecuencia de corte en radianes

                For Index = 0 To Orden

                    w(Index) = 0.54 - 0.46 * Math.Cos(2 * Math.PI * (Index) / (Orden + 1))

                    If (n(Index)) = 0 Then
                        hd(Index) = 2 * (fpa - fpb)
                    Else
                        hd(Index) = (Math.Sin((n(Index)) * (wca)) - Math.Sin((n(Index)) * (wcb))) / ((n(Index)) * Math.PI)
                    End If
                    h(Index) = w(Index) * hd(Index)
                Next Index

            Case Filtro_Para_Banda
                fpb = Frecuencia_Corte_Baja / Frecuencia_Muestreo + 0.25 / (2 * (Orden + 1))
                wcb = 2 * Math.PI * fpb 'Frecuencia de corte en radianes

                fpa = Frecuencia_Corte_Alta / Frecuencia_Muestreo - 0.25 / (2 * (Orden + 1))
                wca = 2 * Math.PI * fpa 'Frecuencia de corte en radianes

                For Index = 0 To Orden
                    w(Index) = 0.54 - 0.46 * Math.Cos(2 * Math.PI * (Index) / (Orden + 1))

                    If (n(Index)) = 0 Then
                        hd(Index) = 1 - 2 * (fpa - fpb)
                    Else
                        hd(Index) = (Math.Sin((n(Index)) * (wcb)) - Math.Sin((n(Index)) * (wca))) / ((n(Index)) * Math.PI)
                    End If
                    h(Index) = w(Index) * hd(Index)
                Next Index

            Case Filtro_Notching
                fpb = Frecuencia_Corte_Baja / Frecuencia_Muestreo - 0.25 / (2 * (Orden + 1))
                wcb = 2 * Math.PI * fpb 'Frecuencia de corte en radianes

                fpa = Frecuencia_Corte_Baja / Frecuencia_Muestreo + 0.25 / (2 * (Orden + 1))
                wca = 2 * Math.PI * fpa 'Frecuencia de corte en radianes

                For Index = 0 To Orden
                    w(Index) = 0.54 - 0.46 * Math.Cos(2 * Math.PI * (Index) / (Orden + 1))
                    If (n(Index)) = 0 Then
                        hd(Index) = 1 - 2 * (fpa - fpb)
                    Else
                        hd(Index) = (Math.Sin((n(Index)) * (wcb)) - Math.Sin((n(Index)) * (wca))) / ((n(Index)) * Math.PI)
                    End If
                    h(Index) = w(Index) * hd(Index)
                Next Index
            Case Else

        End Select
        Return h


    End Function
    Public Function Diseño_Filtro_Barlett(Tipo As Int16, Orden As Int16, Frecuencia_Muestreo As Double, Frecuencia_Corte_Baja As Double, Frecuencia_Corte_Alta As Double)
        'El margen de frecuencias esta modificado
        'Tipo=0 Filtro Pasa Baja 
        'Tipo=1 Filtro Pasa Alto 
        'Tipo=2 Filtro Pasa Banda 
        'Tipo=3 Filtro Para Banda 
        'Tipo=4 Filtro Notching
        Const Filtro_Pasa_Baja = 0
        Const Filtro_Pasa_Alto = 1
        Const Filtro_Pasa_Banda = 2
        Const Filtro_Para_Banda = 3
        Const Filtro_Notching = 4
        Dim fpa, fpb, wca, wcb As Double
        Dim hd(), h(), w() As Double
        Dim n() As Int16

        ReDim hd(Orden) 'Respuesta Infinita al Impulso
        ReDim h(Orden) 'Respuesta Finita al Impulso
        ReDim w(Orden) 'ventana  de  observación
        ReDim n(Orden) 'ventana  de  observación


        n(0) = -1 * Math.Floor(Orden / 2)
        For Index = 1 To Orden
            n(Index) = n(Index - 1) + 1
        Next Index


        Select Case Tipo
            Case Filtro_Pasa_Baja
                fpb = Frecuencia_Corte_Baja / Frecuencia_Muestreo + 0.25 / (2 * (Orden + 1))
                wcb = 2 * Math.PI * fpb 'Frecuencia de corte en radianes
                For Index = 0 To Orden
                    If n(Index) <= 0 Then
                        w(Index) = 2 * (Index + 1) / (Orden + 1)
                    Else
                        w(Index) = 2 - 2 * (Index + 1) / (Orden + 1)
                    End If

                    If (n(Index)) = 0 Then
                        hd(Index) = 2 * fpb
                    Else
                        hd(Index) = Math.Sin((n(Index)) * wcb) / ((n(Index)) * Math.PI)
                    End If
                    h(Index) = w(Index) * hd(Index)
                Next Index

            Case Filtro_Pasa_Alto
                fpb = Frecuencia_Corte_Baja / Frecuencia_Muestreo - 0.25 / (2 * (Orden + 1))
                wcb = 2 * Math.PI * fpb 'Frecuencia de corte en radianes

                For Index = 0 To Orden
                    If n(Index) <= 0 Then
                        w(Index) = 2 * (Index + 1) / (Orden + 1)
                    Else
                        w(Index) = 2 - 2 * (Index + 1) / (Orden + 1)
                    End If

                    If (n(Index)) = 0 Then
                        hd(Index) = 1 - 2 * fpb
                    Else

                        hd(Index) = (-1) * Math.Sin(n(Index) * wcb) / (n(Index) * Math.PI)
                    End If
                    h(Index) = w(Index) * hd(Index)
                Next Index

            Case Filtro_Pasa_Banda
                fpb = Frecuencia_Corte_Baja / Frecuencia_Muestreo - 0.25 / (2 * (Orden + 1))
                wcb = 2 * Math.PI * fpb 'Frecuencia de corte en radianes

                fpa = Frecuencia_Corte_Alta / Frecuencia_Muestreo + 0.25 / (2 * (Orden + 1))
                wca = 2 * Math.PI * fpa 'Frecuencia de corte en radianes

                For Index = 0 To Orden

                    If n(Index) <= 0 Then
                        w(Index) = 2 * (Index + 1) / (Orden + 1)
                    Else
                        w(Index) = 2 - 2 * (Index + 1) / (Orden + 1)
                    End If

                    If (n(Index)) = 0 Then
                        hd(Index) = 2 * (fpa - fpb)
                    Else
                        hd(Index) = (Math.Sin((n(Index)) * (wca)) - Math.Sin((n(Index)) * (wcb))) / ((n(Index)) * Math.PI)
                    End If
                    h(Index) = w(Index) * hd(Index)
                Next Index

            Case Filtro_Para_Banda
                fpb = Frecuencia_Corte_Baja / Frecuencia_Muestreo + 0.25 / (2 * (Orden + 1))
                wcb = 2 * Math.PI * fpb 'Frecuencia de corte en radianes

                fpa = Frecuencia_Corte_Alta / Frecuencia_Muestreo - 0.25 / (2 * (Orden + 1))
                wca = 2 * Math.PI * fpa 'Frecuencia de corte en radianes

                For Index = 0 To Orden
                    If n(Index) <= 0 Then
                        w(Index) = 2 * (Index + 1) / (Orden + 1)
                    Else
                        w(Index) = 2 - 2 * (Index + 1) / (Orden + 1)
                    End If

                    If (n(Index)) = 0 Then
                        hd(Index) = 1 - 2 * (fpa - fpb)
                    Else
                        hd(Index) = (Math.Sin((n(Index)) * (wcb)) - Math.Sin((n(Index)) * (wca))) / ((n(Index)) * Math.PI)
                    End If
                    h(Index) = w(Index) * hd(Index)
                Next Index

            Case Filtro_Notching
                fpb = Frecuencia_Corte_Baja / Frecuencia_Muestreo - 0.25 / (2 * (Orden + 1))
                wcb = 2 * Math.PI * fpb 'Frecuencia de corte en radianes

                fpa = Frecuencia_Corte_Baja / Frecuencia_Muestreo + 0.25 / (2 * (Orden + 1))
                wca = 2 * Math.PI * fpa 'Frecuencia de corte en radianes

                For Index = 0 To Orden
                    If n(Index) <= 0 Then
                        w(Index) = 2 * (Index + 1) / (Orden + 1)
                    Else
                        w(Index) = 2 - 2 * (Index + 1) / (Orden + 1)
                    End If

                    If (n(Index)) = 0 Then
                        hd(Index) = 1 - 2 * (fpa - fpb)
                    Else
                        hd(Index) = (Math.Sin((n(Index)) * (wcb)) - Math.Sin((n(Index)) * (wca))) / ((n(Index)) * Math.PI)
                    End If
                    h(Index) = w(Index) * hd(Index)
                Next Index
            Case Else

        End Select
        Return h
    End Function

    'Public  Function FIltrado_Registro(Coneccion As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, ByRef Progreso As BackgroundWorker)
    Public Function Filtrado_Señal_500_Polos(ByRef Valor As String, ByRef Coeficientes_Filtro() As Double)
        'Funcion ausiliar de filtrado   con 500 coeficientes  
        Static Valores_Temp(500) As Double

        Dim Valor_Final, Lectura_Temp As Double
        Lectura_Temp = Valor
        Valor_Final = Coeficientes_Filtro(0) * Lectura_Temp + Valores_Temp(0)
        Valores_Temp(0) = Coeficientes_Filtro(1) * Lectura_Temp + Valores_Temp(1)
        Valores_Temp(1) = Coeficientes_Filtro(2) * Lectura_Temp + Valores_Temp(2)
        Valores_Temp(2) = Coeficientes_Filtro(3) * Lectura_Temp + Valores_Temp(3)
        Valores_Temp(3) = Coeficientes_Filtro(4) * Lectura_Temp + Valores_Temp(4)
        Valores_Temp(4) = Coeficientes_Filtro(5) * Lectura_Temp + Valores_Temp(5)
        Valores_Temp(5) = Coeficientes_Filtro(6) * Lectura_Temp + Valores_Temp(6)
        Valores_Temp(6) = Coeficientes_Filtro(7) * Lectura_Temp + Valores_Temp(7)
        Valores_Temp(7) = Coeficientes_Filtro(8) * Lectura_Temp + Valores_Temp(8)
        Valores_Temp(8) = Coeficientes_Filtro(9) * Lectura_Temp + Valores_Temp(9)
        Valores_Temp(9) = Coeficientes_Filtro(10) * Lectura_Temp + Valores_Temp(10)

        Valores_Temp(10) = Coeficientes_Filtro(11) * Lectura_Temp + Valores_Temp(11)
        Valores_Temp(11) = Coeficientes_Filtro(12) * Lectura_Temp + Valores_Temp(12)
        Valores_Temp(12) = Coeficientes_Filtro(13) * Lectura_Temp + Valores_Temp(13)
        Valores_Temp(13) = Coeficientes_Filtro(14) * Lectura_Temp + Valores_Temp(14)
        Valores_Temp(14) = Coeficientes_Filtro(15) * Lectura_Temp + Valores_Temp(15)
        Valores_Temp(15) = Coeficientes_Filtro(16) * Lectura_Temp + Valores_Temp(16)
        Valores_Temp(16) = Coeficientes_Filtro(17) * Lectura_Temp + Valores_Temp(17)
        Valores_Temp(17) = Coeficientes_Filtro(18) * Lectura_Temp + Valores_Temp(18)
        Valores_Temp(18) = Coeficientes_Filtro(19) * Lectura_Temp + Valores_Temp(19)
        Valores_Temp(19) = Coeficientes_Filtro(20) * Lectura_Temp + Valores_Temp(20)

        Valores_Temp(20) = Coeficientes_Filtro(21) * Lectura_Temp + Valores_Temp(21)
        Valores_Temp(21) = Coeficientes_Filtro(22) * Lectura_Temp + Valores_Temp(22)
        Valores_Temp(22) = Coeficientes_Filtro(23) * Lectura_Temp + Valores_Temp(23)
        Valores_Temp(23) = Coeficientes_Filtro(24) * Lectura_Temp + Valores_Temp(24)
        Valores_Temp(24) = Coeficientes_Filtro(25) * Lectura_Temp + Valores_Temp(25)
        Valores_Temp(25) = Coeficientes_Filtro(26) * Lectura_Temp + Valores_Temp(26)
        Valores_Temp(26) = Coeficientes_Filtro(27) * Lectura_Temp + Valores_Temp(27)
        Valores_Temp(27) = Coeficientes_Filtro(28) * Lectura_Temp + Valores_Temp(28)
        Valores_Temp(28) = Coeficientes_Filtro(29) * Lectura_Temp + Valores_Temp(29)
        Valores_Temp(29) = Coeficientes_Filtro(30) * Lectura_Temp + Valores_Temp(30)

        Valores_Temp(30) = Coeficientes_Filtro(31) * Lectura_Temp + Valores_Temp(31)
        Valores_Temp(31) = Coeficientes_Filtro(32) * Lectura_Temp + Valores_Temp(32)
        Valores_Temp(32) = Coeficientes_Filtro(33) * Lectura_Temp + Valores_Temp(33)
        Valores_Temp(33) = Coeficientes_Filtro(34) * Lectura_Temp + Valores_Temp(34)
        Valores_Temp(34) = Coeficientes_Filtro(35) * Lectura_Temp + Valores_Temp(35)
        Valores_Temp(35) = Coeficientes_Filtro(36) * Lectura_Temp + Valores_Temp(36)
        Valores_Temp(36) = Coeficientes_Filtro(37) * Lectura_Temp + Valores_Temp(37)
        Valores_Temp(37) = Coeficientes_Filtro(38) * Lectura_Temp + Valores_Temp(38)
        Valores_Temp(38) = Coeficientes_Filtro(39) * Lectura_Temp + Valores_Temp(39)
        Valores_Temp(39) = Coeficientes_Filtro(40) * Lectura_Temp + Valores_Temp(40)

        Valores_Temp(40) = Coeficientes_Filtro(41) * Lectura_Temp + Valores_Temp(41)
        Valores_Temp(41) = Coeficientes_Filtro(42) * Lectura_Temp + Valores_Temp(42)
        Valores_Temp(42) = Coeficientes_Filtro(43) * Lectura_Temp + Valores_Temp(43)
        Valores_Temp(43) = Coeficientes_Filtro(44) * Lectura_Temp + Valores_Temp(44)
        Valores_Temp(44) = Coeficientes_Filtro(45) * Lectura_Temp + Valores_Temp(45)
        Valores_Temp(45) = Coeficientes_Filtro(46) * Lectura_Temp + Valores_Temp(46)
        Valores_Temp(46) = Coeficientes_Filtro(47) * Lectura_Temp + Valores_Temp(47)
        Valores_Temp(47) = Coeficientes_Filtro(48) * Lectura_Temp + Valores_Temp(48)
        Valores_Temp(48) = Coeficientes_Filtro(49) * Lectura_Temp + Valores_Temp(49)
        Valores_Temp(49) = Coeficientes_Filtro(50) * Lectura_Temp + Valores_Temp(50)

        Valores_Temp(50) = Coeficientes_Filtro(51) * Lectura_Temp + Valores_Temp(51)
        Valores_Temp(51) = Coeficientes_Filtro(52) * Lectura_Temp + Valores_Temp(52)
        Valores_Temp(52) = Coeficientes_Filtro(53) * Lectura_Temp + Valores_Temp(53)
        Valores_Temp(53) = Coeficientes_Filtro(54) * Lectura_Temp + Valores_Temp(54)
        Valores_Temp(54) = Coeficientes_Filtro(55) * Lectura_Temp + Valores_Temp(55)
        Valores_Temp(55) = Coeficientes_Filtro(56) * Lectura_Temp + Valores_Temp(56)
        Valores_Temp(56) = Coeficientes_Filtro(57) * Lectura_Temp + Valores_Temp(57)
        Valores_Temp(57) = Coeficientes_Filtro(58) * Lectura_Temp + Valores_Temp(58)
        Valores_Temp(58) = Coeficientes_Filtro(59) * Lectura_Temp + Valores_Temp(59)
        Valores_Temp(59) = Coeficientes_Filtro(60) * Lectura_Temp + Valores_Temp(60)

        Valores_Temp(60) = Coeficientes_Filtro(61) * Lectura_Temp + Valores_Temp(61)
        Valores_Temp(61) = Coeficientes_Filtro(62) * Lectura_Temp + Valores_Temp(62)
        Valores_Temp(62) = Coeficientes_Filtro(63) * Lectura_Temp + Valores_Temp(63)
        Valores_Temp(63) = Coeficientes_Filtro(64) * Lectura_Temp + Valores_Temp(64)
        Valores_Temp(64) = Coeficientes_Filtro(65) * Lectura_Temp + Valores_Temp(65)
        Valores_Temp(65) = Coeficientes_Filtro(66) * Lectura_Temp + Valores_Temp(66)
        Valores_Temp(66) = Coeficientes_Filtro(67) * Lectura_Temp + Valores_Temp(67)
        Valores_Temp(67) = Coeficientes_Filtro(68) * Lectura_Temp + Valores_Temp(68)
        Valores_Temp(68) = Coeficientes_Filtro(69) * Lectura_Temp + Valores_Temp(69)
        Valores_Temp(69) = Coeficientes_Filtro(70) * Lectura_Temp + Valores_Temp(70)

        Valores_Temp(70) = Coeficientes_Filtro(71) * Lectura_Temp + Valores_Temp(71)
        Valores_Temp(71) = Coeficientes_Filtro(72) * Lectura_Temp + Valores_Temp(72)
        Valores_Temp(72) = Coeficientes_Filtro(73) * Lectura_Temp + Valores_Temp(73)
        Valores_Temp(73) = Coeficientes_Filtro(74) * Lectura_Temp + Valores_Temp(74)
        Valores_Temp(74) = Coeficientes_Filtro(75) * Lectura_Temp + Valores_Temp(75)
        Valores_Temp(75) = Coeficientes_Filtro(76) * Lectura_Temp + Valores_Temp(76)
        Valores_Temp(76) = Coeficientes_Filtro(77) * Lectura_Temp + Valores_Temp(77)
        Valores_Temp(77) = Coeficientes_Filtro(78) * Lectura_Temp + Valores_Temp(78)
        Valores_Temp(78) = Coeficientes_Filtro(79) * Lectura_Temp + Valores_Temp(79)
        Valores_Temp(79) = Coeficientes_Filtro(80) * Lectura_Temp + Valores_Temp(80)

        Valores_Temp(80) = Coeficientes_Filtro(81) * Lectura_Temp + Valores_Temp(81)
        Valores_Temp(81) = Coeficientes_Filtro(82) * Lectura_Temp + Valores_Temp(82)
        Valores_Temp(82) = Coeficientes_Filtro(83) * Lectura_Temp + Valores_Temp(83)
        Valores_Temp(83) = Coeficientes_Filtro(84) * Lectura_Temp + Valores_Temp(84)
        Valores_Temp(84) = Coeficientes_Filtro(85) * Lectura_Temp + Valores_Temp(85)
        Valores_Temp(85) = Coeficientes_Filtro(86) * Lectura_Temp + Valores_Temp(86)
        Valores_Temp(86) = Coeficientes_Filtro(87) * Lectura_Temp + Valores_Temp(87)
        Valores_Temp(87) = Coeficientes_Filtro(88) * Lectura_Temp + Valores_Temp(88)
        Valores_Temp(88) = Coeficientes_Filtro(89) * Lectura_Temp + Valores_Temp(89)
        Valores_Temp(89) = Coeficientes_Filtro(90) * Lectura_Temp + Valores_Temp(90)

        Valores_Temp(90) = Coeficientes_Filtro(91) * Lectura_Temp + Valores_Temp(91)
        Valores_Temp(91) = Coeficientes_Filtro(92) * Lectura_Temp + Valores_Temp(92)
        Valores_Temp(92) = Coeficientes_Filtro(93) * Lectura_Temp + Valores_Temp(93)
        Valores_Temp(93) = Coeficientes_Filtro(94) * Lectura_Temp + Valores_Temp(94)
        Valores_Temp(94) = Coeficientes_Filtro(95) * Lectura_Temp + Valores_Temp(95)
        Valores_Temp(95) = Coeficientes_Filtro(96) * Lectura_Temp + Valores_Temp(96)
        Valores_Temp(96) = Coeficientes_Filtro(97) * Lectura_Temp + Valores_Temp(97)
        Valores_Temp(97) = Coeficientes_Filtro(98) * Lectura_Temp + Valores_Temp(98)
        Valores_Temp(98) = Coeficientes_Filtro(99) * Lectura_Temp + Valores_Temp(99)
        Valores_Temp(99) = Coeficientes_Filtro(100) * Lectura_Temp + Valores_Temp(100)


        Valores_Temp(100) = Coeficientes_Filtro(101) * Lectura_Temp + Valores_Temp(101)
        Valores_Temp(101) = Coeficientes_Filtro(102) * Lectura_Temp + Valores_Temp(102)
        Valores_Temp(102) = Coeficientes_Filtro(103) * Lectura_Temp + Valores_Temp(103)
        Valores_Temp(103) = Coeficientes_Filtro(104) * Lectura_Temp + Valores_Temp(104)
        Valores_Temp(104) = Coeficientes_Filtro(105) * Lectura_Temp + Valores_Temp(105)
        Valores_Temp(105) = Coeficientes_Filtro(106) * Lectura_Temp + Valores_Temp(106)
        Valores_Temp(106) = Coeficientes_Filtro(107) * Lectura_Temp + Valores_Temp(107)
        Valores_Temp(107) = Coeficientes_Filtro(108) * Lectura_Temp + Valores_Temp(108)
        Valores_Temp(108) = Coeficientes_Filtro(109) * Lectura_Temp + Valores_Temp(109)
        Valores_Temp(109) = Coeficientes_Filtro(110) * Lectura_Temp + Valores_Temp(110)

        Valores_Temp(110) = Coeficientes_Filtro(111) * Lectura_Temp + Valores_Temp(111)
        Valores_Temp(111) = Coeficientes_Filtro(112) * Lectura_Temp + Valores_Temp(112)
        Valores_Temp(112) = Coeficientes_Filtro(113) * Lectura_Temp + Valores_Temp(113)
        Valores_Temp(113) = Coeficientes_Filtro(114) * Lectura_Temp + Valores_Temp(114)
        Valores_Temp(114) = Coeficientes_Filtro(115) * Lectura_Temp + Valores_Temp(115)
        Valores_Temp(115) = Coeficientes_Filtro(116) * Lectura_Temp + Valores_Temp(116)
        Valores_Temp(116) = Coeficientes_Filtro(117) * Lectura_Temp + Valores_Temp(117)
        Valores_Temp(117) = Coeficientes_Filtro(118) * Lectura_Temp + Valores_Temp(118)
        Valores_Temp(118) = Coeficientes_Filtro(119) * Lectura_Temp + Valores_Temp(119)
        Valores_Temp(119) = Coeficientes_Filtro(120) * Lectura_Temp + Valores_Temp(120)

        Valores_Temp(120) = Coeficientes_Filtro(121) * Lectura_Temp + Valores_Temp(121)
        Valores_Temp(121) = Coeficientes_Filtro(122) * Lectura_Temp + Valores_Temp(122)
        Valores_Temp(122) = Coeficientes_Filtro(123) * Lectura_Temp + Valores_Temp(123)
        Valores_Temp(123) = Coeficientes_Filtro(124) * Lectura_Temp + Valores_Temp(124)
        Valores_Temp(124) = Coeficientes_Filtro(125) * Lectura_Temp + Valores_Temp(125)
        Valores_Temp(125) = Coeficientes_Filtro(126) * Lectura_Temp + Valores_Temp(126)
        Valores_Temp(126) = Coeficientes_Filtro(127) * Lectura_Temp + Valores_Temp(127)
        Valores_Temp(127) = Coeficientes_Filtro(128) * Lectura_Temp + Valores_Temp(128)
        Valores_Temp(128) = Coeficientes_Filtro(129) * Lectura_Temp + Valores_Temp(129)
        Valores_Temp(129) = Coeficientes_Filtro(130) * Lectura_Temp + Valores_Temp(130)

        Valores_Temp(130) = Coeficientes_Filtro(131) * Lectura_Temp + Valores_Temp(131)
        Valores_Temp(131) = Coeficientes_Filtro(132) * Lectura_Temp + Valores_Temp(132)
        Valores_Temp(132) = Coeficientes_Filtro(133) * Lectura_Temp + Valores_Temp(133)
        Valores_Temp(133) = Coeficientes_Filtro(134) * Lectura_Temp + Valores_Temp(134)
        Valores_Temp(134) = Coeficientes_Filtro(135) * Lectura_Temp + Valores_Temp(135)
        Valores_Temp(135) = Coeficientes_Filtro(136) * Lectura_Temp + Valores_Temp(136)
        Valores_Temp(136) = Coeficientes_Filtro(137) * Lectura_Temp + Valores_Temp(137)
        Valores_Temp(137) = Coeficientes_Filtro(138) * Lectura_Temp + Valores_Temp(138)
        Valores_Temp(138) = Coeficientes_Filtro(139) * Lectura_Temp + Valores_Temp(139)
        Valores_Temp(139) = Coeficientes_Filtro(140) * Lectura_Temp + Valores_Temp(140)

        Valores_Temp(140) = Coeficientes_Filtro(141) * Lectura_Temp + Valores_Temp(141)
        Valores_Temp(141) = Coeficientes_Filtro(142) * Lectura_Temp + Valores_Temp(142)
        Valores_Temp(142) = Coeficientes_Filtro(143) * Lectura_Temp + Valores_Temp(143)
        Valores_Temp(143) = Coeficientes_Filtro(144) * Lectura_Temp + Valores_Temp(144)
        Valores_Temp(144) = Coeficientes_Filtro(145) * Lectura_Temp + Valores_Temp(145)
        Valores_Temp(145) = Coeficientes_Filtro(146) * Lectura_Temp + Valores_Temp(146)
        Valores_Temp(146) = Coeficientes_Filtro(147) * Lectura_Temp + Valores_Temp(147)
        Valores_Temp(147) = Coeficientes_Filtro(148) * Lectura_Temp + Valores_Temp(148)
        Valores_Temp(148) = Coeficientes_Filtro(149) * Lectura_Temp + Valores_Temp(149)
        Valores_Temp(149) = Coeficientes_Filtro(150) * Lectura_Temp + Valores_Temp(150)

        Valores_Temp(150) = Coeficientes_Filtro(151) * Lectura_Temp + Valores_Temp(151)
        Valores_Temp(151) = Coeficientes_Filtro(152) * Lectura_Temp + Valores_Temp(152)
        Valores_Temp(152) = Coeficientes_Filtro(153) * Lectura_Temp + Valores_Temp(153)
        Valores_Temp(153) = Coeficientes_Filtro(154) * Lectura_Temp + Valores_Temp(154)
        Valores_Temp(154) = Coeficientes_Filtro(155) * Lectura_Temp + Valores_Temp(155)
        Valores_Temp(155) = Coeficientes_Filtro(156) * Lectura_Temp + Valores_Temp(156)
        Valores_Temp(156) = Coeficientes_Filtro(157) * Lectura_Temp + Valores_Temp(157)
        Valores_Temp(157) = Coeficientes_Filtro(158) * Lectura_Temp + Valores_Temp(158)
        Valores_Temp(158) = Coeficientes_Filtro(159) * Lectura_Temp + Valores_Temp(159)
        Valores_Temp(159) = Coeficientes_Filtro(160) * Lectura_Temp + Valores_Temp(160)

        Valores_Temp(160) = Coeficientes_Filtro(161) * Lectura_Temp + Valores_Temp(161)
        Valores_Temp(161) = Coeficientes_Filtro(162) * Lectura_Temp + Valores_Temp(162)
        Valores_Temp(162) = Coeficientes_Filtro(163) * Lectura_Temp + Valores_Temp(163)
        Valores_Temp(163) = Coeficientes_Filtro(164) * Lectura_Temp + Valores_Temp(164)
        Valores_Temp(164) = Coeficientes_Filtro(165) * Lectura_Temp + Valores_Temp(165)
        Valores_Temp(165) = Coeficientes_Filtro(166) * Lectura_Temp + Valores_Temp(166)
        Valores_Temp(166) = Coeficientes_Filtro(167) * Lectura_Temp + Valores_Temp(167)
        Valores_Temp(167) = Coeficientes_Filtro(168) * Lectura_Temp + Valores_Temp(168)
        Valores_Temp(168) = Coeficientes_Filtro(169) * Lectura_Temp + Valores_Temp(169)
        Valores_Temp(169) = Coeficientes_Filtro(170) * Lectura_Temp + Valores_Temp(170)

        Valores_Temp(170) = Coeficientes_Filtro(171) * Lectura_Temp + Valores_Temp(171)
        Valores_Temp(171) = Coeficientes_Filtro(172) * Lectura_Temp + Valores_Temp(172)
        Valores_Temp(172) = Coeficientes_Filtro(173) * Lectura_Temp + Valores_Temp(173)
        Valores_Temp(173) = Coeficientes_Filtro(174) * Lectura_Temp + Valores_Temp(174)
        Valores_Temp(174) = Coeficientes_Filtro(175) * Lectura_Temp + Valores_Temp(175)
        Valores_Temp(175) = Coeficientes_Filtro(176) * Lectura_Temp + Valores_Temp(176)
        Valores_Temp(176) = Coeficientes_Filtro(177) * Lectura_Temp + Valores_Temp(177)
        Valores_Temp(177) = Coeficientes_Filtro(178) * Lectura_Temp + Valores_Temp(178)
        Valores_Temp(178) = Coeficientes_Filtro(179) * Lectura_Temp + Valores_Temp(179)
        Valores_Temp(179) = Coeficientes_Filtro(180) * Lectura_Temp + Valores_Temp(180)

        Valores_Temp(180) = Coeficientes_Filtro(181) * Lectura_Temp + Valores_Temp(181)
        Valores_Temp(181) = Coeficientes_Filtro(182) * Lectura_Temp + Valores_Temp(182)
        Valores_Temp(182) = Coeficientes_Filtro(183) * Lectura_Temp + Valores_Temp(183)
        Valores_Temp(183) = Coeficientes_Filtro(184) * Lectura_Temp + Valores_Temp(184)
        Valores_Temp(184) = Coeficientes_Filtro(185) * Lectura_Temp + Valores_Temp(185)
        Valores_Temp(185) = Coeficientes_Filtro(186) * Lectura_Temp + Valores_Temp(186)
        Valores_Temp(186) = Coeficientes_Filtro(187) * Lectura_Temp + Valores_Temp(187)
        Valores_Temp(187) = Coeficientes_Filtro(188) * Lectura_Temp + Valores_Temp(188)
        Valores_Temp(188) = Coeficientes_Filtro(189) * Lectura_Temp + Valores_Temp(189)
        Valores_Temp(189) = Coeficientes_Filtro(190) * Lectura_Temp + Valores_Temp(190)

        Valores_Temp(190) = Coeficientes_Filtro(191) * Lectura_Temp + Valores_Temp(191)
        Valores_Temp(191) = Coeficientes_Filtro(192) * Lectura_Temp + Valores_Temp(192)
        Valores_Temp(192) = Coeficientes_Filtro(193) * Lectura_Temp + Valores_Temp(193)
        Valores_Temp(193) = Coeficientes_Filtro(194) * Lectura_Temp + Valores_Temp(194)
        Valores_Temp(194) = Coeficientes_Filtro(195) * Lectura_Temp + Valores_Temp(195)
        Valores_Temp(195) = Coeficientes_Filtro(196) * Lectura_Temp + Valores_Temp(196)
        Valores_Temp(196) = Coeficientes_Filtro(197) * Lectura_Temp + Valores_Temp(197)
        Valores_Temp(197) = Coeficientes_Filtro(198) * Lectura_Temp + Valores_Temp(198)
        Valores_Temp(198) = Coeficientes_Filtro(199) * Lectura_Temp + Valores_Temp(199)
        Valores_Temp(199) = Coeficientes_Filtro(200) * Lectura_Temp + Valores_Temp(200)

        Valores_Temp(200) = Coeficientes_Filtro(201) * Lectura_Temp + Valores_Temp(201)
        Valores_Temp(201) = Coeficientes_Filtro(202) * Lectura_Temp + Valores_Temp(202)
        Valores_Temp(202) = Coeficientes_Filtro(203) * Lectura_Temp + Valores_Temp(203)
        Valores_Temp(203) = Coeficientes_Filtro(204) * Lectura_Temp + Valores_Temp(204)
        Valores_Temp(204) = Coeficientes_Filtro(205) * Lectura_Temp + Valores_Temp(205)
        Valores_Temp(205) = Coeficientes_Filtro(206) * Lectura_Temp + Valores_Temp(206)
        Valores_Temp(206) = Coeficientes_Filtro(207) * Lectura_Temp + Valores_Temp(207)
        Valores_Temp(207) = Coeficientes_Filtro(208) * Lectura_Temp + Valores_Temp(208)
        Valores_Temp(208) = Coeficientes_Filtro(209) * Lectura_Temp + Valores_Temp(209)
        Valores_Temp(209) = Coeficientes_Filtro(210) * Lectura_Temp + Valores_Temp(210)

        Valores_Temp(210) = Coeficientes_Filtro(211) * Lectura_Temp + Valores_Temp(211)
        Valores_Temp(211) = Coeficientes_Filtro(212) * Lectura_Temp + Valores_Temp(212)
        Valores_Temp(212) = Coeficientes_Filtro(213) * Lectura_Temp + Valores_Temp(213)
        Valores_Temp(213) = Coeficientes_Filtro(214) * Lectura_Temp + Valores_Temp(214)
        Valores_Temp(214) = Coeficientes_Filtro(215) * Lectura_Temp + Valores_Temp(215)
        Valores_Temp(215) = Coeficientes_Filtro(216) * Lectura_Temp + Valores_Temp(216)
        Valores_Temp(216) = Coeficientes_Filtro(217) * Lectura_Temp + Valores_Temp(217)
        Valores_Temp(217) = Coeficientes_Filtro(218) * Lectura_Temp + Valores_Temp(218)
        Valores_Temp(218) = Coeficientes_Filtro(219) * Lectura_Temp + Valores_Temp(219)
        Valores_Temp(219) = Coeficientes_Filtro(220) * Lectura_Temp + Valores_Temp(220)

        Valores_Temp(220) = Coeficientes_Filtro(221) * Lectura_Temp + Valores_Temp(221)
        Valores_Temp(221) = Coeficientes_Filtro(222) * Lectura_Temp + Valores_Temp(222)
        Valores_Temp(222) = Coeficientes_Filtro(223) * Lectura_Temp + Valores_Temp(223)
        Valores_Temp(223) = Coeficientes_Filtro(224) * Lectura_Temp + Valores_Temp(224)
        Valores_Temp(224) = Coeficientes_Filtro(225) * Lectura_Temp + Valores_Temp(225)
        Valores_Temp(225) = Coeficientes_Filtro(226) * Lectura_Temp + Valores_Temp(226)
        Valores_Temp(226) = Coeficientes_Filtro(227) * Lectura_Temp + Valores_Temp(227)
        Valores_Temp(227) = Coeficientes_Filtro(228) * Lectura_Temp + Valores_Temp(228)
        Valores_Temp(228) = Coeficientes_Filtro(229) * Lectura_Temp + Valores_Temp(229)
        Valores_Temp(229) = Coeficientes_Filtro(230) * Lectura_Temp + Valores_Temp(230)

        Valores_Temp(230) = Coeficientes_Filtro(231) * Lectura_Temp + Valores_Temp(231)
        Valores_Temp(231) = Coeficientes_Filtro(232) * Lectura_Temp + Valores_Temp(232)
        Valores_Temp(232) = Coeficientes_Filtro(233) * Lectura_Temp + Valores_Temp(233)
        Valores_Temp(233) = Coeficientes_Filtro(234) * Lectura_Temp + Valores_Temp(234)
        Valores_Temp(234) = Coeficientes_Filtro(235) * Lectura_Temp + Valores_Temp(235)
        Valores_Temp(235) = Coeficientes_Filtro(236) * Lectura_Temp + Valores_Temp(236)
        Valores_Temp(236) = Coeficientes_Filtro(237) * Lectura_Temp + Valores_Temp(237)
        Valores_Temp(237) = Coeficientes_Filtro(238) * Lectura_Temp + Valores_Temp(238)
        Valores_Temp(238) = Coeficientes_Filtro(239) * Lectura_Temp + Valores_Temp(239)
        Valores_Temp(239) = Coeficientes_Filtro(240) * Lectura_Temp + Valores_Temp(240)

        Valores_Temp(240) = Coeficientes_Filtro(241) * Lectura_Temp + Valores_Temp(241)
        Valores_Temp(241) = Coeficientes_Filtro(242) * Lectura_Temp + Valores_Temp(242)
        Valores_Temp(242) = Coeficientes_Filtro(243) * Lectura_Temp + Valores_Temp(243)
        Valores_Temp(243) = Coeficientes_Filtro(244) * Lectura_Temp + Valores_Temp(244)
        Valores_Temp(244) = Coeficientes_Filtro(245) * Lectura_Temp + Valores_Temp(245)
        Valores_Temp(245) = Coeficientes_Filtro(246) * Lectura_Temp + Valores_Temp(246)
        Valores_Temp(246) = Coeficientes_Filtro(247) * Lectura_Temp + Valores_Temp(247)
        Valores_Temp(247) = Coeficientes_Filtro(248) * Lectura_Temp + Valores_Temp(248)
        Valores_Temp(248) = Coeficientes_Filtro(249) * Lectura_Temp + Valores_Temp(249)
        Valores_Temp(249) = Coeficientes_Filtro(250) * Lectura_Temp + Valores_Temp(250)

        Valores_Temp(250) = Coeficientes_Filtro(251) * Lectura_Temp + Valores_Temp(251)
        Valores_Temp(251) = Coeficientes_Filtro(252) * Lectura_Temp + Valores_Temp(252)
        Valores_Temp(252) = Coeficientes_Filtro(253) * Lectura_Temp + Valores_Temp(253)
        Valores_Temp(253) = Coeficientes_Filtro(254) * Lectura_Temp + Valores_Temp(254)
        Valores_Temp(254) = Coeficientes_Filtro(255) * Lectura_Temp + Valores_Temp(255)
        Valores_Temp(255) = Coeficientes_Filtro(256) * Lectura_Temp + Valores_Temp(256)
        Valores_Temp(256) = Coeficientes_Filtro(257) * Lectura_Temp + Valores_Temp(257)
        Valores_Temp(257) = Coeficientes_Filtro(258) * Lectura_Temp + Valores_Temp(258)
        Valores_Temp(258) = Coeficientes_Filtro(259) * Lectura_Temp + Valores_Temp(259)
        Valores_Temp(259) = Coeficientes_Filtro(260) * Lectura_Temp + Valores_Temp(260)

        Valores_Temp(260) = Coeficientes_Filtro(261) * Lectura_Temp + Valores_Temp(261)
        Valores_Temp(261) = Coeficientes_Filtro(262) * Lectura_Temp + Valores_Temp(262)
        Valores_Temp(262) = Coeficientes_Filtro(263) * Lectura_Temp + Valores_Temp(263)
        Valores_Temp(263) = Coeficientes_Filtro(264) * Lectura_Temp + Valores_Temp(264)
        Valores_Temp(264) = Coeficientes_Filtro(265) * Lectura_Temp + Valores_Temp(265)
        Valores_Temp(265) = Coeficientes_Filtro(266) * Lectura_Temp + Valores_Temp(266)
        Valores_Temp(266) = Coeficientes_Filtro(267) * Lectura_Temp + Valores_Temp(267)
        Valores_Temp(267) = Coeficientes_Filtro(268) * Lectura_Temp + Valores_Temp(268)
        Valores_Temp(268) = Coeficientes_Filtro(269) * Lectura_Temp + Valores_Temp(269)
        Valores_Temp(269) = Coeficientes_Filtro(270) * Lectura_Temp + Valores_Temp(270)

        Valores_Temp(270) = Coeficientes_Filtro(271) * Lectura_Temp + Valores_Temp(271)
        Valores_Temp(271) = Coeficientes_Filtro(272) * Lectura_Temp + Valores_Temp(272)
        Valores_Temp(272) = Coeficientes_Filtro(273) * Lectura_Temp + Valores_Temp(273)
        Valores_Temp(273) = Coeficientes_Filtro(274) * Lectura_Temp + Valores_Temp(274)
        Valores_Temp(274) = Coeficientes_Filtro(275) * Lectura_Temp + Valores_Temp(275)
        Valores_Temp(275) = Coeficientes_Filtro(276) * Lectura_Temp + Valores_Temp(276)
        Valores_Temp(276) = Coeficientes_Filtro(277) * Lectura_Temp + Valores_Temp(277)
        Valores_Temp(277) = Coeficientes_Filtro(278) * Lectura_Temp + Valores_Temp(278)
        Valores_Temp(278) = Coeficientes_Filtro(279) * Lectura_Temp + Valores_Temp(279)
        Valores_Temp(279) = Coeficientes_Filtro(280) * Lectura_Temp + Valores_Temp(280)

        Valores_Temp(280) = Coeficientes_Filtro(281) * Lectura_Temp + Valores_Temp(281)
        Valores_Temp(281) = Coeficientes_Filtro(282) * Lectura_Temp + Valores_Temp(282)
        Valores_Temp(282) = Coeficientes_Filtro(283) * Lectura_Temp + Valores_Temp(283)
        Valores_Temp(283) = Coeficientes_Filtro(284) * Lectura_Temp + Valores_Temp(284)
        Valores_Temp(284) = Coeficientes_Filtro(285) * Lectura_Temp + Valores_Temp(285)
        Valores_Temp(285) = Coeficientes_Filtro(286) * Lectura_Temp + Valores_Temp(286)
        Valores_Temp(286) = Coeficientes_Filtro(287) * Lectura_Temp + Valores_Temp(287)
        Valores_Temp(287) = Coeficientes_Filtro(288) * Lectura_Temp + Valores_Temp(288)
        Valores_Temp(288) = Coeficientes_Filtro(289) * Lectura_Temp + Valores_Temp(289)
        Valores_Temp(289) = Coeficientes_Filtro(290) * Lectura_Temp + Valores_Temp(290)

        Valores_Temp(290) = Coeficientes_Filtro(291) * Lectura_Temp + Valores_Temp(291)
        Valores_Temp(291) = Coeficientes_Filtro(292) * Lectura_Temp + Valores_Temp(292)
        Valores_Temp(292) = Coeficientes_Filtro(293) * Lectura_Temp + Valores_Temp(293)
        Valores_Temp(293) = Coeficientes_Filtro(294) * Lectura_Temp + Valores_Temp(294)
        Valores_Temp(294) = Coeficientes_Filtro(295) * Lectura_Temp + Valores_Temp(295)
        Valores_Temp(295) = Coeficientes_Filtro(296) * Lectura_Temp + Valores_Temp(296)
        Valores_Temp(296) = Coeficientes_Filtro(297) * Lectura_Temp + Valores_Temp(297)
        Valores_Temp(297) = Coeficientes_Filtro(298) * Lectura_Temp + Valores_Temp(298)
        Valores_Temp(298) = Coeficientes_Filtro(299) * Lectura_Temp + Valores_Temp(299)
        Valores_Temp(299) = Coeficientes_Filtro(300) * Lectura_Temp + Valores_Temp(300)



        Valores_Temp(300) = Coeficientes_Filtro(301) * Lectura_Temp + Valores_Temp(301)
        Valores_Temp(301) = Coeficientes_Filtro(302) * Lectura_Temp + Valores_Temp(302)
        Valores_Temp(302) = Coeficientes_Filtro(303) * Lectura_Temp + Valores_Temp(303)
        Valores_Temp(303) = Coeficientes_Filtro(304) * Lectura_Temp + Valores_Temp(304)
        Valores_Temp(304) = Coeficientes_Filtro(305) * Lectura_Temp + Valores_Temp(305)
        Valores_Temp(305) = Coeficientes_Filtro(306) * Lectura_Temp + Valores_Temp(306)
        Valores_Temp(306) = Coeficientes_Filtro(307) * Lectura_Temp + Valores_Temp(307)
        Valores_Temp(307) = Coeficientes_Filtro(308) * Lectura_Temp + Valores_Temp(308)
        Valores_Temp(308) = Coeficientes_Filtro(309) * Lectura_Temp + Valores_Temp(309)
        Valores_Temp(309) = Coeficientes_Filtro(310) * Lectura_Temp + Valores_Temp(310)

        Valores_Temp(310) = Coeficientes_Filtro(311) * Lectura_Temp + Valores_Temp(311)
        Valores_Temp(311) = Coeficientes_Filtro(312) * Lectura_Temp + Valores_Temp(312)
        Valores_Temp(312) = Coeficientes_Filtro(313) * Lectura_Temp + Valores_Temp(313)
        Valores_Temp(313) = Coeficientes_Filtro(314) * Lectura_Temp + Valores_Temp(314)
        Valores_Temp(314) = Coeficientes_Filtro(315) * Lectura_Temp + Valores_Temp(315)
        Valores_Temp(315) = Coeficientes_Filtro(316) * Lectura_Temp + Valores_Temp(316)
        Valores_Temp(316) = Coeficientes_Filtro(317) * Lectura_Temp + Valores_Temp(317)
        Valores_Temp(317) = Coeficientes_Filtro(318) * Lectura_Temp + Valores_Temp(318)
        Valores_Temp(318) = Coeficientes_Filtro(319) * Lectura_Temp + Valores_Temp(319)
        Valores_Temp(319) = Coeficientes_Filtro(320) * Lectura_Temp + Valores_Temp(320)


        Valores_Temp(320) = Coeficientes_Filtro(321) * Lectura_Temp + Valores_Temp(321)
        Valores_Temp(321) = Coeficientes_Filtro(322) * Lectura_Temp + Valores_Temp(322)
        Valores_Temp(322) = Coeficientes_Filtro(323) * Lectura_Temp + Valores_Temp(323)
        Valores_Temp(323) = Coeficientes_Filtro(324) * Lectura_Temp + Valores_Temp(324)
        Valores_Temp(324) = Coeficientes_Filtro(325) * Lectura_Temp + Valores_Temp(325)
        Valores_Temp(325) = Coeficientes_Filtro(326) * Lectura_Temp + Valores_Temp(326)
        Valores_Temp(326) = Coeficientes_Filtro(327) * Lectura_Temp + Valores_Temp(327)
        Valores_Temp(327) = Coeficientes_Filtro(328) * Lectura_Temp + Valores_Temp(328)
        Valores_Temp(328) = Coeficientes_Filtro(329) * Lectura_Temp + Valores_Temp(329)
        Valores_Temp(329) = Coeficientes_Filtro(330) * Lectura_Temp + Valores_Temp(330)

        Valores_Temp(330) = Coeficientes_Filtro(331) * Lectura_Temp + Valores_Temp(331)
        Valores_Temp(331) = Coeficientes_Filtro(332) * Lectura_Temp + Valores_Temp(332)
        Valores_Temp(332) = Coeficientes_Filtro(333) * Lectura_Temp + Valores_Temp(333)
        Valores_Temp(333) = Coeficientes_Filtro(334) * Lectura_Temp + Valores_Temp(334)
        Valores_Temp(334) = Coeficientes_Filtro(335) * Lectura_Temp + Valores_Temp(335)
        Valores_Temp(335) = Coeficientes_Filtro(336) * Lectura_Temp + Valores_Temp(336)
        Valores_Temp(336) = Coeficientes_Filtro(337) * Lectura_Temp + Valores_Temp(337)
        Valores_Temp(337) = Coeficientes_Filtro(338) * Lectura_Temp + Valores_Temp(338)
        Valores_Temp(338) = Coeficientes_Filtro(339) * Lectura_Temp + Valores_Temp(339)
        Valores_Temp(339) = Coeficientes_Filtro(340) * Lectura_Temp + Valores_Temp(340)

        Valores_Temp(340) = Coeficientes_Filtro(341) * Lectura_Temp + Valores_Temp(341)
        Valores_Temp(341) = Coeficientes_Filtro(342) * Lectura_Temp + Valores_Temp(342)
        Valores_Temp(342) = Coeficientes_Filtro(343) * Lectura_Temp + Valores_Temp(343)
        Valores_Temp(343) = Coeficientes_Filtro(344) * Lectura_Temp + Valores_Temp(344)
        Valores_Temp(344) = Coeficientes_Filtro(345) * Lectura_Temp + Valores_Temp(345)
        Valores_Temp(345) = Coeficientes_Filtro(346) * Lectura_Temp + Valores_Temp(346)
        Valores_Temp(346) = Coeficientes_Filtro(347) * Lectura_Temp + Valores_Temp(347)
        Valores_Temp(347) = Coeficientes_Filtro(348) * Lectura_Temp + Valores_Temp(348)
        Valores_Temp(348) = Coeficientes_Filtro(349) * Lectura_Temp + Valores_Temp(349)
        Valores_Temp(349) = Coeficientes_Filtro(350) * Lectura_Temp + Valores_Temp(350)

        Valores_Temp(350) = Coeficientes_Filtro(351) * Lectura_Temp + Valores_Temp(351)
        Valores_Temp(351) = Coeficientes_Filtro(352) * Lectura_Temp + Valores_Temp(352)
        Valores_Temp(352) = Coeficientes_Filtro(353) * Lectura_Temp + Valores_Temp(353)
        Valores_Temp(353) = Coeficientes_Filtro(354) * Lectura_Temp + Valores_Temp(354)
        Valores_Temp(354) = Coeficientes_Filtro(355) * Lectura_Temp + Valores_Temp(355)
        Valores_Temp(355) = Coeficientes_Filtro(356) * Lectura_Temp + Valores_Temp(356)
        Valores_Temp(356) = Coeficientes_Filtro(357) * Lectura_Temp + Valores_Temp(357)
        Valores_Temp(357) = Coeficientes_Filtro(358) * Lectura_Temp + Valores_Temp(358)
        Valores_Temp(358) = Coeficientes_Filtro(359) * Lectura_Temp + Valores_Temp(359)
        Valores_Temp(359) = Coeficientes_Filtro(360) * Lectura_Temp + Valores_Temp(360)

        Valores_Temp(360) = Coeficientes_Filtro(361) * Lectura_Temp + Valores_Temp(361)
        Valores_Temp(361) = Coeficientes_Filtro(362) * Lectura_Temp + Valores_Temp(362)
        Valores_Temp(362) = Coeficientes_Filtro(363) * Lectura_Temp + Valores_Temp(363)
        Valores_Temp(363) = Coeficientes_Filtro(364) * Lectura_Temp + Valores_Temp(364)
        Valores_Temp(364) = Coeficientes_Filtro(365) * Lectura_Temp + Valores_Temp(365)
        Valores_Temp(365) = Coeficientes_Filtro(366) * Lectura_Temp + Valores_Temp(366)
        Valores_Temp(366) = Coeficientes_Filtro(367) * Lectura_Temp + Valores_Temp(367)
        Valores_Temp(367) = Coeficientes_Filtro(368) * Lectura_Temp + Valores_Temp(368)
        Valores_Temp(368) = Coeficientes_Filtro(369) * Lectura_Temp + Valores_Temp(369)
        Valores_Temp(369) = Coeficientes_Filtro(370) * Lectura_Temp + Valores_Temp(370)

        Valores_Temp(370) = Coeficientes_Filtro(371) * Lectura_Temp + Valores_Temp(371)
        Valores_Temp(371) = Coeficientes_Filtro(372) * Lectura_Temp + Valores_Temp(372)
        Valores_Temp(372) = Coeficientes_Filtro(373) * Lectura_Temp + Valores_Temp(373)
        Valores_Temp(373) = Coeficientes_Filtro(374) * Lectura_Temp + Valores_Temp(374)
        Valores_Temp(374) = Coeficientes_Filtro(375) * Lectura_Temp + Valores_Temp(375)
        Valores_Temp(375) = Coeficientes_Filtro(376) * Lectura_Temp + Valores_Temp(376)
        Valores_Temp(376) = Coeficientes_Filtro(377) * Lectura_Temp + Valores_Temp(377)
        Valores_Temp(377) = Coeficientes_Filtro(378) * Lectura_Temp + Valores_Temp(378)
        Valores_Temp(378) = Coeficientes_Filtro(379) * Lectura_Temp + Valores_Temp(379)
        Valores_Temp(379) = Coeficientes_Filtro(380) * Lectura_Temp + Valores_Temp(380)

        Valores_Temp(380) = Coeficientes_Filtro(381) * Lectura_Temp + Valores_Temp(381)
        Valores_Temp(381) = Coeficientes_Filtro(382) * Lectura_Temp + Valores_Temp(382)
        Valores_Temp(382) = Coeficientes_Filtro(383) * Lectura_Temp + Valores_Temp(383)
        Valores_Temp(383) = Coeficientes_Filtro(384) * Lectura_Temp + Valores_Temp(384)
        Valores_Temp(384) = Coeficientes_Filtro(385) * Lectura_Temp + Valores_Temp(385)
        Valores_Temp(385) = Coeficientes_Filtro(386) * Lectura_Temp + Valores_Temp(386)
        Valores_Temp(386) = Coeficientes_Filtro(387) * Lectura_Temp + Valores_Temp(387)
        Valores_Temp(387) = Coeficientes_Filtro(388) * Lectura_Temp + Valores_Temp(388)
        Valores_Temp(388) = Coeficientes_Filtro(389) * Lectura_Temp + Valores_Temp(389)
        Valores_Temp(389) = Coeficientes_Filtro(390) * Lectura_Temp + Valores_Temp(390)

        Valores_Temp(390) = Coeficientes_Filtro(391) * Lectura_Temp + Valores_Temp(391)
        Valores_Temp(391) = Coeficientes_Filtro(392) * Lectura_Temp + Valores_Temp(392)
        Valores_Temp(392) = Coeficientes_Filtro(393) * Lectura_Temp + Valores_Temp(393)
        Valores_Temp(393) = Coeficientes_Filtro(394) * Lectura_Temp + Valores_Temp(394)
        Valores_Temp(394) = Coeficientes_Filtro(395) * Lectura_Temp + Valores_Temp(395)
        Valores_Temp(395) = Coeficientes_Filtro(396) * Lectura_Temp + Valores_Temp(396)
        Valores_Temp(396) = Coeficientes_Filtro(397) * Lectura_Temp + Valores_Temp(397)
        Valores_Temp(397) = Coeficientes_Filtro(398) * Lectura_Temp + Valores_Temp(398)
        Valores_Temp(398) = Coeficientes_Filtro(399) * Lectura_Temp + Valores_Temp(399)
        Valores_Temp(399) = Coeficientes_Filtro(400) * Lectura_Temp + Valores_Temp(400)


        Valores_Temp(400) = Coeficientes_Filtro(401) * Lectura_Temp + Valores_Temp(401)
        Valores_Temp(401) = Coeficientes_Filtro(402) * Lectura_Temp + Valores_Temp(402)
        Valores_Temp(402) = Coeficientes_Filtro(403) * Lectura_Temp + Valores_Temp(403)
        Valores_Temp(403) = Coeficientes_Filtro(404) * Lectura_Temp + Valores_Temp(404)
        Valores_Temp(404) = Coeficientes_Filtro(405) * Lectura_Temp + Valores_Temp(405)
        Valores_Temp(405) = Coeficientes_Filtro(406) * Lectura_Temp + Valores_Temp(406)
        Valores_Temp(406) = Coeficientes_Filtro(407) * Lectura_Temp + Valores_Temp(407)
        Valores_Temp(407) = Coeficientes_Filtro(408) * Lectura_Temp + Valores_Temp(408)
        Valores_Temp(408) = Coeficientes_Filtro(409) * Lectura_Temp + Valores_Temp(409)
        Valores_Temp(409) = Coeficientes_Filtro(410) * Lectura_Temp + Valores_Temp(410)

        Valores_Temp(410) = Coeficientes_Filtro(411) * Lectura_Temp + Valores_Temp(411)
        Valores_Temp(411) = Coeficientes_Filtro(412) * Lectura_Temp + Valores_Temp(412)
        Valores_Temp(412) = Coeficientes_Filtro(413) * Lectura_Temp + Valores_Temp(413)
        Valores_Temp(413) = Coeficientes_Filtro(414) * Lectura_Temp + Valores_Temp(414)
        Valores_Temp(414) = Coeficientes_Filtro(415) * Lectura_Temp + Valores_Temp(415)
        Valores_Temp(415) = Coeficientes_Filtro(416) * Lectura_Temp + Valores_Temp(416)
        Valores_Temp(416) = Coeficientes_Filtro(417) * Lectura_Temp + Valores_Temp(417)
        Valores_Temp(417) = Coeficientes_Filtro(418) * Lectura_Temp + Valores_Temp(418)
        Valores_Temp(418) = Coeficientes_Filtro(419) * Lectura_Temp + Valores_Temp(419)
        Valores_Temp(419) = Coeficientes_Filtro(420) * Lectura_Temp + Valores_Temp(420)

        Valores_Temp(420) = Coeficientes_Filtro(421) * Lectura_Temp + Valores_Temp(421)
        Valores_Temp(421) = Coeficientes_Filtro(422) * Lectura_Temp + Valores_Temp(422)
        Valores_Temp(422) = Coeficientes_Filtro(423) * Lectura_Temp + Valores_Temp(423)
        Valores_Temp(423) = Coeficientes_Filtro(424) * Lectura_Temp + Valores_Temp(424)
        Valores_Temp(424) = Coeficientes_Filtro(425) * Lectura_Temp + Valores_Temp(425)
        Valores_Temp(425) = Coeficientes_Filtro(426) * Lectura_Temp + Valores_Temp(426)
        Valores_Temp(426) = Coeficientes_Filtro(427) * Lectura_Temp + Valores_Temp(427)
        Valores_Temp(427) = Coeficientes_Filtro(428) * Lectura_Temp + Valores_Temp(428)
        Valores_Temp(428) = Coeficientes_Filtro(429) * Lectura_Temp + Valores_Temp(429)
        Valores_Temp(429) = Coeficientes_Filtro(430) * Lectura_Temp + Valores_Temp(430)


        Valores_Temp(430) = Coeficientes_Filtro(431) * Lectura_Temp + Valores_Temp(431)
        Valores_Temp(431) = Coeficientes_Filtro(432) * Lectura_Temp + Valores_Temp(432)
        Valores_Temp(432) = Coeficientes_Filtro(433) * Lectura_Temp + Valores_Temp(433)
        Valores_Temp(433) = Coeficientes_Filtro(434) * Lectura_Temp + Valores_Temp(434)
        Valores_Temp(434) = Coeficientes_Filtro(435) * Lectura_Temp + Valores_Temp(435)
        Valores_Temp(435) = Coeficientes_Filtro(436) * Lectura_Temp + Valores_Temp(436)
        Valores_Temp(436) = Coeficientes_Filtro(437) * Lectura_Temp + Valores_Temp(437)
        Valores_Temp(437) = Coeficientes_Filtro(438) * Lectura_Temp + Valores_Temp(438)
        Valores_Temp(438) = Coeficientes_Filtro(439) * Lectura_Temp + Valores_Temp(439)
        Valores_Temp(439) = Coeficientes_Filtro(440) * Lectura_Temp + Valores_Temp(440)

        Valores_Temp(440) = Coeficientes_Filtro(441) * Lectura_Temp + Valores_Temp(441)
        Valores_Temp(441) = Coeficientes_Filtro(442) * Lectura_Temp + Valores_Temp(442)
        Valores_Temp(442) = Coeficientes_Filtro(443) * Lectura_Temp + Valores_Temp(443)
        Valores_Temp(443) = Coeficientes_Filtro(444) * Lectura_Temp + Valores_Temp(444)
        Valores_Temp(444) = Coeficientes_Filtro(445) * Lectura_Temp + Valores_Temp(445)
        Valores_Temp(445) = Coeficientes_Filtro(446) * Lectura_Temp + Valores_Temp(446)
        Valores_Temp(446) = Coeficientes_Filtro(447) * Lectura_Temp + Valores_Temp(447)
        Valores_Temp(447) = Coeficientes_Filtro(448) * Lectura_Temp + Valores_Temp(448)
        Valores_Temp(448) = Coeficientes_Filtro(449) * Lectura_Temp + Valores_Temp(449)
        Valores_Temp(449) = Coeficientes_Filtro(450) * Lectura_Temp + Valores_Temp(450)

        Valores_Temp(450) = Coeficientes_Filtro(451) * Lectura_Temp + Valores_Temp(451)
        Valores_Temp(451) = Coeficientes_Filtro(452) * Lectura_Temp + Valores_Temp(452)
        Valores_Temp(452) = Coeficientes_Filtro(453) * Lectura_Temp + Valores_Temp(453)
        Valores_Temp(453) = Coeficientes_Filtro(454) * Lectura_Temp + Valores_Temp(454)
        Valores_Temp(454) = Coeficientes_Filtro(455) * Lectura_Temp + Valores_Temp(455)
        Valores_Temp(455) = Coeficientes_Filtro(456) * Lectura_Temp + Valores_Temp(456)
        Valores_Temp(456) = Coeficientes_Filtro(457) * Lectura_Temp + Valores_Temp(457)
        Valores_Temp(457) = Coeficientes_Filtro(458) * Lectura_Temp + Valores_Temp(458)
        Valores_Temp(458) = Coeficientes_Filtro(459) * Lectura_Temp + Valores_Temp(459)
        Valores_Temp(459) = Coeficientes_Filtro(460) * Lectura_Temp + Valores_Temp(460)

        Valores_Temp(460) = Coeficientes_Filtro(461) * Lectura_Temp + Valores_Temp(461)
        Valores_Temp(461) = Coeficientes_Filtro(462) * Lectura_Temp + Valores_Temp(462)
        Valores_Temp(462) = Coeficientes_Filtro(463) * Lectura_Temp + Valores_Temp(463)
        Valores_Temp(463) = Coeficientes_Filtro(464) * Lectura_Temp + Valores_Temp(464)
        Valores_Temp(464) = Coeficientes_Filtro(465) * Lectura_Temp + Valores_Temp(465)
        Valores_Temp(465) = Coeficientes_Filtro(466) * Lectura_Temp + Valores_Temp(466)
        Valores_Temp(466) = Coeficientes_Filtro(467) * Lectura_Temp + Valores_Temp(467)
        Valores_Temp(467) = Coeficientes_Filtro(468) * Lectura_Temp + Valores_Temp(468)
        Valores_Temp(468) = Coeficientes_Filtro(469) * Lectura_Temp + Valores_Temp(469)
        Valores_Temp(469) = Coeficientes_Filtro(470) * Lectura_Temp + Valores_Temp(470)

        Valores_Temp(470) = Coeficientes_Filtro(471) * Lectura_Temp + Valores_Temp(471)
        Valores_Temp(471) = Coeficientes_Filtro(472) * Lectura_Temp + Valores_Temp(472)
        Valores_Temp(472) = Coeficientes_Filtro(473) * Lectura_Temp + Valores_Temp(473)
        Valores_Temp(473) = Coeficientes_Filtro(474) * Lectura_Temp + Valores_Temp(474)
        Valores_Temp(474) = Coeficientes_Filtro(475) * Lectura_Temp + Valores_Temp(475)
        Valores_Temp(475) = Coeficientes_Filtro(476) * Lectura_Temp + Valores_Temp(476)
        Valores_Temp(476) = Coeficientes_Filtro(477) * Lectura_Temp + Valores_Temp(477)
        Valores_Temp(477) = Coeficientes_Filtro(478) * Lectura_Temp + Valores_Temp(478)
        Valores_Temp(478) = Coeficientes_Filtro(479) * Lectura_Temp + Valores_Temp(479)
        Valores_Temp(479) = Coeficientes_Filtro(480) * Lectura_Temp + Valores_Temp(480)

        Valores_Temp(480) = Coeficientes_Filtro(481) * Lectura_Temp + Valores_Temp(481)
        Valores_Temp(481) = Coeficientes_Filtro(482) * Lectura_Temp + Valores_Temp(482)
        Valores_Temp(482) = Coeficientes_Filtro(483) * Lectura_Temp + Valores_Temp(483)
        Valores_Temp(483) = Coeficientes_Filtro(484) * Lectura_Temp + Valores_Temp(484)
        Valores_Temp(484) = Coeficientes_Filtro(485) * Lectura_Temp + Valores_Temp(485)
        Valores_Temp(485) = Coeficientes_Filtro(486) * Lectura_Temp + Valores_Temp(486)
        Valores_Temp(486) = Coeficientes_Filtro(487) * Lectura_Temp + Valores_Temp(487)
        Valores_Temp(487) = Coeficientes_Filtro(488) * Lectura_Temp + Valores_Temp(488)
        Valores_Temp(488) = Coeficientes_Filtro(489) * Lectura_Temp + Valores_Temp(489)
        Valores_Temp(489) = Coeficientes_Filtro(490) * Lectura_Temp + Valores_Temp(490)

        Valores_Temp(490) = Coeficientes_Filtro(491) * Lectura_Temp + Valores_Temp(491)
        Valores_Temp(491) = Coeficientes_Filtro(492) * Lectura_Temp + Valores_Temp(492)
        Valores_Temp(492) = Coeficientes_Filtro(493) * Lectura_Temp + Valores_Temp(493)
        Valores_Temp(493) = Coeficientes_Filtro(494) * Lectura_Temp + Valores_Temp(494)
        Valores_Temp(494) = Coeficientes_Filtro(495) * Lectura_Temp + Valores_Temp(495)
        Valores_Temp(495) = Coeficientes_Filtro(496) * Lectura_Temp + Valores_Temp(496)
        Valores_Temp(496) = Coeficientes_Filtro(497) * Lectura_Temp + Valores_Temp(497)
        Valores_Temp(497) = Coeficientes_Filtro(498) * Lectura_Temp + Valores_Temp(498)
        Valores_Temp(498) = Coeficientes_Filtro(499) * Lectura_Temp + Valores_Temp(499)
        Valores_Temp(499) = Coeficientes_Filtro(500) * Lectura_Temp

        Return Valor_Final
    End Function
    Public Function Filtrado_Registro_500_Polos_Face_Cero_Reset_Coeficientes()
        Dim Coeficientes_Filtro(500) As Double
        For i = 0 To 1000
            Filtrado_Señal_500_Polos(0, Coeficientes_Filtro)
        Next
    End Function

    Public Function Filtrado_Registro_500_Polos_Face_Cero(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String, ByRef Coeficientes_Filtro() As Double, Configuracion_Deteccion_QRS As Configuracion_Deteccion_QRS_1, ByRef Progreso As BackgroundWorker)
        'Funcion de filtrado obtimsada para el rango con 1000 coeficientes
        Dim Nombre_Base_Datos_Filtro_Temp As String = "Base_Datos_Filtro_Temp"
        Dim Coneccion_Base_Datos_Filtro_Temp As New SqlConnection
        Coneccion_Base_Datos_Filtro_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Nombre_Base_Datos_Filtro_Temp)


        Dim Cantidad_Datos_Max As Double = Configuracion_Deteccion_QRS.Cantida_Datos_TW  'Cantidad Maxima de datos leidas de para ser prosesada
        'Dim Cantidad_Datos_Max As Double = 500000  'Cantidad Maxima de datos leidas de para ser prosesada
        Const Correcion_Desplazamiento = 500 'Cantidad Maxima de datios prosesada de forma simultanea
        Dim Max_Puntero As Int64 = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Entrada, Tabla_Origen)
        Dim Tabla_Almacenamiento_Resultados_Temp_1 As String = "Datos_Filtro_Temp"
        Dim Tabla_Almacenamiento_Resultados_Temp_2 As String = Tabla_Almacenamiento_Resultados
        Dim Lectura_Temp As Double
        Dim Cantidad_Datos_Leidos As Int32
        Dim Puntero As Int32 = 0
        Dim Datos_Lectura_Registro As DataSet
        Dim Registro_Cont_Part As Int32 = 0

        'Tabla temporal para lamacenar los datos andes de envialos a la base de datos
        Dim Tabla_Datos As New DataTable()
        'Incerta las nuevas columnas de las derivaciones a calcula en tabla de datos
        Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
        Tabla_Datos.Columns.Add(New DataColumn(Nombre_Columna, GetType(System.Double)))

        If Progreso.CancellationPending = True Then
            Tabla_Datos.Clear()
            Tabla_Datos.Dispose()
            Tabla_Datos.AcceptChanges()

            Return False
        End If

        Progreso.ReportProgress(Procedimiento_Filtrando_Señal * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (0))
        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Filtro_Temp, Nombre_Base_Datos_Filtro_Temp)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1)
        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1, Nombre_Columna)

        'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados_Temp_2)
        'Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados_Temp_2, Nombre_Columna)


        Progreso.ReportProgress(Procedimiento_Filtrando_Señal * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + 0)
        Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max - 1))
        Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count - 1

        If Cantidad_Datos_Leidos > 1 Then
            'Iniciar el procesamiento
            If Progreso.CancellationPending = True Then
                'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados_Temp_2)
                Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1)
                Class_Funciones_Base_Datos.Eliminar_Base_Datos(Nombre_Base_Datos_Filtro_Temp)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Return False
            End If

            '----------------------------------------------------------------------------------
            'CACULAR PRIMERA MItAD DEL FILTRADO DE FASE CERO 
            While Cantidad_Datos_Leidos > 0 And (Puntero) <= Max_Puntero
                For Index = 0 To Cantidad_Datos_Leidos
                    Lectura_Temp = Filtrado_Señal_500_Polos(Datos_Lectura_Registro.Tables(0).Rows(Index)(1), Coeficientes_Filtro)
                    Tabla_Datos.Rows.Add(Puntero, Lectura_Temp)
                    Puntero = Puntero + 1
                Next Index

                'Guarda los datos en la base de datos 
                Try
                    If Coneccion_Base_Datos_Filtro_Temp.State = 0 Then
                        Coneccion_Base_Datos_Filtro_Temp.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1, Tabla_Datos)
                        Tabla_Datos.Clear()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                If Progreso.CancellationPending = True Then
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1)
                    Class_Funciones_Base_Datos.Eliminar_Base_Datos(Nombre_Base_Datos_Filtro_Temp)
                    'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados_Temp_1)
                    'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Tabla_Almacenamiento_Resultados_Temp_2)

                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Return False
                End If
                Progreso.ReportProgress(Procedimiento_Filtrando_Señal * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + (Puntero - 1) / Max_Puntero * 50)

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Entrada, Tabla_Origen, Nombre_Columna, Convert.ToString(Puntero), Convert.ToString(Puntero + Cantidad_Datos_Max))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count - 1
            End While
            'Coreccion del desplazamiento del filtro
            '-------------------------------------------------------------------------
            For Index = 0 To Correcion_Desplazamiento
                Lectura_Temp = Filtrado_Señal_500_Polos(0, Coeficientes_Filtro)
                Tabla_Datos.Rows.Add(Puntero, Lectura_Temp)
                Puntero = Puntero + 1
            Next Index

            Try
                If Coneccion_Base_Datos_Filtro_Temp.State = 0 Then
                    Coneccion_Base_Datos_Filtro_Temp.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1, Tabla_Datos)
                    Tabla_Datos.Clear()

                    Coneccion_Base_Datos_Filtro_Temp.Close()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            '-----------------------------------------------------------------------------------------------------------------------------------------------
            'CACULAR SEGUNDA MITAD DEL FILTRADO DE FASE CERO 
            Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados_Temp_2)
            Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados_Temp_2, Nombre_Columna)
            Registro_Cont_Part = 0
            Max_Puntero = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1)
            Puntero = Max_Puntero

            Datos_Lectura_Registro.Clear()
            Datos_Lectura_Registro.Dispose()
            Datos_Lectura_Registro.AcceptChanges()

            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1, Nombre_Columna, Convert.ToString(Puntero - Cantidad_Datos_Max), Convert.ToString(Puntero))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count - 1

            For Index = 0 To Correcion_Desplazamiento
                Lectura_Temp = Filtrado_Señal_500_Polos(Datos_Lectura_Registro.Tables(0).Rows(Cantidad_Datos_Leidos - Index)(1), Coeficientes_Filtro)
                Puntero = Puntero - 1
            Next Index
            'Realizar consulta de un registro en la Base de Datos
            For Index = Correcion_Desplazamiento + 1 To Cantidad_Datos_Leidos
                Tabla_Datos.Rows.Add()
            Next Index
            For Index = Correcion_Desplazamiento + 1 To Cantidad_Datos_Leidos
                Lectura_Temp = Filtrado_Señal_500_Polos(Datos_Lectura_Registro.Tables(0).Rows(Cantidad_Datos_Leidos - Index)(1), Coeficientes_Filtro)
                Tabla_Datos.Rows(Cantidad_Datos_Leidos - Index)(0) = Puntero
                Tabla_Datos.Rows(Cantidad_Datos_Leidos - Index)(1) = Lectura_Temp
                'Tabla_Datos.Rows.Add(Puntero, Lectura_Temp)
                Puntero = Puntero - 1
            Next Index
            'Almacenar datos 
            Try
                If Coneccion_Salida.State = 0 Then
                    Coneccion_Salida.Open()
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados_Temp_2, Tabla_Datos)
                    Tabla_Datos.Clear()
                    Coneccion_Salida.Close()
                Else
                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados_Temp_2, Tabla_Datos)
                    Tabla_Datos.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'Actualisar progreso
            If Progreso.CancellationPending = True Then
                Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1)
                Class_Funciones_Base_Datos.Eliminar_Base_Datos(Nombre_Base_Datos_Filtro_Temp)

                Tabla_Datos.Clear()
                Tabla_Datos.Dispose()
                Tabla_Datos.AcceptChanges()
                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()
                Return False
            End If
            Progreso.ReportProgress(Procedimiento_Filtrando_Señal * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + ((Max_Puntero - Puntero) / Max_Puntero * 50 + 50))

            'Actualisar progreso leer nuevos datos 
            Datos_Lectura_Registro.Clear()
            Datos_Lectura_Registro.Dispose()
            Datos_Lectura_Registro.AcceptChanges()

            Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1, Nombre_Columna, Convert.ToString(Puntero - Cantidad_Datos_Max), Convert.ToString(Puntero))
            Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count - 1

            While Cantidad_Datos_Leidos > 0 And (Puntero) > 0
                'Realizar consulta de un registro en la Base de Datos
                For Index = 0 To Cantidad_Datos_Leidos
                    Tabla_Datos.Rows.Add()
                Next Index

                'Realizar consulta de un registro en la Base de Datos
                For Index = 0 To Cantidad_Datos_Leidos
                    Lectura_Temp = Filtrado_Señal_500_Polos(Datos_Lectura_Registro.Tables(0).Rows(Cantidad_Datos_Leidos - Index)(1), Coeficientes_Filtro)
                    Tabla_Datos.Rows(Cantidad_Datos_Leidos - Index)(0) = Puntero
                    Tabla_Datos.Rows(Cantidad_Datos_Leidos - Index)(1) = Lectura_Temp
                    'Tabla_Datos.Rows.Add(Puntero, Lectura_Temp)
                    Puntero = Puntero - 1
                Next Index

                'Almacenar datos 
                Try
                    If Coneccion_Salida.State = 0 Then
                        Coneccion_Salida.Open()
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados_Temp_2, Tabla_Datos)
                        Tabla_Datos.Clear()
                        Coneccion_Salida.Close()
                    Else
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Salida, Tabla_Almacenamiento_Resultados_Temp_2, Tabla_Datos)
                        Tabla_Datos.Clear()
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Actualisar progreso
                If Progreso.CancellationPending = True Then
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1)
                    Class_Funciones_Base_Datos.Eliminar_Base_Datos(Nombre_Base_Datos_Filtro_Temp)
                    Tabla_Datos.Clear()
                    Tabla_Datos.Dispose()
                    Tabla_Datos.AcceptChanges()
                    Datos_Lectura_Registro.Clear()
                    Datos_Lectura_Registro.Dispose()
                    Datos_Lectura_Registro.AcceptChanges()
                    Return False
                End If
                Progreso.ReportProgress(Procedimiento_Filtrando_Señal * 100000 + Derivada_To_int(Nombre_Columna) * 1000 + ((Max_Puntero - Puntero) / Max_Puntero * 50 + 50))

                Datos_Lectura_Registro.Clear()
                Datos_Lectura_Registro.Dispose()
                Datos_Lectura_Registro.AcceptChanges()

                'Actualisar progreso leer nuevos datos 
                Datos_Lectura_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1, Nombre_Columna, Convert.ToString(Puntero - Cantidad_Datos_Max), Convert.ToString(Puntero))
                Cantidad_Datos_Leidos = Datos_Lectura_Registro.Tables(0).Rows.Count - 1
            End While

            '-------------------------------------------------------------------------
            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Salida, Tabla_Almacenamiento_Resultados)
            'Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion, Tabla_Almacenamiento_Resultados_Temp_2, Tabla_Almacenamiento_Resultados)
            Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Base_Datos_Filtro_Temp, Tabla_Almacenamiento_Resultados_Temp_1)
            Class_Funciones_Base_Datos.Eliminar_Base_Datos(Nombre_Base_Datos_Filtro_Temp)

        End If
        Tabla_Datos.Clear()
        Tabla_Datos.Dispose()
        Tabla_Datos.AcceptChanges()
        Datos_Lectura_Registro.Clear()
        Datos_Lectura_Registro.Dispose()
        Datos_Lectura_Registro.AcceptChanges()

        Return True
    End Function


End Class
