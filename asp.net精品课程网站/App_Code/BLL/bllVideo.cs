using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ƶ¼��ҵ���߼���*/
    public class bllVideo{
        /*�����Ƶ¼��*/
        public static bool AddVideo(ENTITY.Video video)
        {
            return DAL.dalVideo.AddVideo(video);
        }

        /*����videoId��ȡĳ����Ƶ¼���¼*/
        public static ENTITY.Video getSomeVideo(int videoId)
        {
            return DAL.dalVideo.getSomeVideo(videoId);
        }

        /*������Ƶ¼��*/
        public static bool EditVideo(ENTITY.Video video)
        {
            return DAL.dalVideo.EditVideo(video);
        }

        /*ɾ����Ƶ¼��*/
        public static bool DelVideo(string p)
        {
            return DAL.dalVideo.DelVideo(p);
        }

        /*��ѯ��Ƶ¼��*/
        public static System.Data.DataSet GetVideo(string strWhere)
        {
            return DAL.dalVideo.GetVideo(strWhere);
        }

        /*����������ҳ��ѯ��Ƶ¼��*/
        public static System.Data.DataTable GetVideo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalVideo.GetVideo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ƶ¼��*/
        public static System.Data.DataSet getAllVideo()
        {
            return DAL.dalVideo.getAllVideo();
        }
    }
}
