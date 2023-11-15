/*
 * Author: Jordi Sancho Garcia
 * M03. Programació UF1
 * v1. 15/11/2023
 * PR2. El joc del penjat
 *
 */

namespace GameProject
{
    public class SanchoJordiCode
    {
        public static void Main()
        {
            const string MSGUpWelcome = "**************************************";
            const string MSGWelcome = "******* Benvingut al AHORCADO ********";
            const string MSGDownWelcome = "**************************************";
            const string MSGChooseDif = "Si us plau, agafa el nivell de dificultat: ";
            const string MSGEasyOpt = "A. Fàcil";
            const string MSGNormalOpt = "B. Normal";
            const string MSGHardOpt = "C. Difícil";
            const string MSGExpertOpt = "D. Expert";
            const string MSGGetChoose = "Has agafat el nivell de dificultat";
            const string MSGClickForContinue = "Polsa una tecla per continuar...";
            const string MSGClickaLeter = "Tecleja una lletra (vocal o consonant) en majúscula";
            const string MSGNumTrys = "Número d'intents restants: ";
            const string MSGNumCountCorrect = "Número d’encerts: ";
            const string MSGEmptyTrys = "Has esgotat el número d'intens!";
            const string MSGGameOver = "S'ha acabat el joc!";
            const string MSGTheWordIs = "La paraula era:";
            const string MSGGetText = "Introdueix un text qualsevol:";
            const string MSGWinGame = "Felicitats! Has guanyat!";
            const int leveleasy = 7;
            const int levelnormal = 5;
            const int levelhard = 4;
            const int levelexpert = 3;
            int numtrysuser = 0, lenghtsecretword=0, numcountcorrect=0;
            bool gameover = false;
            string inputlvluser, inputletter, usertext;
            string secretword, secretwordoutAccents="", secretarrayword;

            string[,] picturehangman = {{"+","=","=","=","=","=","=","=","+"," "," "," "},
                                        {"|"," "," "," "," "," "," "," "," "," "," "," "},
                                        {"|"," "," "," "," "," "," "," "," "," "," "," "},
                                        {"|"," "," "," "," "," "," "," "," "," "," "," "},
                                        {"|"," "," "," "," "," "," "," "," "," "," "," "},
                                        {"|"," "," "," "," "," "," "," "," "," "," "," "},
                                        {"=","=","=","=","=","=","=","=","=","=","=","="}};

            char[,] letters = {{'A','B','C','D','E','F','G','H','I'},
                               {'J','K','L','M','N','Ñ','O','P','Q'},
                               {'R','S','T','U','V','W','X','Y','Z'}};

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(MSGUpWelcome);
            Console.WriteLine(MSGWelcome);
            Console.WriteLine(MSGDownWelcome);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(MSGChooseDif);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(MSGEasyOpt);
            Console.WriteLine(MSGNormalOpt);
            Console.WriteLine(MSGHardOpt);
            Console.WriteLine(MSGExpertOpt);
            Console.ResetColor();
            inputlvluser = Console.ReadLine();
            switch (inputlvluser.ToUpper())
            {
                case "A":
                    Console.WriteLine($"{MSGGetChoose} facil!");
                    numtrysuser = leveleasy;
                    lenghtsecretword = 8;
                    break;
                case "B":
                    Console.WriteLine($"{MSGGetChoose} normal!");
                    numtrysuser = levelnormal;
                    lenghtsecretword = 10;
                    break;
                case "C":
                    Console.WriteLine($"{MSGGetChoose} dificil!");
                    numtrysuser = levelhard;
                    lenghtsecretword = 10;
                    break;
                case "D":
                    Console.WriteLine($"{MSGGetChoose} expert!");
                    numtrysuser = levelexpert;
                    lenghtsecretword = 12;
                    break;
            }
            Console.WriteLine(MSGClickForContinue);
            Console.ReadKey();
            Console.Clear();

            /* Apartat agafar text de l'usuari i agafar la paraula oculta */
            char[] delimiter = { ' ', ',', '.', ':', '\f', '"', '\''};
            Console.WriteLine(MSGGetText);
            usertext = Console.ReadLine();
            bool foundword = false;
            string[] words = usertext.Split(delimiter);
            secretword = "";
            do
            {
                int numword = 0;
                while (numword < words.Length && !(foundword))
                {
                    if (words[numword].Length == lenghtsecretword)
                    {
                        secretword = words[numword];
                        foundword = true;
                    }
                    numword++;
                }
                lenghtsecretword--;
            } while (secretword == "" && lenghtsecretword != 0);

            /* Creo l'array on tindra las barras baixes dins del joc */
            char[] arraysecretword = new char[secretword.Length];
            for (int j = 0; j < secretword.Length; j++)
            {
                arraysecretword[j] = '_';
            }

            /* miro si la paraula escollida te accens en cas de que tingui li trec i poso la paraula amb majúscules*/
            for (int j = 0;j < secretword.Length; j++)
            {
                switch (secretword[j].ToString().ToUpper())
                {
                    case "Á":
                    case "À":
                    case "A":
                        secretwordoutAccents += "A";
                        break;
                    case "É":
                    case "È":
                    case "E":
                        secretwordoutAccents += "E";
                        break;
                    case "Í":
                    case "Ì":
                    case "I":
                    case "Ï":
                        secretwordoutAccents += "I";
                        break;
                    case "Ó":
                    case "Ò":
                    case "O":
                    case "Ö":
                        secretwordoutAccents += "O";
                        break;
                    case "Ú":
                    case "Ù":
                    case "Ü":
                    case "U":
                        secretwordoutAccents += "U";
                        break;
                    default:
                        secretwordoutAccents += secretword[j].ToString().ToUpper();
                        break;
                }
            }

            Console.Clear();

            /* Començament joc */
            while (!(gameover) && numtrysuser >= 0 && secretwordoutAccents != "")
            {
                Console.WriteLine($"{MSGNumCountCorrect}{numcountcorrect}");
                Console.WriteLine($"{MSGNumTrys}{numtrysuser}");
                Console.WriteLine();
                for (int i = 0; i < letters.GetLength(0); i++)
                {
                    for (int j = 0; j < letters.GetLength(1); j++)
                    {
                        Console.Write($"{letters[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                // printar barras bajas de la palabra escogida
                for (int l = 0; l < arraysecretword.Length; l++) 
                {
                    Console.Write($"{arraysecretword[l]} ");
                }
                Console.WriteLine();
                Console.WriteLine();
                // Dibuija cuadrat del ahoracado i depenent del nivell de dificultat d'una forma o d'una altre
                Console.ForegroundColor = ConsoleColor.Cyan;
                switch (inputlvluser.ToUpper())
                {
                    // Dins de cada cas mira en el numero de intents en el que es trova l'usuari per printarlo amb un estat o un altre
                    case "A":
                        switch (numtrysuser)
                        {
                            case 6:
                                picturehangman[1, 8] = "|";
                                break;
                            case 5:
                                picturehangman[2, 8] = "O";
                                break;
                            case 4:
                                picturehangman[3, 8] = "|";
                                break;
                            case 3:
                                picturehangman[3, 7] = "/";
                                break;
                            case 2:
                                picturehangman[3, 9] = @"\";
                                break;
                            case 1:
                                picturehangman[4, 7] = "/";
                                break;
                            case 0:
                                picturehangman[4, 9] = @"\";
                                break;
                        }
                        break;
                    case "B":
                        switch (numtrysuser)
                        {
                            case 4:
                                picturehangman[1, 8] = "|";
                                break;
                            case 3:
                                picturehangman[2, 8] = "O";
                                break;
                            case 2:
                                picturehangman[3, 8] = "|";
                                break;
                            case 1:
                                picturehangman[3, 7] = "/";
                                picturehangman[3, 9] = @"\";
                                break;
                            case 0:
                                picturehangman[4, 7] = "/";
                                picturehangman[4, 9] = @"\";
                                break;
                        }
                        break;
                    case "C":
                        switch (numtrysuser)
                        {
                            case 3:
                                picturehangman[1, 8] = "|";
                                break;
                            case 2:
                                picturehangman[2, 8] = "O";
                                break;
                            case 1:
                                picturehangman[3, 8] = "|";
                                picturehangman[3, 7] = "/";
                                picturehangman[3, 9] = @"\";
                                break;
                            case 0:
                                picturehangman[4, 7] = "/";
                                picturehangman[4, 9] = @"\";
                                break;
                        }
                        break;
                    case "D":
                        switch (numtrysuser)
                        {
                            case 2:
                                picturehangman[1, 8] = "|";
                                picturehangman[2, 8] = "O";
                                break;
                            case 1:
                                picturehangman[3, 8] = "|";
                                picturehangman[3, 7] = "/";
                                picturehangman[3, 9] = @"\";
                                break;
                            case 0:
                                picturehangman[4, 7] = "/";
                                picturehangman[4, 9] = @"\";
                                break;
                        }
                        break;
                }
                for (int i = 0; i < picturehangman.GetLength(0); i++)
                {
                    for (int j = 0; j < picturehangman.GetLength(1); j++)
                    {
                        Console.Write(picturehangman[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
                Console.WriteLine();
                if (numtrysuser != 0)
                {
                    Console.WriteLine(MSGClickaLeter);
                    inputletter = Console.ReadLine();
                    inputletter = inputletter.ToUpper();
                    /* comprova si dins de la paraula secreta conte la lletra introduida */
                    if (secretwordoutAccents.Contains(inputletter))
                    {
                        /* Actualitza la array amb barra baixa per que es vegui las lletres que estiguin dins de la paraula */
                        for (int p = 0; p < secretwordoutAccents.Length; p++)
                        {
                            if (inputletter[0] == secretwordoutAccents[p])
                            {
                                arraysecretword[p] = inputletter[0];
                            }
                        }

                        secretarrayword = "";
                        for (int h = 0; h < arraysecretword.Length; h++)
                        {
                            secretarrayword += arraysecretword[h];
                        }

                        if (secretarrayword == secretwordoutAccents)
                        {
                            Console.WriteLine();
                            Console.WriteLine(MSGWinGame);
                            Console.WriteLine($"{MSGTheWordIs}{secretwordoutAccents}");
                            Console.WriteLine(MSGClickForContinue);
                            Console.ReadKey();
                            gameover = true;
                        }
                        numcountcorrect++;
                    } else
                    {
                        numtrysuser--;
                    }
                    /* Borra las lletras utilitzades */
                    for (int i = 0; i < letters.GetLength(0); i++)
                    {
                        for (int j = 0; j < letters.GetLength(1); j++)
                        {
                            if (letters[i, j] == Convert.ToChar(inputletter))
                            {
                                letters[i, j] = ' ';
                            }
                        }
                    }
                } else
                {
                    Console.WriteLine(MSGEmptyTrys);
                    Console.WriteLine(MSGGameOver);
                    Console.WriteLine($"{MSGTheWordIs}{secretwordoutAccents}");
                    Console.WriteLine(MSGClickForContinue);
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
    }
}