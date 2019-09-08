# 繁体简体字幕转换工具

## 简介
此工具可将字幕文件中的简体中文与繁体中文进行相互转换，并且可以指定目录进行批量转换。

## 下载
- 开发版本：[ChineseSubtitleConversionTool.exe](https://github.com/xiaoxinpro/ChineseSubtitleConversionTool/raw/master/ChineseSubtitleConversionTool/bin/Debug/ChineseSubtitleConversionTool.exe)

- 稳定版本：[暂无](https://github.com/xiaoxinpro/ChineseSubtitleConversionTool/releases)

## 使用说明

### 普通转换
可以直接将字幕文件拖拽到软件中，自动读取字幕文件内容，点击“转为简体”或“转为繁体”完成转换，点击“保存”按钮可以输出保存。

### 批量转换
可以直接将含有字幕的文件夹拖拽到软件中，选择转换的格式，填写输出的文件名样式，点击“开始转换”即可完成转换。

批量转换使用多线程技术，转换过程UI不卡顿，其他功能可正常同步使用，方便并快捷。

> 需要注意当目标“文件名”与源文件或已存在文件同名时会覆盖掉已有文件，请注意备份源字幕文件。

批量转换将自动获取该目录下的全部字幕文件（包括ASS、SSA、SRT、LRC、TXT），其他格式文件不会读取。

#### 文件名样式说明
批量转换使用的是文件名样式替换掉替换符，替换符使用`{}`包裹，已有替换符如下：

- `{name}` 源文件名称（不包含路径与扩展名），必须存在的替换符。

- `{exten}` 源文件扩展名，必须存在的替换符。

- `{num}` 文件序号（后续增加功能），可选替换符。

文件名样式中除替换符以外的字符将原样输出，需要注意所有字符必须符合文件名规范，否则将出现保存异常。

> 如果要使用源文件名替换掉旧的字幕文件可输入：`{name}{exten}`

![界面](https://github.com/xiaoxinpro/ChineseSubtitleConversionTool/blob/master/Image.png)

## 捐赠
如果您觉得此工具对你有帮助，欢迎给予我们一定的捐助来维持项目的长期发展。

### 支付宝扫码捐赠

![支付宝扫码捐赠](https://github.com/xiaoxinpro/xxjzWeb/blob/master/Public/Home/i/alipay.png)

### 微信扫描捐赠

![微信扫描捐赠](https://github.com/xiaoxinpro/xxjzWeb/blob/master/Public/Home/i/wechat.png)