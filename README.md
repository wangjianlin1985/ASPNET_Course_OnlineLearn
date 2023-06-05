# ASPNET_Course_OnlineLearn
asp.net基于三层模式精品课程在线学习答疑网站设计毕业源码案例设计
## 开发技术：基于MVC思想和三层设计模式，前台采用bootstrap响应式框架，后台div+css
##程序开发软件: Visual Studio 2010以上    数据库：sqlserver2005以上
### 前台显示系统包括首页、课程信息、教师信息、获奖信息、课程实践、教材信息、论文信息、课件信息、录像信息、在线答疑、个人用户管理等栏目，现分别介绍：
(1)首页：包含了会员注册和登录栏目、信息搜索栏目、友情链接栏目以及课程信息、教师信息、教材信息、论文信息的简要介绍。

(2)课程信息：对精品课程作了简要介绍，并详尽阐述课程的教学方法、教学大纲、课程简介，列举了教学过程中所用的教材、课件、录像以及实践项目

(3)教师信息：对教师情况进行详细介绍，包括教师教授的课程、获得的奖项情况以及发表过的学术论文。

(4)获奖信息：对教师所获奖项进行简要介绍，包括获奖时间和获奖内容。

(5)课程实践：对课程的实践项目介绍，包括单元实训、综合实训以及课程实验。

(6)教材信息：介绍课程使用教材，包括教材名、作者、出版社以及出版时间。

(7)论文信息：对教师发表过的学术论文进行简要介绍，包括论文发表时间和发表的期刊杂志名。

(8)课件信息：对课程使用的课件进行介绍，不仅包含PPT演示文稿的下载，还详细列举了课程的例题和习题解答。

(9)录像信息：对教师录制的录像进行介绍，包括录制时间、录制教师，用户可以下载课程的录像文件。

(10)在线答疑：用户需登录以后才能留言，方便相互之间的学习交流。

(11)个人用户管理：用户登录以后才能进入，可以修改密码、修改联系方式、查看其他人的留言和发表留言。

(12)后台管理系统：是系统管理员对整个网站进行维护的平台，在这个平台上可对课程信息、教师信息、获奖信息、课程实践信息、教材信息、论文信息、课件信息、录像信息进行添加、修改和删除操作。管理员不能对用户的留言信息进行添加和修改，但可以对超过3个月的过期留言进行删除操作。由于各个模块管理员的操作基本相同，下面只列举管理员管理课程信息的程序流程。
## 实体ER属性：
学生: 学号,登录密码,所在班级,姓名,性别,出生日期,用户照片,联系电话,邮箱,家庭地址,注册时间

班级: 班级编号,班级名称,成立日期,班主任,班级备注

教师: 教师工号,登录密码,教师姓名,教师性别,教师照片,入职日期,教师介绍

课程: 课程编号,课程名称,课程图片,上课老师,课程学时,教学大纲,课程简介

课程实践: 实践id,实践的课程,实践主题,实践内容,实践地点,实践时间

教材: 教材id,教材名称,教材类别,教材定价,出版社,出版日期,作者,库存数量,教材备注

留言答疑: 留言id,留言问题,留言内容,留言人,留言时间,答疑回复,答疑时间

视频录像: 视频id,视频标题,所属课程,视频介绍,视频文件,上传的老师,录制时间

论文: 论文id,论文名称,期刊名称,发布日期,论文作者,审核状态

获奖: 获奖id,获奖原因,获奖内容,获奖的老师,获奖时间

课件: 课件id,课件标题,所属课程,课件描述,课件文件,发布时间

友情链接: 记录id,网站名称,网站Logo,网站地址
