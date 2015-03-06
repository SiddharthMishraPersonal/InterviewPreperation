<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections</Namespace>
  <Namespace>System.Collections.Specialized</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Text.RegularExpressions</Namespace>
</Query>

void Main()
{
 string answer;
    bool errors = false;
    string answerString, desiredAnswerString;
    
    answer = new UserName().newMember(new string[]{"MasterOfDisaster", "DingBat", "Orpheus", "WolfMan", "MrKnowItAll"}, "TygerTyger");
    Console.WriteLine("Your answer:");
    answerString = "\"" + answer + "\"";
    Console.WriteLine("\t" + answerString);
    desiredAnswerString = "\"TygerTyger\"";
    Console.WriteLine("Desired answer:\n\t" + desiredAnswerString);
    if (answerString != desiredAnswerString)
    {
      errors = true;
      Console.WriteLine("DOESN'T MATCH!!!!");
    }
    else
      Console.WriteLine("Match :-)");
    Console.WriteLine();
    answer = new UserName().newMember(new string[]{"MasterOfDisaster", "TygerTyger1", "DingBat", "Orpheus",  "TygerTyger", "WolfMan", "MrKnowItAll"}, "TygerTyger");
    Console.WriteLine("Your answer:");
    answerString = "\"" + answer + "\"";
    Console.WriteLine("\t" + answerString);
    desiredAnswerString = "\"TygerTyger2\"";
    Console.WriteLine("Desired answer:\n\t" + desiredAnswerString);
    if (answerString != desiredAnswerString)
    {
      errors = true;
      Console.WriteLine("DOESN'T MATCH!!!!");
    }
    else
      Console.WriteLine("Match :-)");
    Console.WriteLine();
    answer = new UserName().newMember(new string[]{"TygerTyger2000", "TygerTyger1", "MasterDisaster", "DingBat",  "Orpheus", "WolfMan", "MrKnowItAll"}, "TygerTyger");
    Console.WriteLine("Your answer:");
    answerString = "\"" + answer + "\"";
    Console.WriteLine("\t" + answerString);
    desiredAnswerString = "\"TygerTyger\"";
    Console.WriteLine("Desired answer:\n\t" + desiredAnswerString);
    if (answerString != desiredAnswerString)
    {
      errors = true;
      Console.WriteLine("DOESN'T MATCH!!!!");
    }
    else
      Console.WriteLine("Match :-)");
    Console.WriteLine();
    answer = new UserName().newMember(new string[]{"grokster2", "BrownEyedBoy", "Yoop", "BlueEyedGirl",  "grokster", "Elemental", "NightShade", "Grokster1"}, "grokster");
    Console.WriteLine("Your answer:");
    answerString = "\"" + answer + "\"";
    Console.WriteLine("\t" + answerString);
    desiredAnswerString = "\"grokster1\"";
    Console.WriteLine("Desired answer:\n\t" + desiredAnswerString);
    if (answerString != desiredAnswerString)
    {
      errors = true;
      Console.WriteLine("DOESN'T MATCH!!!!");
    }
    else
      Console.WriteLine("Match :-)");
    Console.WriteLine();
    answer = new UserName().newMember(new string[]{"Bart4", "Bart5", "Bart6", "Bart7", "Bart8", "Bart9", "Bart10", "Lisa", "Marge", "Homer", "Bart", "Bart1", "Bart2", "Bart3", "Bart11", "Bart12"}, "Bart");
    Console.WriteLine("Your answer:");
    answerString = "\"" + answer + "\"";
    Console.WriteLine("\t" + answerString);
    desiredAnswerString = "\"Bart13\"";
    Console.WriteLine("Desired answer:\n\t" + desiredAnswerString);
    if (answerString != desiredAnswerString)
    {
      errors = true;
      Console.WriteLine("DOESN'T MATCH!!!!");
    }
    else
      Console.WriteLine("Match :-)");
    Console.WriteLine();
    
    if (errors)
      Console.WriteLine("Some of the test cases had errors :-(");
    else
      Console.WriteLine("You're a stud (at least on the test data)! :-D ");
  }


public class UserName
{
  public string newMember(string[] existingNames, string newName)
  {
    StringBuilder retval=new StringBuilder(newName);
    
    int addval=1;
    
    for(int i=0;i<existingNames.Length;i++)
    {
    if(retval.ToString()==existingNames[i])
    {
     retval=new StringBuilder(newName+Convert.ToString(addval));
     addval++;
     i=-1;
    }
    }
    return retval.ToString();
  }
}
