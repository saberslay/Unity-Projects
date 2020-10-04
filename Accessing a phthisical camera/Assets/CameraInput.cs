using UnityEngine;
using UnityEngine.UI;

public class CameraInput : MonoBehaviour {
    public RawImage CameraRawImage;
    WebCamTexture webCamTexture;
    void Start() {
        DeviceDebug();
        camera_video_capture();
    }

    public void camera_video_capture () {
        GetCameraFeed(1);
        CameraRawImage.texture = webCamTexture;
        if (webCamTexture != null) {
            webCamTexture.Play();
            Debug.Log("Web Cam Connected : " + webCamTexture.deviceName + "\n");
        }
    }

    public void GetCameraFeed (int devise_number) {
        WebCamDevice[] cam_devices = WebCamTexture.devices;
        webCamTexture = new WebCamTexture(cam_devices[devise_number + 1].name, 1920, 1080, 60);
    }

    public void DeviceDebug () {
        // for debugging purposes, Log available devices to the console
        WebCamDevice[] webCamDevices = WebCamTexture.devices;
        for (int i = 0; i < webCamDevices.Length; i++) {
            Debug.Log("Web camera available: " + webCamDevices[i].name);
        }
    }
}
