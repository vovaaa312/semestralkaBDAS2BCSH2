﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.View;

namespace VetClinic
{
    public class WindowRegistration : IWindowService
    {
        RegistrationWindow registrationWindow = new RegistrationWindow();
        public void CreateWindow()
        { 
            registrationWindow.Show();
        }
    }
}
