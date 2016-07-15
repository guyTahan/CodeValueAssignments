using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Struct |AttributeTargets.Class , AllowMultiple = true)]
    public class CodeReviewAttribute : Attribute
    {
        private string _reviewerName;
        private string _reviewDate;
        private bool _isTheCodeWorthy;

        public CodeReviewAttribute(string reviewerName, string reviewDate, bool isTheCodeGood)
        {
            _reviewerName = reviewerName;
            _reviewDate = reviewDate;
            _isTheCodeWorthy = isTheCodeGood;
        }

        public string ReviewerName      
        {
            get { return _reviewerName; }
            set { _reviewerName = value; }
        }

        public string ReviewDate
        {
            get { return _reviewDate; }
            set { _reviewDate = value; }
        }

        public bool CodeIsGood
        {
            get { return _isTheCodeWorthy; }
            set { _isTheCodeWorthy = value; }
        }
    }
}
