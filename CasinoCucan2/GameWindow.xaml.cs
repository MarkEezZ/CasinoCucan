using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace CasinoCucan2
{
    public partial class GameWindow : Window
    {
        Thickness[] marginList;
        TextBlock[] objectList;
        TextBlock[] lineElements;
        Label[] timerList;
        int[] valuesArr;
        int[] counterIterations;
        int generatedNumber;
        int bet = 0;
        bool betCondition = false;
        User user;
        SolidColorBrush brushBlack = new SolidColorBrush(Color.FromArgb(255, 12, 24, 21));
        SolidColorBrush brushGreen = new SolidColorBrush(Color.FromArgb(255, 21, 233, 126));
        SolidColorBrush brushWhite = new SolidColorBrush(Color.FromArgb(255, 211, 233, 230));
        SolidColorBrush brushGray = new SolidColorBrush(Color.FromArgb(255, 40, 40, 40));

        int whiteBetAmount = 0;
        int blackBetAmount = 0;
        int greenBetAmount = 0;

        public GameWindow(string gettedLogin, string gettedPass)
        {
            InitializeComponent();
            user = new User(gettedLogin, gettedPass);
            string userBalance;
            userBalance = File.ReadAllText("C:/Users/goog5/Desktop/My Github/CasinoCucan2/CasinoCucan2/userData/" + gettedLogin + "Balance.txt");
            user.Balance = Convert.ToInt32(userBalance);
            textBlockBalance.Text = Convert.ToString(user.Balance);

            getSpinMargins(spinNextNextNext, spinNextNext, spinNext, spinCurrent, spinBack, spinBackBack);
            getSpinObjects(spinNextNextNext, spinNextNext, spinNext, spinCurrent, spinBack, spinBackBack);
            getDivOf60();
            getCounterIterations();
            getTimerList(lab60, lab55, lab50, lab45, lab40, lab35, lab30, lab25, lab20, lab15, lab10, lab5, lab4, lab3, lab2, lab1);
            getLineElements(line0, line1, line2, line3, line4, line5, line6, line7, line8, line9, line10);
            spinFunc(marginList, lineElements, objectList, valuesArr, counterIterations);
        }

        async void spinFunc(Thickness[] marginList, TextBlock[] lineElements, TextBlock[] objectList, int[] valuesArr, int[] counterIterations)
        {
            int counterForValues;
            int value;
            int counter;
            int countIterationsSingle;
            int counterForLine = 0;

            string[,] startValuesArr;
            int counterToChangeText;
            int alterForIforText;
            bool spinStarter = true;

            while (spinStarter)
            {
                timerFunc(timerList);
                await Task.Delay(16000);
                //doubleArr2Check.Text = "";

                setGreenButton.IsEnabled = false;
                setWhiteButton.IsEnabled = false;
                setBlackButton.IsEnabled = false;

                generateNumberFunc();
                startValuesArr = findStartValue();

                counterForValues = 15;
                value = valuesArr[counterForValues];
                counter = 0;
                countIterationsSingle = counterIterations[counterForValues];

                counterToChangeText = 0;
                alterForIforText = 5;

                for (int i = 0; i < 6; i++)
                {
                    objectList[i].Text = "";
                    objectList[i].Margin = marginList[i];
                    objectList[i].Background = new SolidColorBrush(Color.FromArgb(255, 24, 24, 24));
                }

                while (counterForValues > 0)
                {
                    await Task.Delay(1);

                    for (int i = 0; i < 6; i++)
                    {

                        if (marginList[i].Left == 1285)
                        {
                            objectList[i].Text = startValuesArr[alterForIforText, counterToChangeText];
                            if (Convert.ToInt32(objectList[i].Text) % 2 == 0 && objectList[i].Text != "0")
                            {
                                objectList[i].Background = brushBlack;
                                objectList[i].Foreground = Brushes.White;
                            }
                            else if (Convert.ToInt32(objectList[i].Text) % 2 != 0 && objectList[i].Text != "0")
                            {
                                objectList[i].Background = brushWhite;
                                objectList[i].Foreground = Brushes.Black;
                            }
                            else
                            {
                                objectList[i].Background = brushGreen;
                                objectList[i].Foreground = Brushes.White;
                            }
                            alterForIforText--;
                        }
                        if (alterForIforText < 0)
                        {
                            alterForIforText = 5;
                        }

                        marginList[i].Left -= value;
                        objectList[i].Margin = marginList[i];

                        if (marginList[i].Left == 565)
                        {
                            marginList[i].Left = 1285;
                            if (i == 0)
                            {
                                counterToChangeText++;
                                if (counterToChangeText == 7)
                                {
                                    counterToChangeText = 0;
                                }
                            }
                        }

                        counter++;
                        if (counter == countIterationsSingle)
                        {
                            counterForValues--;
                            value = valuesArr[counterForValues];
                            countIterationsSingle = counterIterations[counterForValues];
                            counter = 0;
                        }
                    }
                }

                if (lineElements[0].Text == "" && counterForLine < 10)
                {
                    lineElements[0].Background = spinCurrent.Background;
                    lineElements[0].Foreground = spinCurrent.Foreground;
                    lineElements[0].Text = spinCurrent.Text;
                    counterForLine++;
                }

                else if (lineElements[0].Text != "" && counterForLine < 10)
                {
                    for (int j = 0; j < counterForLine; j++)
                    {
                        lineElements[counterForLine - j].Background = lineElements[counterForLine - j - 1].Background;
                        lineElements[counterForLine - j].Foreground = lineElements[counterForLine - j - 1].Foreground;
                        lineElements[counterForLine - j].Text = lineElements[counterForLine - j - 1].Text;
                    }
                    lineElements[0].Background = spinCurrent.Background;
                    lineElements[0].Foreground = spinCurrent.Foreground;
                    lineElements[0].Text = spinCurrent.Text;
                    counterForLine++;
                }
                else if (lineElements[0].Text != "" && counterForLine == 10)
                {
                    for (int j = 0; j < counterForLine; j++)
                    {
                        lineElements[counterForLine - j].Background = lineElements[counterForLine - j - 1].Background;
                        lineElements[counterForLine - j].Foreground = lineElements[counterForLine - j - 1].Foreground;
                        lineElements[counterForLine - j].Text = lineElements[counterForLine - j - 1].Text;
                    }
                    lineElements[0].Background = spinCurrent.Background;
                    lineElements[0].Foreground = spinCurrent.Foreground;
                    lineElements[0].Text = spinCurrent.Text;
                }

                if (currentColor.Fill == spinCurrent.Background)
                {
                    if (currentColor.Fill == brushBlack)
                    {
                        user.Balance += 2 * blackBetAmount;
                        textBlockBalance.Text = Convert.ToString(user.Balance);
                    }
                    else if (currentColor.Fill == brushWhite)
                    {
                        user.Balance += 2 * whiteBetAmount;
                        textBlockBalance.Text = Convert.ToString(user.Balance);
                    }
                    else
                    {
                        user.Balance += 14 * greenBetAmount;
                        textBlockBalance.Text = Convert.ToString(user.Balance);
                    }
                }                
                whiteBetAmount = 0;
                betWhite.Text = "0";

                blackBetAmount = 0;
                betBlack.Text = "0";

                greenBetAmount = 0;
                betGreen.Text = "0";

                currentBet.Text = Convert.ToString(bet);
                currentColor.Fill = brushGray;
                betCondition = false;

                setGreenButton.IsEnabled = true;
                setWhiteButton.IsEnabled = true;
                setBlackButton.IsEnabled = true;
            }
        }

        async void timerFunc(Label[] timerList)
        {
            Visibility vHidden = Visibility.Hidden;
            Visibility vVisible = Visibility.Visible;

            for (int i = 0; i < 16; i++)
            {
                await Task.Delay(1000);
                timerList[i].Visibility = vHidden;
            }

            for (int i = 0; i < 16; i++)
            {
                await Task.Delay(320);
                timerList[i].Visibility = vVisible;
            }
        }

        void getSpinMargins(FrameworkElement nextNextNext, FrameworkElement nextNext, FrameworkElement next,
        FrameworkElement current, FrameworkElement back, FrameworkElement backBack)
        {
            marginList = new Thickness[6];
            marginList[0] = nextNextNext.Margin;
            marginList[1] = nextNext.Margin;
            marginList[2] = next.Margin;
            marginList[3] = current.Margin;
            marginList[4] = back.Margin;
            marginList[5] = backBack.Margin;
        }

        void getSpinObjects(TextBlock nextNextNext, TextBlock nextNext, TextBlock next,
        TextBlock current, TextBlock back, TextBlock backBack)
        {
            objectList = new TextBlock[6];
            objectList[0] = nextNextNext;
            objectList[1] = nextNext;
            objectList[2] = next;
            objectList[3] = current;
            objectList[4] = back;
            objectList[5] = backBack;
        }

        void getDivOf60()
        { 
            //1, 2, 3, 4, 5, 6, 8, 10, 12, 15, 20, 24, 30, 40, 60, 120
            valuesArr = new int[16];
            int counter = 0;
            for (int i = 1; i <= 120; i++)
            {
                if (120 % i == 0)
                {
                    valuesArr[counter] = i;
                    counter++;
                }
            }
        }

        void getCounterIterations()
        {
            counterIterations = new int[16];
            counterIterations[0] = 720 * 1;
            counterIterations[1] = 360 * 1;
            counterIterations[2] = 240 * 1;
            counterIterations[3] = 180 * 1;
            counterIterations[4] = 144 * 1;
            counterIterations[5] = 120 * 2;
            counterIterations[6] = 90 * 2;
            counterIterations[7] = 72 * 2;
            counterIterations[8] = 60 * 2;
            counterIterations[9] = 48 * 3;
            counterIterations[10] = 36 * 3;
            counterIterations[11] = 30 * 3;
            counterIterations[12] = 24 * 3;
            counterIterations[13] = 18 * 4;
            counterIterations[14] = 12 * 4;
            counterIterations[15] = 6 * 4;
        }

        void getTimerList(Label lab60, Label lab55, Label lab50, Label lab45, Label lab40,
            Label lab35, Label lab30, Label lab25, Label lab20, Label lab15, Label lab10,
            Label lab5, Label lab4, Label lab3, Label lab2, Label lab1)
        {
            timerList = new Label[16];
            timerList[0] = lab60;
            timerList[1] = lab55;
            timerList[2] = lab50;
            timerList[3] = lab45;
            timerList[4] = lab40;
            timerList[5] = lab35;
            timerList[6] = lab30;
            timerList[7] = lab25;
            timerList[8] = lab20;
            timerList[9] = lab15;
            timerList[10] = lab10;
            timerList[11] = lab5;
            timerList[12] = lab4;
            timerList[13] = lab3;
            timerList[14] = lab2;
            timerList[15] = lab1;
        }

        void getLineElements(TextBlock line0, TextBlock line1, TextBlock line2, TextBlock line3, TextBlock line4,
                TextBlock line5, TextBlock line6, TextBlock line7, TextBlock line8, TextBlock line9, TextBlock line10)
        {
            lineElements = new TextBlock[11];
            lineElements[0] = line0;
            lineElements[1] = line1;
            lineElements[2] = line2;
            lineElements[3] = line3;
            lineElements[4] = line4;
            lineElements[5] = line5;
            lineElements[6] = line6;
            lineElements[7] = line7;
            lineElements[8] = line8;
            lineElements[9] = line9;
            lineElements[10] = line10;
        }

        void generateNumberFunc()
        {
            Random numberR = new Random();
            generatedNumber = numberR.Next(0, 19);
        }

        string[,] findStartValue()
        {
            int startValueInFunc = generatedNumber;
            int[] arr = new int[37];
            string[] arr2 = new string[42];
            string[ , ] arrDouble = new string[6, 7];
            string[ , ] arrDouble2 = new string[6, 7];

            for (int i = 0; i < 37; i++)
            {
                arr[i] = startValueInFunc;
                if (startValueInFunc == 0)
                {
                    startValueInFunc = 19;
                }
                startValueInFunc--;
            }
            startValueInFunc++;

            if (startValueInFunc == 1)
            {
                arr2[0] = "18";
                arr2[1] = "0";
            }
            else if (startValueInFunc == 0)
            {
                arr2[0] = "17";
                arr2[1] = "18";
            }
            else
            {
                arr2[0] = Convert.ToString(startValueInFunc - 2);
                arr2[1] = Convert.ToString(startValueInFunc - 1);
            }


            int counter = 36;
            for (int i = 2; i < 39; i++)
            {
                arr2[i] = Convert.ToString(arr[counter]);
                counter--;
            }


            if (startValueInFunc == 16)
            {
                arr2[39] = "17";
                arr2[40] = "18";
                arr2[41] = "0";
            }
            else if (startValueInFunc == 17)
            {
                arr2[39] = "18";
                arr2[40] = "0";
                arr2[41] = "1";
            }
            else if (startValueInFunc == 18)
            {
                arr2[39] = "0";
                arr2[40] = "1";
                arr2[41] = "2";
            }
            else
            {
                arr2[39] = Convert.ToString(generatedNumber + 1);
                arr2[40] = Convert.ToString(generatedNumber + 2);
                arr2[41] = Convert.ToString(generatedNumber + 3);
            }

            for (int i = 0; i < 6; i++)
            {
                int fillArrDouble = i;
                for (int j = 0; j < 7; j++)
                {
                    arrDouble[i, j] = arr2[fillArrDouble];
                    fillArrDouble += 6;
                }
            }

            int reverseCounter = 5;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    arrDouble2[i, j] = arrDouble[reverseCounter, j];
                }
                reverseCounter--;
            }
            return arrDouble2;
        }

        public void topUpButton_Click(object sender, RoutedEventArgs e)
        {
            TopUpWindow topUpOpenWindow = new TopUpWindow(user, textBlockBalance);
            topUpOpenWindow.Show();
        }

        private void setWhiteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(currentBet.Text) <= user.Balance)
            {
                if (betCondition == false)
                {
                    bet = Convert.ToInt32(currentBet.Text);
                    currentColor.Fill = brushWhite;

                    whiteBetAmount += bet;
                    betWhite.Text = Convert.ToString(whiteBetAmount);
                    user.Balance -= whiteBetAmount;
                    textBlockBalance.Text = Convert.ToString(user.Balance);
                    betCondition = true;
                }
                else
                {
                    MessageBox.Show("You cannot place a bet for more than one color.", "Error");
                }
            }
            else
            {
                MessageBox.Show("You have no so much money.", "Error");
            }
        }

        private void setGreenButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(currentBet.Text) <= user.Balance)
            {
                if (betCondition == false)
                {
                    bet = Convert.ToInt32(currentBet.Text);
                    currentColor.Fill = brushGreen;

                    greenBetAmount += bet;
                    betGreen.Text = Convert.ToString(greenBetAmount);
                    user.Balance -= greenBetAmount;
                    textBlockBalance.Text = Convert.ToString(user.Balance);
                    betCondition = true;
                }
                else
                {
                    MessageBox.Show("You cannot place a bet for more than one color.", "Error");
                }
            }
            else
            {
                MessageBox.Show("You have no so much money.", "Error");
            }
        }

        private void setBlackButton_Click(object sender, RoutedEventArgs e)
        {   
            if (Convert.ToInt32(currentBet.Text) <= user.Balance)
            {
                if (betCondition == false)
                {
                    bet = Convert.ToInt32(currentBet.Text);
                    currentColor.Fill = brushBlack;

                    blackBetAmount += bet;
                    betBlack.Text = Convert.ToString(blackBetAmount);
                    user.Balance -= blackBetAmount;
                    textBlockBalance.Text = Convert.ToString(user.Balance);
                    betCondition = true;
                }
                else
                {
                    MessageBox.Show("You cannot place a bet for more than one color.", "Error");
                }
            }
            else
            {
                MessageBox.Show("You have no so much money.", "Error");
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream stream = new FileStream("C:/Users/goog5/Desktop/My Github/CasinoCucan2/CasinoCucan2/userData/" + user.Login + "Balance.txt", FileMode.Open))
            {
                string balanceForFile = Convert.ToString(user.Balance);
                byte[] balanceForFileByte = Encoding.Default.GetBytes(balanceForFile);

                stream.Write(balanceForFileByte, 0, balanceForFileByte.Length);
            }
            Close();
        }
    }
}
