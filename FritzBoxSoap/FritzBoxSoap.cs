﻿namespace FritzBoxSoap
{
    public class FritzBoxSoap
    {

        //TODO Caching
        //Alle 5 sekunden neue werte
        private SoapRequestSender sender;

        public FritzBoxSoap(string ip, string pw)
        {
            this.sender = new SoapRequestSender(ip, pw);
        }

        public double getPercentageUsageDownStream()
        {
            WANInfo info = this.sender.GetWANInfo();
            OnlineMonitorInfo currinfo = this.sender.GetOnlineMonitorInfo();

            var dl = info.getDownStreamRate() * 1000; // MaxRate format is kbit/s
            var currentdl = currinfo.getCurrentDownStreamRate()[0] * 8; //CurrentRate is Bytes per second

            double percentage = ((double) currentdl / (double)dl);
            return percentage * 100;
        }

        public double getPercentageUsageUoStream()
        {
            WANInfo info = this.sender.GetWANInfo();
            OnlineMonitorInfo currinfo = this.sender.GetOnlineMonitorInfo();

            var ul = info.getUpstreamRate() * 1000; // MaxRate format is kbit/s
            var currentul = currinfo.getCurrentUpstreamRate()[0] * 8; //CurrentRate is Bits per second

            double percentage = ((double)currentul / (double)ul);
            return percentage * 100;
        }

        public string getUlAmount()
        {
            OnlineMonitorInfo currinfo = this.sender.GetOnlineMonitorInfo();
            return (currinfo.getCurrentUpstreamRate()[0] * 8).ToString(); //CurrentRate is Bits per second
        }

        public string getDlAmount()
        {
            OnlineMonitorInfo currinfo = this.sender.GetOnlineMonitorInfo();
            return (currinfo.getCurrentDownStreamRate()[0] * 8).ToString(); //CurrentRate is Bits per second
        }

        /// <summary>
        /// Retunrs Current DownloadSpeed in Bits per second
        /// </summary>
        /// <returns></returns>
        public long getCurrentDlSpeed()
        {
            OnlineMonitorInfo currinfo = this.sender.GetOnlineMonitorInfo();
            return currinfo.getCurrentDownStreamRate()[0] * 8;
        }

        /// <summary>
        /// Retunrs Current UploadSpeed in Bits per second
        /// </summary>
        /// <returns></returns>
        public long getCurrentUpSpeed()
        {
            OnlineMonitorInfo currinfo = this.sender.GetOnlineMonitorInfo();
            return currinfo.getCurrentUpstreamRate()[0] * 8;
        }
    }
}
