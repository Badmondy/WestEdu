namespace WestEdu;


public interface IPerson<T>{
    string? FirstName { get; set; }
    string? LastName { get; set; }
    string? SocialSecurityNumber { get; set; }

    ContactInfo ContactInformation {get;set;} 

    AddressInfo AddressInformation { get; set; } 

    
    List<T> ListAll();

    IPerson<T> Find();
}