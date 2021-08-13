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
    public partial class OrderDetailsList : ListForm<OrderDetails, OrderDetailsRepository>
    {
        private int _orderId;

        public OrderDetailsList(int orderId) : base(new OrderDetailsRepository())
        {
            InitializeComponent();
            _orderId = orderId;
        }

        public override void RefreshData()
        {
            Table = _repository.GetOrderDetailsById(_orderId);
        }
    }
}
