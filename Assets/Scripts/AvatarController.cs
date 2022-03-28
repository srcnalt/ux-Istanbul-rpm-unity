using UnityEngine;
using ReadyPlayerMe;
using UnityEngine.UI;

public class AvatarController : MonoBehaviour
{
    [SerializeField] private WebView webView;
    [SerializeField] private Button loadButton;
    [SerializeField] private AvatarLoader avatarLoader;
    [SerializeField] private RuntimeAnimatorController animatorController;

    private void Start()
    {
        avatarLoader = new AvatarLoader();
        loadButton.onClick.AddListener(DisplayWebView);

        webView.OnAvatarCreated = OnAvatarCreated;
    }

    private void DisplayWebView()
    {
        webView.CreateWebView();
        loadButton.gameObject.SetActive(false);
    }

    private void OnAvatarCreated(string url)
    {
        webView.SetVisible(false);
        avatarLoader.LoadAvatar(url, null, OnAvatarLoaded);
    }

    private void OnAvatarLoaded(GameObject avatar, AvatarMetaData metaData)
    {
        avatar.GetComponent<Animator>().runtimeAnimatorController = animatorController;
        loadButton.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        loadButton.onClick.RemoveListener(DisplayWebView);
    }
}
