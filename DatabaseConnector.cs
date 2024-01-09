using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution
{
    public class DatabaseConnector
    {
        private readonly string connectionString;

        public DatabaseConnector(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // 데이터베이스에 연결하는 메서드입니다.
        public void Connect()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
            }
        }

        // 주어진 trackingNumber 에 해당하는 상품들을 가져오는 메서드입니다.
        public DataTable GetItemsByTrackingNumber(string trackingNumber)
        {
            DataTable dtItems = new DataTable();

            string query = "SELECT oi.*, i.item_name, i.item_code FROM order_item oi JOIN item i ON oi.item_id = i.item_id WHERE oi.track_id = @TrackingNumber";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                adapter.Fill(dtItems);
            }

            return dtItems;
        }

        // 주어진 trackingNumber에 해당하는 TrackingInfo를 가져오는 메서드입니다.
        public TrackingInfo GetTrackingInfoByTrackingNumber(string trackingNumber)
        {
            TrackingInfo trackingInfo = new TrackingInfo();

            string query = "SELECT order_Id, order_item_status FROM order_item WHERE track_id = @TrackingNumber";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        trackingInfo.OrderId = reader["order_Id"].ToString(); // 주문번호
                        trackingInfo.OrderItemStatus = reader["order_item_status"].ToString(); // 상태
                    }
                }
            }

            return trackingInfo;
        }

        // orderId에 해당하는 주문의 상태를 업데이트하는 메서드입니다.
        public void UpdateOrderItemStatus(string orderId)
        {
            string query = "UPDATE order_item SET order_item_status = 'DELIVERY' WHERE order_Id = @OrderId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderId", orderId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // 정보를 담는 클래스입니다.
        public class TrackingInfo
        {
            public string OrderId { get; set; }
            public string OrderItemStatus { get; set; }
        }
    }
}