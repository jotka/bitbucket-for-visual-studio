﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace GitClientVS.UI.Converters
{
    public class HumanizeDateTimeConverter : BaseMarkupExtensionConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTime)value;
            if ((DateTime.Now - dateTime) <= TimeSpan.FromDays(7))
            {
                return Humanize(dateTime);
            }

            return "on " + dateTime;
        }

        private static string Humanize(DateTime dateTime)
        {
            try
            {

                return dateTime.Humanize(false,culture:CultureInfo.CreateSpecificCulture("en-us"));
            }
            catch (Exception)
            {
                return "some time ago";
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
