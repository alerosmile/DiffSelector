# DiffSelector

The DiffSelector can be used to select the diff viewer depending on whether the Alt key is pressed or not. If the Alt key is not pressed during startup, the first diff viewer is started, if the Alt key is pressed, the second diff viwer is started.
This is useful in tools like TortoiseGit or TortoiseSVN where only one external diff viewer can be configured.

.Net 4 is required to run the application.

## Usage
```
DiffSelector.exe /diffViewer1 <External diff viewer 1 cmd line> /diffViewer2 <External diff viewer 2 cmd line>
```

Example usage in TortoiseSVN for Selectron's VisualDiff and Beyond Compare 5:
- Alt key not pressed &rarr; VisualDiff is started
- Alt key pressed &rarr; Beyond Compare is started
```
DiffSelector.exe /diffViewer1 "C:\Selectron\CAP1131\CAP1131.V6.3.0102.9993\Tools\VisualDiff\bin\VisualDiff.exe" -lf %base -rf %mine -lft %bname -rft %yname /diffViewer2 "C:\Program Files\Beyond Compare 5\BComp.exe" %base %mine /title1=%bname /title2=%yname /leftreadonly
```
## TortoiseSVN configuration
![image](https://github.com/user-attachments/assets/a602a2b9-3ed2-402d-92aa-27c7ab1a7f06)

![image](https://github.com/user-attachments/assets/1ef10012-b76f-45c0-8b53-bb36d03160aa)
