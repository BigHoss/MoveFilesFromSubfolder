# MoveFilesFromSubfolder
Moves all files from a folder including all subfolders to another folder

## Usage
```
MoveFilesToSubFolder.exe <InputPath> <OutputPath> <DetailedLogging> <MoveOrCopy>
```
### Example
```
MoveFilesToSubFolder.exe "C:\temp" "C:\tempWithAllFiles" true true
```

### Options

#### ```<InputPath>```
Path with the files in subfolders, if empty the path where the exe is is used.

#### ```<OutputPath> ```
Path where all the files should be placed.

#### ```<DetailedLogging> ```
bool value (true/false) 
write the whole path to the console.

#### ```<MoveOrCopy>```
bool value (true/false) 
move or copy the files.

## Used Nugets
