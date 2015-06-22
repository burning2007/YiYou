using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yiyou.Model
{
    public class ApplicationAllInOneMdl
    {
        public ApplicationAllInOneMdl()
        { }

        private Consult_ApplicationMdl _consult_ApplicationMdl = new Consult_ApplicationMdl();

        public Consult_ApplicationMdl Consult_ApplicationMdl
        {
            get { return _consult_ApplicationMdl; }
            set { _consult_ApplicationMdl = value; }
        }

        private EMR_PatientMdl _emr_PatientMdl = new EMR_PatientMdl();

        public EMR_PatientMdl EMR_PatientMdl
        {
            get { return _emr_PatientMdl; }
            set { _emr_PatientMdl = value; }
        }

        private List<Consult_Application_ConsultantMdl> _consult_Application_ConsultantMdlCollection = new List<Consult_Application_ConsultantMdl>();

        public List<Consult_Application_ConsultantMdl> Consult_Application_ConsultantMdlCollection
        {
            get { return _consult_Application_ConsultantMdlCollection; }
            set { _consult_Application_ConsultantMdlCollection = value; }
        }


        private consult_application_accessoryMdl _consult_application_accessoryMdl ;
        public consult_application_accessoryMdl consult_application_accessoryMdl
        {
            get { return _consult_application_accessoryMdl; }
            set { _consult_application_accessoryMdl = value; }
        }
    }
}
