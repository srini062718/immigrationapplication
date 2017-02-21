using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmigrationApplication.Model;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ImmigrationApplication.DataAccess
{
    public class PrintDetailRepository
    {
        private readonly PrintDetails _pd = new PrintDetails();
        private readonly DataSet _ds = new DataSet();
        public PrintDetailRepository()
        {
            _pd.Address = new List<Address>();
            _pd.Education = new List<Education>();
            _pd.Employment = new List<Employment>();
            _pd.Child = new List<Child>();
            _pd.FormerSpouse = new List<FormerSpouse>();
            _pd.LastArrivalDetail = new List<LastArrivalDetail>();
            _pd.OtherDetail = new List<OtherDetail>();
            _pd.Parent = new List<Parent>();
            _pd.USRelative = new List<USRelative>();
            _pd.PreviousApplication = new List<PreviousApplication>();

        }
        public PrintDetails GetPersonDetailsById(int personId)
        {
            var cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
            using (var con = new SqlConnection(cs))
            {
                var cmd = new SqlCommand("sp_PrintDetails", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@personid", personId);
                var da = new SqlDataAdapter(cmd);
                da.Fill(_ds);
                if (_ds.Tables.Count <= 0) return _pd;
                foreach (DataRow row in _ds.Tables[0].Rows)
                {
                    _pd.Person = new Person
                    {
                        PersonID = Convert.ToInt32(row["PersonID"]),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        MiddleName = row["MiddleName"].ToString(),
                        Gender = row["Gender"].ToString(),
                        DateExpired = (DateTime)row["DateExpired"],
                        DateIssued= (DateTime)row["DateIssued"],
                        DateofBirth = (DateTime)row["DateofBirth"],
                        DateofMarriage = (DateTime)row["DateofMarriage"],
                        I94ExpiryDate = (DateTime)row["I94ExpiryDate"],
                        LastUSEntryDate = (DateTime)row["LastUSEntryDate"],
                        VisaExpiryDate = (DateTime)row["VisaExpiryDate"],
                        VisaIssueDate = (DateTime)row["VisaIssueDate"],
                        Anumber = row["Anumber"].ToString(),
                        BirthCity = row["BirthCity"].ToString(),
                        CityofMarriage = row["CityofMarriage"].ToString(),
                        CountryIssued = row["CountryIssued"].ToString(),
                        CountryofMarriage = row["CountryofMarriage"].ToString(),
                        SSN = Convert.ToInt32(row["SSN"]),
                        AliasAny = row["AliasAny"].ToString(),
                        USVisaType = row["USVisaType"].ToString(),
                        MartialStatus = row["MartialStatus"].ToString(),
                        Nationality = row["Nationality"].ToString(),
                        PassportNumber = row["PassportNumber"].ToString(),
                        SpouseName = row["SpouseName"].ToString()

                    };
                }
                foreach(DataRow row in _ds.Tables[1].Rows)
                {
                      var a = new Address
                      {
                        Address1 = row["Address1"].ToString(),
                        Address2 = row["Address2"].ToString(),
                        AddressID = Convert.ToInt32(row["AddressID"]),
                        City = row["City"].ToString(),
                        State = row["State"].ToString(),
                        Country = row["Country"].ToString(),
                        ZipCode = Convert.ToInt32(row["Zipcode"]),
                        PersonID = personId
                    };
                    _pd.Address.Add(a);
                }
                foreach (DataRow row in _ds.Tables[2].Rows)
                {
                    var e = new Education
                    {
                        Name = row["Name"].ToString(),
                        Address1 = row["Address1"].ToString(),
                        Address2 = row["Address2"].ToString(),
                        EducationID = Convert.ToInt32(row["EducationID"]),
                        City = row["City"].ToString(),
                        State = row["State"].ToString(),
                        StartDate = (DateTime)row["StartDate"],
                        EndDate = (DateTime)row["EndDate"],
                        Degree = row["Degree"].ToString(),
                        FieldofStudy = row["FieldofStudy"].ToString(),
                        ZipCode = Convert.ToInt32(row["Zipcode"]),
                        PersonID = personId
                    };
                    _pd.Education.Add(e);
                }
                foreach (DataRow row in _ds.Tables[3].Rows)
                {
                    var e = new Employment
                    {
                        EmployerName = row["EmployerName"].ToString(),
                        Address1 = row["Address1"].ToString(),
                        Address2 = row["Address2"].ToString(),
                        EmploymentID = Convert.ToInt32(row["EmploymentID"]),
                        City = row["City"].ToString(),
                        State = row["State"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        Salary = row["Salary"].ToString(),
                        DateLeft = (DateTime)row["DateLeft"],
                        DateStarted = (DateTime)row["DateStarted"],
                        Zipcode = Convert.ToInt32(row["Zipcode"]),
                        JobDescription = row["JobDescription"].ToString(),
                        Client = row["Client"].ToString(),
                        PersonID = personId
                    };
                    _pd.Employment.Add(e);
                }
                foreach (DataRow row in _ds.Tables[4].Rows)
                {
                    var p = new Parent
                    {
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        MiddleName = row["MiddleName"].ToString(),
                        ParentID = Convert.ToInt32(row["ParentID"]),
                        CityofBirth = row["CityofBirth"].ToString(),
                     CityofResidence = row["CityofResidence"].ToString(),
                        Relationship = row["Relationship"].ToString(),
                        DateofBirth = (DateTime)row["DateofBirth"],
                        PersonID = personId
                    };
                    _pd.Parent.Add(p);
                }
                foreach (DataRow row in _ds.Tables[5].Rows)
                {
                    var fp = new FormerSpouse
                    {
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        MiddleName = row["MiddleName"].ToString(),
                        FormerSpouseID = Convert.ToInt32(row["FormerSpouseID"]),
                        CityofMarriage = row["CityofMarriage"].ToString(),
                        CountryofMarriage = row["CountryofMarriage"].ToString(),
                        DateofBirth = (DateTime)row["DateofBirth"],
                        DateofMarriage = (DateTime)row["DateofMarriage"],
                        PersonID = personId
                    };
                    _pd.FormerSpouse.Add(fp);
                }
                foreach (DataRow row in _ds.Tables[6].Rows)
                {
                    var lad = new LastArrivalDetail
                    {
                        AppliedPermanentResident = row["AppliedPermanentResident"].ToString(),
                        USConsulate = row["USConsulate"].ToString(),
                        NameofFlight = row["NameofFlight"].ToString(),
                        FlightNumber = row["FlightNumber"].ToString(),
                        LastArrivalDetailsID = Convert.ToInt32(row["LastArrivalDetailsID"]),
                        City = row["City"].ToString(),
                        State = row["State"].ToString(),
                        DateofArrival = (DateTime)row["DateofArrival"],
                        RefusedVisa = row["RefusedVisa"].ToString(),
                        PersonID = personId
                    };
                    _pd.LastArrivalDetail.Add(lad);
                }
                foreach (DataRow row in _ds.Tables[7].Rows)
                {
                    var od = new OtherDetail
                    {
                        AboutFirm = row["AboutFirm"].ToString(),
                        LanguagesSpoken = row["LanguagesSpoken"].ToString(),
                        Conviction = row["Conviction"].ToString(),
                        LicenseNumber = row["LicenseNumber"].ToString(),
                        OtherDetailsID = Convert.ToInt32(row["OtherDetailsID"]),
                        OtherInformation = row["OtherInformation"].ToString(),
                        PersonID = personId
                    };
                    _pd.OtherDetail.Add(od);
                }
                foreach (DataRow row in _ds.Tables[8].Rows)
                {
                    var c = new Child
                    {
                        ChildrenID = Convert.ToInt32(row["ChildrenID"]),
                        PersonID = Convert.ToInt32(row["PersonID"]),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        MiddleName = row["MiddleName"].ToString(),
                        Gender = row["Gender"].ToString(),
                        DateofBirth = (DateTime)row["DateofBirth"],
                        BirthCountry = row["BirthCountry"].ToString(),
                        MaritalStatus = row["MaritalStatus"].ToString(),
                        BirthPlace = row["BirthPlace"].ToString(),
                        Address1 = row["Address1"].ToString(),
                        Address2 = row["Address2"].ToString(),
                        City = row["City"].ToString(),
                        State = row["State"].ToString(),
                        ZipCode = Convert.ToInt32(row["Zipcode"]),
                    };
                    _pd.Child.Add(c);
                }
                foreach (DataRow row in _ds.Tables[9].Rows)
                {
                    var pa = new PreviousApplication
                    {
                        ApplicationType = row["ApplicationType"].ToString(),
                        StatusGranted = row["StatusGranted"].ToString(),
                        IndicateIfDenied = row["IndicateIfDenied"].ToString(),
                        CapGap = row["CapGap"].ToString(),
                        PreviousApplicationID = Convert.ToInt32(row["PreviousApplicationID"]),
                        DateApplied = (DateTime)row["DateApplied"],
                        PersonID = personId
                    };
                    _pd.PreviousApplication.Add(pa);
                }
                foreach (DataRow row in _ds.Tables[10].Rows)
                {
                    var usr = new USRelative
                    {
                        Name = row["Name"].ToString(),
                        Relationship = row["Relationship"].ToString(),
                        USVisaType = row["USVisaType"].ToString(),
                        Age = Convert.ToInt32(row["Age"]),
                        USRelativeID = Convert.ToInt32(row["USRelativeID"]),
                        Address = row["Address"].ToString(),
                        MaritialStatus = row["MaritialStatus"].ToString(),
                        PersonID = personId
                    };
                    _pd.USRelative.Add(usr);
                }
            }
            return _pd;
        }
    }
}
