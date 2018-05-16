﻿ using System;
using System.Collections.Generic;
using System.Text;

namespace NssRestClient.Dto
{
    public class Machine
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string TrafficLightStatus { get; set; }

        public string BackgroundColor
        {
            get
            {
                switch (TrafficLightStatus)
                {
                    case "Red":
                        return "Red";
                    case "Amber":
                        return "Orange";
                    case "Green":
                        return "Green";
                    default:
                        break;
                }

                return "";
            }
        }
    }
}
