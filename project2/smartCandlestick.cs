﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    public class smartCandlestick : candlestick
    {
        public decimal range {get;set;}
        public decimal bodyRange { get; set; }
        public decimal topPrice { get; set; }
        public decimal bottomPrice { get; set; }
        public decimal upperTail { get; set; }
        public decimal lowerTail { get; set; }

        public bool isBullish { get; set; }
        public bool isBearish { get; set; }
        public bool isNeutral { get; set; }
        public bool isMarubozu { get; set; }
        public bool isDoji { get; set; }
        public bool isDragonFlyDoji { get; set; }
        public bool isGravestoneDoji { get; set; }
        public bool isHammer { get; set; }
        public bool isInvertedHammer { get; set; }

        smartCandlestick() { }

        smartCandlestick(string rowOfData) : base(rowOfData)
        {
            range = this.high - this.low;
            topPrice = Math.Max(this.open, this.close);
            bottomPrice = Math.Min(this.open, this.close);
            bodyRange = topPrice - bottomPrice;
            upperTail = this.high - topPrice;
            lowerTail = bottomPrice - this.low;


        }
    }
}
