using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Distribution
{
    public partial class Main : Form
    {
        private readonly string connectionString = "Server=192.168.219.143;Port=3306;Database=B2B;Uid=root;Pwd=1234";
        private int Csum = 0; // 체크된 아이템의 수
        private bool isDataFetched = false; // 데이터를 가져왔는지 여부를 확인하는 플래그
        private string orderId; // 주문 ID
        private DatabaseConnector databaseConnector; // 데이터베이스 연결자

        public Main()
        {
            InitializeComponent();
            databaseConnector = new DatabaseConnector(connectionString); // 데이터베이스 연결자 초기화
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            databaseConnector.Connect(); // 데이터베이스 연결
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string trackingNumber = txtTrackingNumber.Text;

            DataTable dtItems = databaseConnector.GetItemsByTrackingNumber(trackingNumber); // 주문에 해당하는 아이템들을 가져옴
            DatabaseConnector.TrackingInfo trackingInfo = databaseConnector.GetTrackingInfoByTrackingNumber(trackingNumber); // 주문의 배송 정보를 가져옴

            if (string.IsNullOrEmpty(trackingInfo.OrderId) && !isDataFetched)
            {
                info.Text = "존재하지 않는 배송번호 입니다."; // 주문번호가 존재하지 않을 때
                return;
            }

            if (trackingInfo.OrderItemStatus == "DELIVERY" && !isDataFetched)
            {
                info.Text = "배송중인 주문입니다."; // 주문이 배송 중일 때
                return;
            }

            info.Text = "";

            if (!isDataFetched)
            {
                DisplayItems(dtItems); // 아이템들을 화면에 표시
                isDataFetched = true; // 데이터를 가져왔음을 표시
            }
            else
            {
                string barcode = txtTrackingNumber.Text;
                bool itemFound = false;

                foreach (ListViewItem item in listViewItems.Items)
                {
                    string itemBarcode = item.SubItems[1].Text;

                    if (itemBarcode == barcode && !item.Checked)
                    {
                        item.Checked = true; // 아이템 체크
                        orderId = item.SubItems[2].Text; // 주문 ID 설정
                        itemFound = true;
                        break;
                    }
                }

                if (!itemFound)
                {
                    info.Text = "목록에 상품이 없습니다."; // 아이템이 목록에 없을 때
                }
            }

            bool allItemsChecked = CheckAllItemsChecked(); // 모든 아이템이 체크되었는지 확인

            if (allItemsChecked)
            {
                databaseConnector.UpdateOrderItemStatus(orderId); // 주문 아이템 상태 업데이트
                info.Text = "배송완료"; // 배송 완료 메시지 표시
                Csum++; // 체크된 아이템 수 증가
                sum.Text = Csum.ToString(); // 총 체크된 아이템 수 표시
                isDataFetched = false; // 데이터를 다시 가져와야 함을 표시
            }
        }

        private bool CheckAllItemsChecked()
        {
            foreach (ListViewItem item in listViewItems.Items)
            {
                if (!item.Checked)
                {
                    return false;
                }
            }

            return true;
        }

        private void DisplayItems(DataTable dtItems)
        {
            listViewItems.Items.Clear();

            foreach (DataRow row in dtItems.Rows)
            {
                string itemName = row["Item_name"].ToString();
                string barcode = row["item_code"].ToString();
                string count = row["count"].ToString();
                string orderId = row["order_id"].ToString();

                for (int i = 0; i < Convert.ToInt32(count); i++)
                {
                    ListViewItem item = new ListViewItem(itemName);
                    item.SubItems.Add(barcode);
                    item.SubItems.Add(orderId);

                    listViewItems.Items.Add(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearItems(); // 아이템 목록 초기화
            Csum = 0; // 체크된 아이템 수 초기화
            sum.Text = "0"; // 총 체크된 아이템 수 표시 초기화
            isDataFetched = false; // 데이터를 다시 가져와야 함을 표시
        }

        private void ClearItems()
        {
            listViewItems.Items.Clear(); // 아이템 목록 초기화
        }

        private class TrackingInfo
        {
            public string OrderId { get; set; } // 주문 ID
            public string OrderItemStatus { get; set; } // 주문 아이템 상태
        }
    }
}