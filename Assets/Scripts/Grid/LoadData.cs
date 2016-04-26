using UnityEngine;
using System.Collections;

public class LoadData : Cooldown {

    //delegate type
    public delegate void LoadDataMethods(int intVar);

    //delegate instance
    public LoadDataMethods FinishedLoading;

    protected override void Execute()
    {
        base.Execute();
        //LoadValue();
    }

    public void LoadValue()
    {
        //the locations of the php file
        string url = "http://connectif.nl/count.php";

        WWWForm form = new WWWForm();

        form.AddField("thetest", "test");

        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW _www)
    {
        yield return _www;
        
        if (FinishedLoading != null)
            FinishedLoading(int.Parse(_www.text));
    }
}
