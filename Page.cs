using UnityEngine;




public class Page
{
    //fields
   
   
    //properties
   
    public int BookPg { get; set; }
    public string Heading { get; set; }
    public string Body { get; set; }


    //constructors
   
     public Page (string heading, string body)
     {
         Heading = heading;
         Body = body;
      
     }
    public Page(int bookPg)
    {
        BookPg = bookPg;

    }

     //methods*/




}

