using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace My_Weather_App
{
    public partial class About : Page
    {

        public List<String> listCity = new List<string>();
        public List<String> listDate = new List<string>();
        public List<int> listHumidity = new List<int>();
        public List<int> listMinTemp = new List<int>();
        public List<int> listMaxTemp = new List<int>();
        public List<int> listPrecipitation = new List<int>();
        public List<int> listWindSpeed = new List<int>();
        public List<int> arrCountCity = new List<int>();
        public List<int> temp = new List<int>();
        //public List<String> listWeather = new List<string>();

        //int countCity = 0;

        //bool boolUser;

        string username;

        int hum, min, max, prec, wind;

        string city, date;



        SqlConnection sConnection = new SqlConnection(@"Data Source=DESKTOP-9A2QO06\MSSQL;Initial Catalog=Prog-POE;Integrated Security=True");



        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {


            lblHumDis.Visible = true;
            lblMinDis.Visible = true;
            lblMaxDis.Visible = true;
            lblPrecDis.Visible = true;
            lblWindDis.Visible = true;
            imgWeather.Visible = true;
            lblCity.Text = username;

            for (int i = 0; i < listCity.Count; i++)
            {

                if (ddlCity.SelectedItem.ToString() == listCity[i])
                {


                    city = listCity[i];
                    date = listDate[i];
                    hum = listHumidity[i];
                    min = listMinTemp[i];
                    max = listMaxTemp[i];
                    prec = listPrecipitation[i];
                    wind = listWindSpeed[i];

                    lblTemp.Text = temp[i].ToString() + "°C";


                    lblCity.Text = city;
                    lblDate.Text = date;
                    lblHumDis.Text = (hum.ToString() + "%");
                    lblMinDis.Text = (min.ToString() + "°C");
                    lblMaxDis.Text = (max.ToString() + "°C");
                    lblPrecDis.Text = (prec.ToString() + "%");
                    lblWindDis.Text = (wind.ToString() + " km/h");

                    //THIS METHOD IS CALLED TO PROVIDE THE RIGHT IMAGE FOR THE WEATHER
                    findWeather(temp[i], hum, min, max, prec, wind);



                }
            }
        }






        protected void Page_Load(object sender, EventArgs e)
        {
            lblHumDis.Visible = false;
            lblMinDis.Visible = false;
            lblMaxDis.Visible = false;
            lblPrecDis.Visible = false;
            lblWindDis.Visible = false;
            imgWeather.Visible = false;



            username = Request.QueryString["Parameter"].ToString();

            Label lblWelcome = (Label)Page.Master.FindControl("lblWelcome");
            lblWelcome.Visible = true;
            lblWelcome.Text += username;

            string city;
            int count = 0;
            sConnection.Open();

            string Sql = "SELECT CITY FROM REGULAR WHERE USERNAME = '" + username + "'";
            SqlCommand command = new SqlCommand(Sql, sConnection);



            using (SqlDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    city = read["CITY"].ToString();
                    for (int i = 0; i < ddlCity.Items.Count; i++)
                    {
                        if (ddlCity.Items[i].ToString() == city)
                        {
                            count++;
                        }
                    }

                    if (count == 0)
                    {
                        ddlCity.Items.Add(read["CITY"].ToString());
                    }

                    //ddlCity.DataSource = command.ExecuteReader();
                    //ddlCity.DataTextField = "CITY";
                    //ddlCity.DataValueField = "CITY";
                    //ddlCity.DataBind();
                }
            }

            sConnection.Close();
            getWeather();
        }


    




   
        public void getWeather()
        {



            sConnection.Open();

            string Sql = "SELECT * FROM WEATHER";
            SqlCommand command = new SqlCommand(Sql, sConnection);



            using (SqlDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    listCity.Add((read["CITY"].ToString()));
                    listDate.Add((read["DATE"].ToString()));
                    listHumidity.Add(int.Parse(read["HUMIDITY"].ToString()));
                    listMinTemp.Add(int.Parse(read["MIN_TEMP"].ToString()));
                    listMaxTemp.Add(int.Parse(read["MAX_TEMP"].ToString()));
                    listPrecipitation.Add(int.Parse(read["PRECIPITATION"].ToString()));
                    listWindSpeed.Add(int.Parse(read["WIND_SPEED"].ToString()));
                }
            }

            sConnection.Close();


            Random random = new Random();

            for (int i = 0; i < listCity.Count; i++)
            {
                temp.Add(random.Next(listMinTemp[i], listMaxTemp[i]));
            }


        
        }










        //THERE ARE MANY SPECIFICATIONS THAT ARE BEING CHECKED TO PROVIDE THE RIGHT IMAGE
        //CORRESPONDING TO THE WEATHER
        public void findWeather(int temp, int hum, int min, int max, int prec, int wind)
        {


            if ((hum <= 50) && (temp >= 10) && (prec <= 50)
                && ((wind >= 0) && (wind < 40)))
            {
                
                imgWeather.ImageUrl = "~/Images/sunny.png";
            }

            else if ((hum >= 50) && (hum < 100) && (temp <= 25) && (prec >= 50)
                && ((wind >= 30) && (wind < 63)))
            {

                imgWeather.ImageUrl = "~/Images/cloudy.png";

            }

            else if ((hum == 100) && (temp <= 15) && ((prec >= 50) && (prec < 100))
                && ((wind >= 63) && (wind < 88)))
            {

                imgWeather.ImageUrl = "~/Images/rain.png";

            }

            else if ((hum == 100) && (temp <= 15) && (prec == 100)
                && ((wind >= 88) && (wind <= 117)))
            {

                imgWeather.ImageUrl = "~/Images/storm.png";

            }

            else if ((temp < 10) && (hum < 50))
            {
                imgWeather.ImageUrl = "~/Images/sunny.png";
            }

            else if ((hum >= 50) && (prec <= 50))
            {
                imgWeather.ImageUrl = "~/Images/cloudy.png";
            }

            else if ((hum <= 50) && (prec <= 50))
            {
                imgWeather.ImageUrl = "~/Images/sunny.png";
            }

            else if ((hum >= 50) && (prec >= 50))
            {
                imgWeather.ImageUrl = "~/Images/sunny.png";
            }
        }

    }
}