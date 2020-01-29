using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Model.Shared
{
    public class City
    {
        private List<Address> _addressList;
        private int _postalCode;
        private string _cityName;

        public List<Address> AddressList { get => _addressList; set => _addressList = value; }
        public int PostalCode { get => _postalCode; set => _postalCode = value; }
        public string CityName { get => _cityName; set => _cityName = value; }
    }
}
