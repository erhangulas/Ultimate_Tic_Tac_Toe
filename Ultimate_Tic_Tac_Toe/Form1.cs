using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ultimate_Tic_Tac_Toe
{
    public partial class Ultimate_Tic_Toc_Toe : Form
    {
        int[] result = new int[9];
        Button[,] tictactoe = new Button[9, 9];
        int bilgSonuc = 0;
        int yarisSonuc = 0;
        public Ultimate_Tic_Toc_Toe()
        {
            int i, j;
            for (i = 0; i < 9; i++)//arayüz oluşturuldu
            {
                result[i] = 0;
                for (j = 0; j < 9; j++)
                {
                    tictactoe[i, j] = new Button();
                    tictactoe[i, j].Location = new Point(160 + 50 * (j % 3) + 160 * (i % 3), 5 + 50 * (j / 3) + 160 * (i / 3));
                    tictactoe[i, j].BackColor = Color.Wheat;
                    tictactoe[i, j].Size = new Size(50, 50);
                    tictactoe[i, j].Click += new EventHandler(ClickButton);
                    tictactoe[i, j].Name = i + "" + j;
                    tictactoe[i, j].Font = new Font(this.Font.FontFamily, 26, this.Font.Style | FontStyle.Bold);
                    tictactoe[i, j].TabStop = false;
                    tictactoe[i, j].Text = " ";
                    this.Controls.Add(tictactoe[i, j]);
                }

            }
            InitializeComponent();
        }
        private void Ultimate_Tic_Toc_Toe_Load(object sender, EventArgs e)
        {
           
            lblBilgSonuc.ForeColor = Color.Red;
            lblYarisSonuc.ForeColor = Color.Green;
        }
        public void ClickButton(Object sender, System.EventArgs e)
        {
            Button buton = (Button)sender;
            buton.Text = "X";
            buton.Enabled = false;
            buton.ForeColor = Color.Green;
            int table = Convert.ToInt32(buton.Name) / 10;
            int position = Convert.ToInt32(buton.Name) % 10;
            
            check(table,"X");
            if (!Finished())
            {
                computer_turn(position);
            }
            
        }

        

        public Boolean Finished()
        {
            int x=1;
            for (int i = 0; i < 9; i=i+3)
            {
                if ((result[i] == result[i + 1]) && (result[i + 1] == result[i + 2]))
                {
                    if (result[i] == 1)
                    {
                        MessageBox.Show("Tebrikler Kazandınız!");
                        x = 0;
                    }
                    else if (result[i] == 2)
                    {
                        MessageBox.Show("Bilgisayar kazandı!");
                        x = 0;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if ((result[i] == result[i + 3]) && (result[i + 3] == result[i + 6]))
                {
                    if (result[i] == 1)
                    {
                        MessageBox.Show("Tebrikler Kazandınız!");
                        x = 0;
                    }
                    else if (result[i] == 2)
                    {
                        MessageBox.Show("Bilgisayar kazandı!");
                        x = 0;
                    }
                }
            }
            if((result[0]==result[4])&&(result[4]==result[8]))
            {
                if (result[0] == 1)
                {
                    MessageBox.Show("Tebrikler Kazandınız!");
                    x = 0;
                }
                else if (result[0] == 2)
                {
                    MessageBox.Show("Bilgisayar kazandı!");
                    x = 0;
                }
            }
            if ((result[2] == result[4]) && (result[4] == result[6]))
            {
                if (result[2] == 1)
                {
                    MessageBox.Show("Tebrikler Kazandınız!");
                    x = 0;
                }
                else if (result[2] == 2)
                {
                    MessageBox.Show("Bilgisayar kazandı!");
                    x = 0;
                }
            }
            
            if (x == 0) return true;
            int k = 0;
            int j=0;
                while(j<9 && k==0){
                    if (possibleMoves(j))k++ ;
                    j++;
                }
                if (k == 0)
                {
                    MessageBox.Show("Berabere bitti!");
                    return true;
                }
                else return false;
            
        }
        public void computer_turn(int position)
        {
            int[] heu = new int[81];
            int k, ind=0, min=99, hamle=0,x=0;
            if (possibleMoves(position)) //tabloda olası hareket var mı
            {
                for (int i = 0; i < 9; i++)
                {
                    if (tictactoe[position, i].Text.Equals(" "))//bos noktalara bak
                    {
                        if (result[i] != 0 && possibleMoves(i))//göndereceği tabloda kazanma durumu ve boş nokta var mı
                        {
                            hamle = i;
                            x++;
                            break;
                        }
                        else
                        {
                            k = heuristic(position, i);// değerimizi aldık
                            if (k < min)
                            {
                                ind = 0;
                                heu_clear(heu);
                                min = k;
                                heu[ind] = i;
                                ind++;
                            }
                            else if (k == min)
                            {
                                heu[ind] = i;
                                ind++;
                            }
                        }
                    }
                }
                min = 99;
                hamle = 0;
                if (x == 0)
                {
                    for (int i = 0; i < ind; i++)// aldığımız noktalar arasından en iyisi seçildi
                    {
                        if (result[heu[i]] != 0 && possibleMoves(heu[i]))
                        {
                            hamle = i;
                            x++;
                            break;
                        }
                        else
                        {
                            k = heuristic(heu[i], -1);
                            if (k < min)
                            {
                                min = k;
                                hamle = i;
                            }
                        }
                    }
                }
            }
            else//bilgisayarın oynayacağı karede boş nokta yok
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        
                        if (tictactoe[i, j].Text.Equals(" "))//9*9'luk karede tüm boş noktalara bakılarak en iyi nokta seçildi
                        {
                            k=heuristic(i, j);
                            if (k < min)
                            {
                                ind = 0;
                                heu_clear(heu);
                                min = k;
                                heu[ind] = i;
                                ind++;
                            }
                            else if (k == min)
                            {
                                heu[ind] = i;
                                ind++;
                            }
                        }
                    }
                }
                if (x == 0)
                {
                    min = 99;
                    hamle = 0;
                    for (int i = 0; i < ind; i++)
                    {
                        k = heuristic(heu[i], -1);
                        if (k < min)
                        {
                            min = k;
                            hamle = i;
                            position = i;
                        }
                    }
                }
            }
            tictactoe[position, heu[hamle]].Text = "O";
            tictactoe[position, heu[hamle]].Enabled = false;
            refreshTable();
            tictactoe[position, heu[hamle]].BackColor = Color.Brown;
            check(position, "O");
            if (!Finished())
            {
                if(!possibleMoves(heu[hamle]))
                openTable();
                else
                openT(heu[hamle]);
            }
        }

        private void refreshTable()// tabloda kahverengi ve mavi renkler temizlendi
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {                                            
                            switch (result[i])
                            {
                                case 0: tictactoe[i, j].BackColor = Color.Wheat; break;
                                case 1: tictactoe[i, j].BackColor = Color.Green; break;
                                case 2: tictactoe[i, j].BackColor = Color.Red; break;
                                default:
                                    break;
                            }                 
                }
            }
        }

        private void openT(int x)//küçük karede hamle yapılabilecek noktalar kullaıcıya gösterildi
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((i == x) && (tictactoe[i, j].Text.Equals(" ")))
                    {
                        tictactoe[i, j].Enabled = true;
                        tictactoe[i, j].BackColor = Color.CadetBlue;
                    }
                    else
                        tictactoe[i, j].Enabled = false;
                }
            }
        }

        private void openTable()// bilgisayarın gönderdiği kare doluysa tüm boş kutular kullanıcıya açılıyor
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((tictactoe[i, j].Text.Equals(" ")))
                    {
                        tictactoe[i, j].Enabled = true;
                        tictactoe[i, j].BackColor = Color.CadetBlue;
                    }
                    else
                        tictactoe[i, j].Enabled = false;
                }
            }
        }

        private Boolean possibleMoves(int p)//gidilen karede boş nokta var mı
        {
            int i=0, x=0;
            while ((x==0) && (i<9))
            {
                if (tictactoe[p, i].Text.Equals(" ")) x++;
                i++;
            }
            if (x != 0) return true;
            else return false;
        }

        private void heu_clear(int[] heu)// dizimiz sıfırlandı
        {
            for (int i = 0; i < 9; i++)
            {
                heu[i] = 0;
            }
        }

        private int heuristic(int position, int i)// minimax için değerlendirme fonksiyonumuz
        {
            int heuO=0,heuX=0;
            if (i>=0)
            tictactoe[position, i].Text="O";
            for (int j = 0; j < 9; j=j+3)
            {
                if ((!tictactoe[position, j].Text.Equals("X")) && (!tictactoe[position, j + 1].Text.Equals("X")) && (!tictactoe[position, j + 2].Text.Equals("X")))
                    if ((tictactoe[position, j].Text.Equals(tictactoe[position, j + 1])) || (tictactoe[position, j].Text.Equals(tictactoe[position, j + 2])) || (tictactoe[position, j + 2].Text.Equals(tictactoe[position, j + 1])))
                    {
                        if (tictactoe[position, j].Text.Equals("O") || tictactoe[position, j + 2].Text.Equals("O"))
                            heuO += 3;
                        else if (tictactoe[position, j].Text.Equals(" ") || tictactoe[position, j + 2].Text.Equals(" "))
                            heuO += 2;
                    }
                    else heuO++;
                else if ((!tictactoe[position, j].Text.Equals("O")) && (!tictactoe[position, j + 1].Text.Equals("O")) && (!tictactoe[position, j + 2].Text.Equals("O")))
                    if ((tictactoe[position, j].Text.Equals(tictactoe[position, j + 1])) || (tictactoe[position, j].Text.Equals(tictactoe[position, j + 2])) || (tictactoe[position, j + 2].Text.Equals(tictactoe[position, j + 1])))
                    {
                        if (tictactoe[position, j].Text.Equals("X") || tictactoe[position, j + 2].Text.Equals("X"))
                            heuX += 3;
                        else if (tictactoe[position, j].Text.Equals(" ") || tictactoe[position, j + 2].Text.Equals(" "))
                            heuX += 2;
                    }
                    else heuX++;
            }
            for (int j = 0; j < 3; j++)
            {
                if ((!tictactoe[position, j].Text.Equals("X")) && (!tictactoe[position, j + 3].Text.Equals("X")) && (!tictactoe[position, j + 6].Text.Equals("X")))
                    if ((tictactoe[position, j].Text.Equals(tictactoe[position, j + 3])) || (tictactoe[position, j].Text.Equals(tictactoe[position, j + 6])) || (tictactoe[position, j + 6].Text.Equals(tictactoe[position, j + 3])))
                    {
                        if (tictactoe[position, j].Text.Equals("O") || tictactoe[position, j + 6].Text.Equals("O"))
                            heuO += 3;
                        else if (tictactoe[position, j].Text.Equals(" ") || tictactoe[position, j + 6].Text.Equals(" "))
                            heuO += 2;
                    }
                    else heuO++;
                else if ((!tictactoe[position, j].Text.Equals("O")) && (!tictactoe[position, j + 3].Text.Equals("O")) && (!tictactoe[position, j + 6].Text.Equals("O")))
                    if ((tictactoe[position, j].Text.Equals(tictactoe[position, j + 3])) || (tictactoe[position, j].Text.Equals(tictactoe[position, j + 6])) || (tictactoe[position, j + 6].Text.Equals(tictactoe[position, j + 3])))
                    {
                        if (tictactoe[position, j].Text.Equals("X") || tictactoe[position, j + 6].Text.Equals("X"))
                            heuX += 3;
                        else if (tictactoe[position, j].Text.Equals(" ") || tictactoe[position, j + 6].Text.Equals(" "))
                            heuX += 2;
                    }
                    else heuX++;
            }
            if ((!tictactoe[position, 0].Text.Equals("X")) && (!tictactoe[position, 4].Text.Equals("X")) && (!tictactoe[position, 8].Text.Equals("X")))
                heuO++;
            else if ((!tictactoe[position, 0].Text.Equals("O")) && (!tictactoe[position, 4].Text.Equals("O")) && (!tictactoe[position, 8].Text.Equals("O")))
                heuX++;
            if ((!tictactoe[position, 2].Text.Equals("X")) && (!tictactoe[position, 4].Text.Equals("X")) && (!tictactoe[position, 6].Text.Equals("X")))
                heuO++;
            else if ((!tictactoe[position, 2].Text.Equals("O")) && (!tictactoe[position, 4].Text.Equals("O")) && (!tictactoe[position, 6].Text.Equals("O")))
                heuX++;
            if(i>=0)
            tictactoe[position, i].Text = " ";
            return heuX - heuO;
        }

      
        public void check(int table, string tas)//küçük karede kazanma durumu var mı
        {
            if (result[table] == 0)
            {
                for (int i = 0; i < 9; i = i + 3)
                {
                    if (tictactoe[table, i].Text.Equals(tictactoe[table, i + 1].Text) && tictactoe[table, i + 1].Text.Equals(tictactoe[table, i + 2].Text))
                    {
                        if (tictactoe[table, i].Text.Equals("X"))
                            result[table] = 1;
                        else if (tictactoe[table, i].Text.Equals("O"))
                            result[table] = 2;
                        colorTable(table,result[table]);
                        break;
                    }
                }
                if (result[table] == 0){
                for (int i = 0; i < 3; i++)
                {
                    if (tictactoe[table, i].Text.Equals(tictactoe[table, i + 3].Text) && tictactoe[table, i + 3].Text.Equals(tictactoe[table, i + 6].Text) )
                    {
                        if (tictactoe[table, i].Text.Equals("X"))
                            result[table] = 1;
                        else if (tictactoe[table, i].Text.Equals("O"))
                            result[table] = 2;
                        colorTable(table, result[table]);
                        break;
                    }
                }
                if (result[table] == 0){
                if (tictactoe[table, 0].Text.Equals(tictactoe[table, 4].Text) && tictactoe[table, 4].Text.Equals(tictactoe[table, 8].Text))
                {
                    if (tictactoe[table, 0].Text.Equals("X"))
                        result[table] = 1;
                    else if (tictactoe[table, 0].Text.Equals("O"))
                        result[table] = 2;
                    colorTable(table, result[table]);
                }
                if (result[table] == 0){
                if (tictactoe[table, 2].Text.Equals(tictactoe[table, 4].Text) && tictactoe[table, 4].Text.Equals(tictactoe[table, 6].Text))
                {
                    if (tictactoe[table, 2].Text.Equals("X"))
                        result[table] = 1;
                    else if (tictactoe[table, 2].Text.Equals("O"))
                        result[table] = 2;
                    colorTable(table, result[table]);
                }
                }
                }
            }
            }
            }

        private void colorTable(int table, int p)//tahtanın boyanması
        {
            if (p == 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    tictactoe[table, i].BackColor = Color.Green;
                }
                lblYarisSonuc.Text = (++yarisSonuc).ToString();
            }
            else if(p==2)
            {
                for (int i = 0; i < 9; i++)
                {
                    tictactoe[table, i].BackColor = Color.Red;
                }
                lblBilgSonuc.Text = (++bilgSonuc).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)//yeni oyun
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    tictactoe[i, j].Text = " ";
                    tictactoe[i, j].BackColor = Color.Wheat;
                    tictactoe[i, j].Enabled = true;
                }
                result[i] = 0;
                bilgSonuc = 0;
                yarisSonuc = 0;
                lblYarisSonuc.Text = " ";
                lblBilgSonuc.Text = " ";
               
                
            }
        }

        
        
    }
}
