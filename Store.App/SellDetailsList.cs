using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Store.Models;
using Store.Repositories;

namespace Store.App
{
    public partial class SellDetailsList : ListForm<SellDetails, SellDetailsRepository>
    {
        protected int _sellId;

        public SellDetailsList(int sellId) : base(new SellDetailsRepository())
        {
            InitializeComponent();
            _sellId = sellId;
            Text = "Sell Details List";
        }

        public override void RefreshData()
        {
            Table = _repository.GetSellDetailsById(_sellId);
        }
    }
}
