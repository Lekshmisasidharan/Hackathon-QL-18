using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace SecretApplication
{
    public partial class PostVanpool : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public string GetLongitudeAndLatitude(string address, string sensor)
        {
            string urlAddress = "https://maps.googleapis.com/maps/api/geocode/xml?address=" + HttpUtility.UrlEncode(address) + "&key=AIzaSyAS0LV6iVW-gd-sjBRIu-fpFamhk4WaNzk";
            string returnValue = "";
            try
            {
                XmlDocument objXmlDocument = new XmlDocument();
                objXmlDocument.Load(urlAddress);
                XmlNodeList objXmlNodeList = objXmlDocument.SelectNodes("/GeocodeResponse/result/geometry/location");
                foreach (XmlNode objXmlNode in objXmlNodeList)
                {
                    // GET LONGITUDE 
                    returnValue = objXmlNode.ChildNodes.Item(0).InnerText;

                    // GET LATITUDE 
                    returnValue += "," + objXmlNode.ChildNodes.Item(1).InnerText;
                }
            }
            catch
            {
                // Process an error action here if needed  
            }
            return returnValue;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var Name = txtboxName.Text;
            var MorningStartingLocation = txtboxMrngLocation.Text + " " + txtboxMrngLocation2.Text;
            var MorningStartTime = txtboxPickUpTimeMrng.Text;
            var MorningArrivalTime = txtboxArrivalTimeMrng.Text;
            var EveningStartingLocation = txtboxEvngLocation.Text + " " + txtboxEvngLocation2.Text;
            var EveningStartTime = txtboxPickUpTimeEvng.Text;
            var EveningArrivalTime = txtboxArrivalTimeEvng.Text;
            var TotalSeats = txtBoxTotalSeats.Text;
            var AvailableSeats = TxtboxVacancies.Text;
            var PhoneNumber = Textboxpnnum.Text;

            var latlng = GetLongitudeAndLatitude(MorningStartingLocation, "false");
            string[] degs = latlng.Split(',');

            var latitude = degs[0];
            var longitude = degs[1];

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\lekshmi\\Hackethon\\Hackathon-QL-18\\SecretApplication\\SecretApplication\\App_Data\\Database1.mdf;Integrated Security=True";
            string query = "INSERT INTO VanData (MorningPickUpLocation, MorningStartTime, MorningArrivalTime, EveningPickUpLocation, EveningStartTime, EveningArrivalTime,TotalSeats,SeatsAvailable,Longitude,Latitude,PhoneNumber) " +
                   "VALUES (@MorningPickUpLocation, @MorningStartTime, @MorningArrivalTime, @EveningPickUpLocation, @EveningStartTime, @EveningArrivalTime, @TotalSeats,@SeatsAvailable,@Longitude,@Latitude,@PhoneNumber) ";

            // create connection and command
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                // define parameters and their values
                cmd.Parameters.Add("@MorningPickUpLocation", SqlDbType.VarChar, 500).Value = MorningStartingLocation;
                cmd.Parameters.Add("@MorningStartTime", SqlDbType.VarChar, 100).Value = MorningStartTime;
                cmd.Parameters.Add("@MorningArrivalTime", SqlDbType.VarChar, 100).Value = MorningArrivalTime;
                cmd.Parameters.Add("@EveningPickUpLocation", SqlDbType.VarChar, 500).Value = EveningStartingLocation;
                cmd.Parameters.Add("@EveningStartTime", SqlDbType.VarChar, 500).Value = EveningStartTime;
                cmd.Parameters.Add("@EveningArrivalTime", SqlDbType.VarChar, 500).Value = EveningArrivalTime;
                cmd.Parameters.Add("@TotalSeats", SqlDbType.Int).Value = TotalSeats;
                cmd.Parameters.Add("@SeatsAvailable", SqlDbType.Int).Value = AvailableSeats;
                cmd.Parameters.Add("@Longitude", SqlDbType.Float).Value = longitude;
                cmd.Parameters.Add("@Latitude", SqlDbType.Float).Value = latitude;
                cmd.Parameters.Add("@PhoneNumber",SqlDbType.VarChar,500).Value = PhoneNumber;


                // open connection, execute INSERT, close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

        }

    }
}