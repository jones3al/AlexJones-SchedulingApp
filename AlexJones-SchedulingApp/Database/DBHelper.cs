using AlexJones_SchedulingApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace AlexJones_SchedulingApp.Database
{
    public static class DBHelper

    {
        #region MYSQL Access Function
        public static MySqlConnection Connection { get; set; }

        // Connected to Database useing connecting string in App config shows message if connected and error if not
        public static void StartConnection()
        {

            try
            {
                // get connection string
                string dbstring = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                Connection = new MySqlConnection(dbstring);

                // open connection
                Connection.Open();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void CloseConnection()
        {
            try
            {
                //close connection
                if (Connection != null)
                {
                    Connection.Close();
                }
                Connection = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        #endregion

        #region MySQL Generic DML Functions

        // Inserts new record into specified TABLE using the provided VALUES
        public static int InsertNewRecord(string table, string values)
        {
            CloseConnection();
            StartConnection();
            // Build Query to run
            StringBuilder insertQueryBuilder = new StringBuilder();
            insertQueryBuilder.Append($"INSERT INTO {table} VALUES ({values})");
            string query = insertQueryBuilder.ToString();

            MySqlCommand insertCommand = new MySqlCommand(query, Connection);

            try
            {

                return insertCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        // Update MySql TABLE with provided QUERY. Returns number of rows affected.
        public static int UpdateRecord(string table, string values, string where = "")
        {
            CloseConnection();
            StartConnection();
            StringBuilder updateQueryBuilder = new StringBuilder();
            updateQueryBuilder.Append($"UPDATE {table} SET {values}");
            if (where != "")
            {
                updateQueryBuilder.Append($" WHERE {where};");
            }
            else
            {
                updateQueryBuilder.Append(";");
            }

            string query = updateQueryBuilder.ToString();

            MySqlCommand updateCommand = new MySqlCommand(query, Connection);

            try
            {
                StartConnection();
                return updateCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        // Removes records from specified TABLE using the provided WHERE filter
        public static int DeleteRecord(string table, string where)
        {
            CloseConnection();
            StartConnection();
            StringBuilder deleteQueryBuilder = new StringBuilder();
            deleteQueryBuilder.Append($"DELETE FROM {table} WHERE {where};");

            string query = deleteQueryBuilder.ToString();

            MySqlCommand deleteCommand = new MySqlCommand(query, Connection);

            // Attempt to run the query against the database, and return the number of rows affected
            try
            {
                
                return deleteCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                CloseConnection();
            }

        }
        #endregion

        #region Database Retrieval Functions
        // Retrieves most current list of records in USER table
        public static List<User> GetAllUsers()
        {
            CloseConnection();
            StartConnection();
            List<User> allUsers = new List<User>();

            string allUsersQuery = "SELECT * FROM user";
            MySqlCommand selectAllUsersCommmand = new MySqlCommand(allUsersQuery, Connection);

            try
            {
                
                MySqlDataReader reader = selectAllUsersCommmand.ExecuteReader();

                while (reader.Read())
                {
                    User u = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3), reader.GetDateTime(4), reader.GetString(5));
                    allUsers.Add(u);
                }

                return allUsers;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { CloseConnection(); }
        }

        // Retrieves a user from User table using provided Id to select
        public static User GetUserById(int userId)
        {
            CloseConnection();
            StartConnection();
            string selectUserQuery = $"SELECT * FROM user WHERE userId = {userId}";
            MySqlCommand selectUsersCOmmand = new MySqlCommand(selectUserQuery, Connection);

            try
            {
                MySqlDataReader reader = selectUsersCOmmand.ExecuteReader();
                User selectedUser = null;

                while (reader.Read())
                {
                    selectedUser = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3), reader.GetDateTime(4), reader.GetString(5));
                }

                return selectedUser;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { CloseConnection(); }
        }

        // Retrieves a user from User table using the provided Username
        public static User GetUserByName(string username)
        {
            CloseConnection();
            StartConnection();
            string selectUsersQuery = $"SELECT * FROM user WHERE userName = \"{username}\"";
            MySqlCommand selectAllUsersCommand = new MySqlCommand(selectUsersQuery, Connection);

            try
            {

                MySqlDataReader reader = selectAllUsersCommand.ExecuteReader();
                User selectedUser = null;

                while (reader.Read())
                {
                    selectedUser = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3), reader.GetDateTime(4), reader.GetString(5));
                }

                return selectedUser;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { CloseConnection(); }
        }

        // Retrieves most current list of records in Appointment table
        public static List<Appointment> GetAllAppointments()
        {
            CloseConnection();
            StartConnection();
            List<Appointment> allAppointments = new List<Appointment>();

            string allAppointmentsQuery = "SELECT * FROM appointment";
            MySqlCommand selectAllAppointmentsCommand = new MySqlCommand(allAppointmentsQuery, Connection);

            try
            {

                MySqlDataReader reader = selectAllAppointmentsCommand.ExecuteReader();

                while (reader.Read())
                {
                    Appointment appointment = new Appointment(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
                        reader.GetString(7), reader.GetString(8), reader.GetDateTime(9), reader.GetDateTime(10), reader.GetDateTime(11), reader.GetString(12), reader.GetDateTime(13), reader.GetString(14));

                    allAppointments.Add(appointment);
                }

                return allAppointments;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();  
            }
        }

        // Retrieves an Appointment from APPOINTMENT table using the provided Id to select

        public static Appointment GetAppointmentById(int id)
        {
            CloseConnection();
            StartConnection();
            string selectAppointmentsQuery = $"SELECT * FROM appointment WHERE appointmentId = {id}";
            MySqlCommand selectAllAppointmentsCommand = new MySqlCommand(selectAppointmentsQuery, Connection);

            try
            {

                MySqlDataReader reader = selectAllAppointmentsCommand.ExecuteReader();
                Appointment selectedAppointment = null;

                while (reader.Read())
                {
                    selectedAppointment = new Appointment(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
                        reader.GetString(7), reader.GetString(8), reader.GetDateTime(9), reader.GetDateTime(10), reader.GetDateTime(11), reader.GetString(12), reader.GetDateTime(13), reader.GetString(14));
                }

                return selectedAppointment;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { CloseConnection(); }
        }


        // Retrieves most current list of records in CUSTOMER table of Database

        public static List<Customer> GetAllCustomers()
        {
            CloseConnection();
            StartConnection();
            List<Customer> allCustomers = new List<Customer>();

            string allCustomersQuery = "SELECT * FROM customer";
            MySqlCommand selectCustomersCommand = new MySqlCommand(allCustomersQuery, Connection);

            try
            {

                MySqlDataReader reader = selectCustomersCommand.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetBoolean(3), reader.GetDateTime(4), reader.GetString(5),
                        reader.GetDateTime(6), reader.GetString(7));

                    allCustomers.Add(customer);
                }

                return allCustomers;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { CloseConnection(); }  
        }

        // Retrieves Record for a Specific Customer from CUSTOMER table using the specified Id

        public static Customer GetCustomerById(int id)
        {
            CloseConnection();
            StartConnection();
            string selectCustomersQuery = $"SELECT * FROM customer WHERE customerId = {id}";
            MySqlCommand selectCustomersCommand = new MySqlCommand(selectCustomersQuery, Connection);

            try
            {

                MySqlDataReader reader = selectCustomersCommand.ExecuteReader();
                Customer selectedCustomer = null;

                while (reader.Read())
                {
                    selectedCustomer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetBoolean(3), reader.GetDateTime(4), reader.GetString(5),
                        reader.GetDateTime(6), reader.GetString(7));
                }

                return selectedCustomer;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Retrieves most current list of records in ADDRESS table of Database

        public static List<Address> GetAllAddresses()
        {
            CloseConnection();
            StartConnection();
            List<Address> allAddresses = new List<Address>();

            string allAddressesQuery = "SELECT * FROM address";
            MySqlCommand selectAddressesCommand = new MySqlCommand(allAddressesQuery, Connection);

            try
            {

                MySqlDataReader reader = selectAddressesCommand.ExecuteReader();

                while (reader.Read())
                {
                    Address address = new Address(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6),
                        reader.GetString(7), reader.GetDateTime(8), reader.GetString(9));

                    allAddresses.Add(address);
                }

                return allAddresses;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /// Retreives an Address from ADDRESS table using the provided Id to select

        public static Address GetAddressById(int id)
        {
            CloseConnection();
            StartConnection();
            string selectAddressesQuery = $"SELECT * FROM address WHERE addressId = {id}";
            MySqlCommand selectAddressesCommand = new MySqlCommand(selectAddressesQuery, Connection);

            try
            {

                MySqlDataReader reader = selectAddressesCommand.ExecuteReader();
                Address newAddress = null;

                while (reader.Read())
                {
                    newAddress = new Address(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6),
                        reader.GetString(7), reader.GetDateTime(8), reader.GetString(9));
                }

                return newAddress;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Retrieves most current list of records in CITY table of Database

        public static List<City> GetAllCities()
        {
            CloseConnection();
            StartConnection();
            List<City> allCities = new List<City>();

            string allCitiesQuery = "SELECT * FROM city";
            MySqlCommand selectCitiesCommand = new MySqlCommand(allCitiesQuery, Connection);

            try
            {

                MySqlDataReader reader = selectCitiesCommand.ExecuteReader();

                while (reader.Read())
                {
                    City city = new City(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetString(4), reader.GetDateTime(5), reader.GetString(6));

                    allCities.Add(city);
                }

                return allCities;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Retrieves Record for a Specific City from CITY table using the specified Id

        public static City GetCityById(int id)
        {
            CloseConnection();
            StartConnection();
            string selectCitiesQuery = $"SELECT * FROM city WHERE cityId = {id}";
            MySqlCommand selectCitiesCommand = new MySqlCommand(selectCitiesQuery, Connection);

            try
            {

                MySqlDataReader reader = selectCitiesCommand.ExecuteReader();
                City selectedCity = null;

                while (reader.Read())
                {
                    selectedCity = new City(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetString(4), reader.GetDateTime(5), reader.GetString(6));
                }

                return selectedCity;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Retrieves most current list of records in COUNTRY table of Database

        public static List<Country> GetAllCountries()
        {
            CloseConnection();
            StartConnection();
            List<Country> allCountries = new List<Country>();

            string allCountriesQuery = "SELECT * FROM country";
            MySqlCommand selectCountriesCommand = new MySqlCommand(allCountriesQuery, Connection);

            try
            {

                MySqlDataReader reader = selectCountriesCommand.ExecuteReader();

                while (reader.Read())
                {
                    Country country = new Country(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5));

                    allCountries.Add(country);
                }

                return allCountries;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Retrieves a Country from COUNTRY table using the provided Id to search

        public static Country GetCountryById(int id)
        {

            CloseConnection();
            StartConnection();
            string selectCountriesQuery = $"SELECT * FROM country WHERE countryId = {id}";
            MySqlCommand selectCountriesCommand = new MySqlCommand(selectCountriesQuery, Connection);

            try
            {

                MySqlDataReader reader = selectCountriesCommand.ExecuteReader();
                Country selectedCountry = null;

                while (reader.Read())
                {
                    selectedCountry = new Country(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5));
                }

                return selectedCountry;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        #endregion

        #region

        /// Queries specified TABLE for MAX Id value, then returns that Id, incremented by 1

        public static int GetNewIdFromTable(string table, string idColumnName)
        {
            CloseConnection();
            StartConnection();
            string query = $"SELECT MAX({idColumnName}) FROM {table}";
            MySqlCommand selectCommand = new MySqlCommand(query, Connection);

            try
            {

                int maxId = 9998;
                MySqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    maxId = reader.GetInt32(0);
                }

                return maxId + 1;
            }
            catch (MySqlException ex)
            {
                EventLogger.LogConnectionIssue();
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public static string GetFullAddressById(int addressId)
        {
            CloseConnection();
            
            Address address = null;
            City city = null;
            Country country = null;

            StartConnection();
            string addressSelectQuery = $"SELECT * FROM address WHERE addressId = {addressId}";
            MySqlCommand addressSelectCommand = new MySqlCommand(addressSelectQuery, Connection);

            // Try to Pull the Address using the provided addressId
            try
            {
                
                MySqlDataReader reader = addressSelectCommand.ExecuteReader();

                while (reader.Read())
                {
                    address = new Address(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetString(7),
                        reader.GetDateTime(8), reader.GetString(9));
                }
            }
            catch (MySqlException ex)
            {
                EventLogger.LogConnectionIssue();
                MessageBox.Show(ex.Message);
            }
            finally { CloseConnection(); }


            // Try to Pull City data using the CityId pulled from the Address
            try
            {
                StartConnection();
                string citySelectQuery = $"SELECT * FROM city WHERE cityId = {address.CityId}";
                MySqlCommand citySelectCommand = new MySqlCommand(citySelectQuery, Connection);

                MySqlDataReader reader = citySelectCommand.ExecuteReader();

                while (reader.Read())
                {
                    city = new City(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetString(4), reader.GetDateTime(5), reader.GetString(6));
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Address not found. Unable to load city data.");
            }
            catch (MySqlException ex)
            {
                EventLogger.LogConnectionIssue();
                MessageBox.Show(ex.Message);
            }
            finally { CloseConnection(); }

            // Try to Pull Country data using the countryId pulled from the City
            try
            {
                StartConnection(); 
                string countrySelectQuery = $"SELECT * FROM country WHERE countryId = {city.CountryId}";
                MySqlCommand countrySelectCommand = new MySqlCommand(countrySelectQuery, Connection);



                MySqlDataReader reader = countrySelectCommand.ExecuteReader();

                while (reader.Read())
                {
                    country = new Country(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5));
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Address not found. Unable to load country data.");
            }
            catch (MySqlException ex)
            {
                EventLogger.LogConnectionIssue();
                MessageBox.Show(ex.Message);
            }
            finally { CloseConnection(); }

            // Build the Full Address and Return
            StringBuilder addressBuilder = new StringBuilder();
            try
            {
                addressBuilder.Append($"{address.Address1}");
                if (address.Address2 != "") { addressBuilder.Append($", {address.Address2}"); }
                addressBuilder.Append("\r\n");
                addressBuilder.Append($"{city.Name}, {country.Name}");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Unable to load Address data to create string");
            }

            return addressBuilder.ToString();
        }
        #endregion
    }
}

