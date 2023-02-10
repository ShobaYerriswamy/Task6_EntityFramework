using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using PPM.DAL;
using UserInterface;
using Microsoft.EntityFrameworkCore;

namespace Final
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Viewing view = new Viewing();
            view.View(); 
        }   
    }
}

