using static DocumentMono.Common.Enums;

namespace DocumentMono.DataAccess
{
    /// <summary>
    /// Kullanıcı bilgisi
    /// </summary>
    public class User
    {
        /// <summary>
        /// User's ID / Kullanıcı IDsi
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Username for login / Giriş için kullanıcı adı
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password for login / Giriş için parola
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User's status / Kullanıcının protaldaki durumu
        /// </summary>
        public UserStatus Status { get; set; }

    }
    /// <summary>
    /// Memur bilgisi
    /// </summary>
    public class CivilServant {

        /// <summary>
        /// Servant's ID / Memurun IDsi
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// User's manager ID / Kullanıcının yöneticisinin IDsi
        /// </summary>
        public int ManagerID { get; set; }

        /// <summary>
        /// Servant's name / Memurun adı
        /// </summary>
        public string ServantName { get; set; }

        /// <summary>
        /// Servant's lastname / Memurun soyadı
        /// </summary>
        public string ServantLastName { get; set; }

        /// <summary>
        /// Servant's position / Memurun pozisyonu
        /// </summary>
        public string Position { get; set; }

        public virtual User User { get; set; }

    }

    /// <summary>
    /// Vatandaş bilgisi
    /// </summary>
    public class Citizen {

        /// <summary>
        /// Citizen's ID / Vatandaş IDsi
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Citizen's identity number / Kimlik numarası
        /// </summary>
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Adı / First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name / Soyadı
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email address / EPosta adresi
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Birth of date / Doğum tarihi
        /// </summary>
        public DateOnly BirthDate { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }

    /// <summary>
    /// Belgeler
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Document's ID / Belgenin IDsi
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// File name / Dosya adı
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// File content / Dosya içeriği
        /// </summary>
        public string FileContent { get; set; }
        /// <summary>
        /// Date of create / Oluşturulma tarihi
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Is file approved? / Belge onaylandı mı?
        /// </summary>
        public bool IsApproved { get; set; }
        /// <summary>
        /// Last update date / Son güncelleme tarihi
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }

        public virtual Citizen Citizen { get; set; }
    }

    /// <summary>
    /// Onay akışı adımları
    /// </summary>
    public class FlowStep {



        /// <summary>
        /// Document's ID / Belge IDsi
        /// </summary>
        public int DocumentID { get; set; }
        /// <summary>
        /// Approver user's ID / Onaylayacak kişi IDsi
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Approval Status / Onay durumu
        /// </summary>
        public FlowStatus FlowStatus { get; set; }

        /// <summary>
        /// Approver ansver date / Onaycının yanıtladığı tarih
        /// </summary>
        public DateTime? AnsverDate { get; set; }
    }

    
}