using KT09_LK_ProductList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT09_LK_ProductList {
    public partial class Form1 : Form {
        private List<Product> Products { get; set; }

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            rbBook.Checked = true;

            Products = new List<Product> {
                new CD {
                    Title = "Transformer",
                    Artist = "Lou Reed",
                    Id = 0,
                    LengthInMinutes = 40,
                    Price = 123
                },
                new Book {
                    Title = "Hitch Hiker's Guide to the Galaxy",
                    Author = "Douglas Adams",
                    NumPages = 400,
                    Id = 1,
                    Price = 250
                }
            };

            UpdateList();
        }

        private void UpdateList() {
            lvProducts.Items.Clear();

            foreach (var prod in Products) {
                lvProducts.Items.Add(
                    prod.ToListViewItem()
                );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var title = tbTitle.Text;
            var price = int.Parse(tbPrice.Text);
            var id = int.Parse(tbId.Text);

            var validated = false;
            if(ValidatePrice(price.ToString()) && ValidateTitle(title))
            {
                validated = true;
            }
            
            if (validated && rbBook.Checked == true)
            {
                var numPages = int.Parse(tbNumPages.Text);
                var author = tbAuthor.Text;

                Products.Add(new Book
                {
                    Title = title,
                    Author = author,
                    NumPages = numPages,
                    Id = id,
                    Price = price
                });
            }
            
            if(validated && rbCd.Checked == true)
            {
                var lengthInMin = int.Parse(tbLengthInMinutes.Text);
                var artist = tbArtist.Text;

                Products.Add(new CD
                {
                    Title = title,
                    Artist = artist,
                    Id = id,
                    LengthInMinutes = lengthInMin,
                    Price = price
                });
            }

            if(validated && rbGame.Checked == true)
            {
                var platform = tbPlatform.Text;

                Products.Add(new Game
                {
                    Title = title,
                    Price = price,
                    Platform = platform,
                    Id = id
                });

            }

            UpdateList();



        }

        private bool ValidateTitle(string title)
        {
            var isValid = false;
            if(title.Length > 3)
            {
                isValid = true;
            }
            return isValid;
        }

        private bool ValidatePrice(string price)
        {
            var isValid = false;
            if (int.TryParse(price, out int x) && price.Length > 2)
            {
                isValid = true;
            }
            return isValid;
        }

        private bool ValidateId(string id)
        {
            var isValid = false;
            if (int.TryParse(id, out int x) && id.Length > 1)
            {
                isValid = true;
            }
            return isValid;
        }

        private void rbBook_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBook.Checked == true)
            {
                lblArtist.Visible = false;
                lblLengthInMinutes.Visible = false;
                tbArtist.Visible = false;
                tbLengthInMinutes.Visible = false;
                tbPlatform.Visible = false;
                lblPlatform.Visible = false;

                tbAuthor.Visible = true;
                tbNumPages.Visible = true;
                lblAuthor.Visible = true;
                lblNumPages.Visible = true;
            }
        }

        private void rbCd_CheckedChanged(object sender, EventArgs e)
        {

            if (rbCd.Checked == true)
            {
                lblAuthor.Visible = false;
                lblNumPages.Visible = false;
                tbAuthor.Visible = false;
                tbNumPages.Visible = false;
                tbPlatform.Visible = false;
                lblPlatform.Visible = false;

                tbArtist.Visible = true;
                tbLengthInMinutes.Visible = true;
                lblArtist.Visible = true;
                lblLengthInMinutes.Visible = true;
            }
        }

        private void rbGame_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGame.Checked == true)
            {
                lblAuthor.Visible = false;
                lblNumPages.Visible = false;
                tbAuthor.Visible = false;
                tbNumPages.Visible = false;
                lblArtist.Visible = false;
                lblLengthInMinutes.Visible = false;
                tbArtist.Visible = false;
                tbLengthInMinutes.Visible = false;

                tbPlatform.Visible = true;
                lblPlatform.Visible = true;
            }
        }
    }
}
