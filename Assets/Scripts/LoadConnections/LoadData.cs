using UnityEngine;
using System.Collections;

public class LoadData : Cooldown {

    //delegate type
    public delegate void LoadedConnectionsMethods(string stringVar);

    //delegate instance
    public LoadedConnectionsMethods FinishedLoadingConnections;

    [SerializeField]
    private int connectionsTimeExclusion = 10;

    [SerializeField]
    private string connections;

    private string blindDatesLink = "http://18003.hosts.ma-cloud.nl/light/activeBlindDates.php";

    private string connectifConnectionsLink = "http://connectif.nl/index.php?request=json&typeRequest=updateUserReadedMessage&time=";

    private bool loadedBlindDates, loadedConnections;

    private string results;

    /*
    protected override void Execute()
    {
        base.Execute();
        //only update when we are done loading

        if(!loadedBlindDates)
            LoadValue(blindDatesLink, true);
    }
    
    public void LoadValue(string _link, bool _isBlindDate)
    {
        if (_isBlindDate)
        {
            UnityEditor.EditorSettings.webSecurityEmulationHostUrl = "http://18003.hosts.ma-cloud.nl/";
        }
        else
        {
            UnityEditor.EditorSettings.webSecurityEmulationHostUrl = "http://connectif.nl/";
        }

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

        if (_isBlindDate)
        {
            loadedBlindDates = true;
            LoadValue(connectifConnectionsLink + connectionsTimeExclusion, false);
            results += _www.text;
        }
        else
        {
            loadedConnections = true;
            if(www.text != "") {
                results += _www.text;
            }
        }

        if (loadedBlindDates && loadedConnections)
            SendInfo();
    }
    */

    protected override void Execute()
    {
        base.Execute();
        //only update when we are done loading
        //UnityEditor.EditorSettings.webSecurityEmulationHostUrl = "http://14411.hosts.ma-cloud.nl/xlab/";
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

        results = _www.text;

        SendInfo();
    }

    void SendInfo()
    {
        if (FinishedLoadingConnections != null)
            FinishedLoadingConnections(connections);

        loadedConnections = loadedBlindDates = false;
        results = "";
    }
    
}
