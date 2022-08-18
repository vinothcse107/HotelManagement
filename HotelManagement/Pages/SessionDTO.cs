namespace HotelManagement
{
    public class SessionDTO
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string role { get; set; }
        public string sid { get; set; }
    }
    public class WaiterOrderList
    {
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
    public class Orders
    {
        public int OrderId { get; set; }
    }
}