# PlayboxSDK Integration Guide

## 1. Add the PlayboxInstaller Package

1. Open Unity.
2. Go to **Window → Package Manager**.
3. Click **Add package from Git URL...**.
4. Paste the following URL:
   ```
   https://github.com/playbox-technologies/playbox-installer.git#main
   ```
5. Click **Add** and wait for the installation to complete.

---

## 2. Install Dependencies via PlayboxInstaller

1. In Unity, open the **PlayboxInstaller context menu**.
2. Run all setup stages sequentially (Stage 1 → Stage 2).
3. After **Stage 2** is complete, a `DownloadFiles` folder will appear in the project root.
4. From this folder, extract and install the required SDKs:
  - `Firebase.Analytics`
  - `Firebase.Crashlytics`

---

## 3. Finalize PlayboxSDK Installation

1. After completing all the previous steps, go to:
   **PlayboxInstaller → Install PlayboxSDK**.
2. Wait for the process to complete — PlayboxSDK will be fully integrated into your project.

---

## Result

After following these steps:
- PlayboxSDK is installed and ready to use.
