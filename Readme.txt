ProjectShp
2019/7/22

1、功能描述：
	输入七参数转换shp文件的投影。

2、开发环境：
	操作系统：windows10
	编程语言：c#
	开发工具：vs2017、ArcEngine10.4
	平台：.net Framework4.6

3、解决方案中目录结构：
	|---README.txt			//说明文档
	|---FrmProjTrans.cs			//设计界面及代码
	|---SpatialRefConversion.cs		//转换要素类的空间参考系，生成新的要素类文件（*.shp）
	|---DataManager.cs			//数据管理基础类，提供shp文件创建、空间参考获取及文件操作的方法