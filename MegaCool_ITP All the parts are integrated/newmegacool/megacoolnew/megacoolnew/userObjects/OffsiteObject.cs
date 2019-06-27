using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace megacoolnew.userObjects
{
    class OffsiteObject
    {
        private string priJobID;

        private string priJobType;

        private string priJobStatus;

        private string priJobStartDate;

        private string priJobEndDate;

        private string priJobDescription;

        private string priCID;

        private string priSID;

        private string priIID;

        private string priItem;

        private string priEmpID;

        private string priEmpPos;

        public string EmpPos
        {
            get { return priEmpPos; }
            set { priEmpPos = value; }
        }

        public string EmpID
        {
            get { return priEmpID; }
            set { priEmpID = value; }
        }

        public string Item
        {
            get { return priItem; }
            set { priItem = value; }
        }

        public string IID
        {
            get { return priIID; }
            set { priIID = value; }
        }

        public string JobID
        {
            get { return priJobID; }
            set { priJobID = value; }
        }

        public string JobType
        {
            get { return priJobType; }
            set { priJobType = value; }
        }

        public string JobStatus
        {
            get { return priJobStatus; }
            set { priJobStatus = value; }
        }

        public string JobStartDate
        {
            get { return priJobStartDate; }
            set { priJobStartDate = value; }
        }

        public string JobEndDate
        {
            get { return priJobEndDate; }
            set { priJobEndDate = value; }
        }

        public string JobDescription
        {
            get { return priJobDescription; }
            set { priJobDescription = value; }
        }

        public string CID
        {
            get { return priCID; }
            set { priCID = value; }
        }

        public string SID
        {
            get { return priSID; }
            set { priSID = value; }
        }

    }
}
