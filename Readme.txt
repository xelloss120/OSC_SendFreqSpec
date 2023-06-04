■これなに？

OSCで、音声入力デバイスから求めた周波数スペクトルを、送信するやつです。

■使い方

起動時は初期値で動作します。
設定を変更する場合は、入力欄を埋めて適用ボタンを押したら、その設定で動作します。

それぞれ以下の設定制約があります。
録音長さ秒：整数のみ
録音周波数：整数のみ
サンプル数：整数のみ、2のべき乗、64以上、8192以下
分割数：整数のみ、サンプル数以下

詳細を知りたい人は、後述のGitHubアドレスから、ソースコードを読んでもらえればと思います。
1file100line程度なので、読めると思います。

■参考
対応したVCIファイル（VirtualCastで使えるアイテム）を同梱しています。

■作った人

120
https://twitter.com/120byte

■免責

本ソフトウェアの利用により発生した問題は、
本ソフトウェア利用者の責任とし、
本ソフトウェア作成者は一切の責任を負わないものとします。

■改版履歴

20230604
初版

GitHub
https://github.com/xelloss120/OSC_SendFreqSpec

■ライセンス

---------------------------------------------------------------------------------------------------
UniVCI
---------------------------------------------------------------------------------------------------
MIT License

Copyright (c) 2019 Virtual Cast, Inc.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

---------------------------------------------------------------------------------------------------
uOSC
---------------------------------------------------------------------------------------------------
The MIT License (MIT)

Copyright (c) 2017 hecomi

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.