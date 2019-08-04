using System;
using System.Data;
using System.Configuration;
using System.Web;



public class Class1
{

    
	//class used for the creation of string name for the images 
    // class is public so it can be called on within methods from other classes as required 
    public static string GetRandomPassword(int length)
    { 
    char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); // chars to choose from
    string password = string.Empty;
    Random random = new Random();

    for (int i = 0; i < length; i++)
    {
    int x = random.Next(1, chars.Length);
            //Avoids Characters Repetation  

    if (!password.Contains(chars.GetValue(x).ToString()))
    password += chars.GetValue(x);


    else
    i=i-1;
    }
    return password;
    }

}
