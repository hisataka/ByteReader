ByteReader
======================
C#でバイナリ列を数値に変換するサンプルです。  
BitConverterを利用しています。  

変換の際にビッグエンディアンによるかリトルエンディアンによるかは、  
コンピュータのアーキテクチャに依存します。  

エンディアンを指定して変換を行うことはできないため、  
アーキテクチャがビッグエンディアンであるコンピュータ上で、  
バイト配列をリトルエンディアン指定で基本データ型に変換する場合は、  
別途自前の変換ロジックを用意する必要があります。  
（とはいえ配列順序の入れ替え部分のみを自前で用意することになると思います。  
　実際の変換は、BitConverterクラスに任せることができるはずです）  

なお、アーキテクチャがリトルエンディアンであるかどうかは、  
IsLittleEndianフィールドにて判定することができます。  

関連情報
--------
http://www.atmarkit.co.jp/fdotnet/dotnettips/045getbytes/getbytes.html  
http://msdn.microsoft.com/ja-jp/library/3kftcaf9(v=VS.80).aspx  
http://d.hatena.ne.jp/h0shu/20071118/p1  
http://msdn.microsoft.com/ja-jp/library/system.bitconverter.islittleendian(v=VS.80).aspx  
http://msdn.microsoft.com/ja-jp/library/bzx26z14(v=VS.80).aspx  