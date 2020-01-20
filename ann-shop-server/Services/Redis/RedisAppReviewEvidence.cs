using ann_shop_server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ann_shop_server.Services
{
    public class RedisAppReviewEvidenceService: Service<RedisAppReviewEvidenceService>
    {
        private const string APP_REVIEW_EVIDENCE = "app_review_evidence";

        /// <summary>
        /// Chuyển từ string sang byte[]
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private byte[] _convertToByte(string value)
        {
            if (String.IsNullOrEmpty(value))
                return null;

            return Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        /// Chuyển từ byte[] to string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string _convertToString(byte[] value)
        {
            if (value == null)
                return null;

            return Encoding.UTF8.GetString(value);
        }

        /// <summary>
        /// Lấy thông tin review của app của khách hàng
        /// </summary>
        /// <param name="userPhone"></param>
        /// <returns></returns>
        public RedisAppReviewEvidence get(string userPhone)
        {
            using (var redis = new ann_shop_redis())
            {
                var byteEvidence = redis.HGet(
                    APP_REVIEW_EVIDENCE,
                    _convertToByte(userPhone)
                );

                if (byteEvidence != null)
                    return JsonConvert.DeserializeObject<RedisAppReviewEvidence>(_convertToString(byteEvidence));

                return null;
            }
        }

        /// <summary>
        /// Khởi tạo thông tin review app của khách hàng
        /// </summary>
        /// <param name="evidence"></param>
        /// <returns></returns>
        public RedisAppReviewEvidence set(RedisAppReviewEvidence evidence)
        {
            using (var redis = new ann_shop_redis())
            {
                redis.HSet(
                    APP_REVIEW_EVIDENCE,
                    _convertToByte(evidence.userPhone),
                    _convertToByte(JsonConvert.SerializeObject(evidence))
                );

                return evidence;
            }
        }

        public RedisAppReviewEvidence updateStatus(string userPhone, string status)
        {
            using (var redis = new ann_shop_redis())
            {
                var byteEvidence = redis.HGet(
                    APP_REVIEW_EVIDENCE,
                    _convertToByte(userPhone)
                );

                if (byteEvidence != null)
                {
                    var evidence = JsonConvert.DeserializeObject<RedisAppReviewEvidence>(_convertToString(byteEvidence));

                    evidence.status = status;
                    redis.HSet(
                        APP_REVIEW_EVIDENCE,
                        _convertToByte(evidence.userPhone),
                        _convertToByte(JsonConvert.SerializeObject(evidence))
                    );

                    return evidence;
                }

                return null;
            }
        }
    }
}