using UnityEngine;
using System.Collections;

public class LoadData : Cooldown {

    //delegate type
    public delegate void LoadedBlindDatesData(string stringVar);

    //delegate instance
    public LoadedBlindDatesData FinishedLoadingBlindDates;

    //delegate type
    public delegate void LoadedConnectionsMethods(string stringVar);

    //delegate instance
    public LoadedConnectionsMethods FinishedLoadingConnections;

    [SerializeField]
    private int connectionsTimeExclusion = 10;

    protected override void Execute()
    {
        base.Execute();
        //LoadValue("http://connectif.nl/index.php?request=json&typeRequest=updateUserReadedMessage&time=" + connectionsTimeExclusion, true);
        //LoadValue("http://18003.hosts.ma-cloud.nl/light/activeBlindDates.php", false);

        LoadValue("http://14411.hosts.ma-cloud.nl/xlab/phptestscript.php", false);
    }

    public void LoadValue(string _link, bool _isBlindDate)
    {
        //the locations of the php file
        string url = _link;

        WWWForm form = new WWWForm();

        form.AddField("thetest", "test");

        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www, _isBlindDate));
    }

    IEnumerator WaitForRequest(WWW _www, bool _isBlindDate)
    {
        yield return _www;

        if (_isBlindDate && FinishedLoadingConnections != null)
            FinishedLoadingConnections(_www.text);
        else if (!_isBlindDate && FinishedLoadingBlindDates != null)
            FinishedLoadingBlindDates(_www.text);
    }
}
