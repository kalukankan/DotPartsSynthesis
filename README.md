DotPartsSynthesis
=================

パーツ毎の分割したドット絵を合成するソフト

### ●動作環境  
・Windows XP 以降のOS (32bit or 64bit)  
・Microsoft .NET Framework 4.5 が入っている  

### ●開発環境  
・Windows 7 Professional 64bit  
・Visual Studio Express 2013 for Windows Desktop  

### ●インストール方法  
1. Microsoft .NET Framework 4.5 をインストール  
　http://www.microsoft.com/ja-jp/download/details.aspx?id=30653  
2. プログラムをダウンロードし、解凍ソフトを使ってzipファイルを解凍します。  

### ●とりあえずの使い方  
1. 身体のドット絵、髪型のドット絵、目のドット絵、のように  
　同じ大きさのドット絵をパーツごとに作成します。  
（身体、髪、目などを重ね合わせたらキャラクターができるようにします）  
2. 各ドット絵のパーツごとにフォルダに入れて、ファイル名に適当短い名前をつけます。  
　（身体なら「b01.png」「b02.png」…など）  
　※合成後の出力されたファイル名に使います。  
例1）配置イメージ  
C:/dotImages/body/b01.png, b02.png, b03.png, …  
C:/dotImages/hair/h01.png, h02.png, h03.png, …  
C:/dotImages/eye/e01.png, e02.png, e03.png, …  
3. 解凍したフォルダの中にある「DotPartsSynthesis.exe.config」をメモ帳で開いて  
　下記の値を適宜修正します。  
　・dotPartsDirs  
　　　ドット絵の各パーツのフォルダのパス（カンマ区切りで複数していします）  
　・exportDir  
　　　合成したドット絵を出力するフォルダのパス  
　・dotPartsExtension  
　　　ドット絵のパーツの拡張子（.pngみたいに指定してください）  
4. あとは「DotPartsSynthesis.exe」をダブルクリックして実行します。  
5. 成功していたら、「exportDir」で指定したフォルダに  
　合成したファイル名がつらつらと連なった名前のファイルが大量にあるはずです  
例2）例1のフォルダ構成の場合で、exportDir=C:/exportの場合、  
C:/export/b01_h01_e01.png　（身体「b01.png」、髪型「h01.png」、目「e01.png」を合成）  
C:/export/b01_h01_e02.png  
C:/export/b01_h01_e03.png  
C:/export/b01_h02_e01.png  
…  
（全部で身体3枚×髪型3枚×目3枚＝27枚のドット絵が出力されます）  
