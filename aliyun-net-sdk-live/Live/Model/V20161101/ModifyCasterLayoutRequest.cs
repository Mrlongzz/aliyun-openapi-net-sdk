/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
using System.Collections.Generic;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Transform;
using Aliyun.Acs.Core.Utils;
using Aliyun.Acs.live.Transform;
using Aliyun.Acs.live.Transform.V20161101;

namespace Aliyun.Acs.live.Model.V20161101
{
    public class ModifyCasterLayoutRequest : RpcAcsRequest<ModifyCasterLayoutResponse>
    {
        public ModifyCasterLayoutRequest()
            : base("live", "2016-11-01", "ModifyCasterLayout", "live", "openAPI")
        {
        }

		private List<string> blendLists;

		private List<AudioLayer> audioLayers;

		private List<VideoLayer> videoLayers;

		private string casterId;

		private List<string> mixLists;

		private long? ownerId;

		private string layoutId;

		public List<string> BlendLists
		{
			get
			{
				return blendLists;
			}

			set
			{
				blendLists = value;
				for (int i = 0; i < blendLists.Count; i++)
				{
					DictionaryUtil.Add(QueryParameters,"BlendList." + (i + 1) , blendLists[i]);
				}
			}
		}

		public List<AudioLayer> AudioLayers
		{
			get
			{
				return audioLayers;
			}

			set
			{
				audioLayers = value;
				for (int i = 0; i < audioLayers.Count; i++)
				{
					DictionaryUtil.Add(QueryParameters,"AudioLayer." + (i + 1) + ".FixedDelayDuration", audioLayers[i].FixedDelayDuration);
					DictionaryUtil.Add(QueryParameters,"AudioLayer." + (i + 1) + ".VolumeRate", audioLayers[i].VolumeRate);
					DictionaryUtil.Add(QueryParameters,"AudioLayer." + (i + 1) + ".ValidChannel", audioLayers[i].ValidChannel);
				}
			}
		}

		public List<VideoLayer> VideoLayers
		{
			get
			{
				return videoLayers;
			}

			set
			{
				videoLayers = value;
				for (int i = 0; i < videoLayers.Count; i++)
				{
					DictionaryUtil.Add(QueryParameters,"VideoLayer." + (i + 1) + ".FillMode", videoLayers[i].FillMode);
					DictionaryUtil.Add(QueryParameters,"VideoLayer." + (i + 1) + ".WidthNormalized", videoLayers[i].WidthNormalized);
					DictionaryUtil.Add(QueryParameters,"VideoLayer." + (i + 1) + ".FixedDelayDuration", videoLayers[i].FixedDelayDuration);
					DictionaryUtil.Add(QueryParameters,"VideoLayer." + (i + 1) + ".PositionRefer", videoLayers[i].PositionRefer);
					for (int j = 0; j < videoLayers[i].PositionNormalizeds.Count; j++)
					{
						DictionaryUtil.Add(QueryParameters,"VideoLayer." + (i + 1) + ".PositionNormalized." +(j + 1), videoLayers[i].PositionNormalizeds[j]);
					}
					DictionaryUtil.Add(QueryParameters,"VideoLayer." + (i + 1) + ".HeightNormalized", videoLayers[i].HeightNormalized);
				}
			}
		}

		public string CasterId
		{
			get
			{
				return casterId;
			}
			set	
			{
				casterId = value;
				DictionaryUtil.Add(QueryParameters, "CasterId", value);
			}
		}

		public List<string> MixLists
		{
			get
			{
				return mixLists;
			}

			set
			{
				mixLists = value;
				for (int i = 0; i < mixLists.Count; i++)
				{
					DictionaryUtil.Add(QueryParameters,"MixList." + (i + 1) , mixLists[i]);
				}
			}
		}

		public long? OwnerId
		{
			get
			{
				return ownerId;
			}
			set	
			{
				ownerId = value;
				DictionaryUtil.Add(QueryParameters, "OwnerId", value.ToString());
			}
		}

		public string LayoutId
		{
			get
			{
				return layoutId;
			}
			set	
			{
				layoutId = value;
				DictionaryUtil.Add(QueryParameters, "LayoutId", value);
			}
		}

		public class AudioLayer
		{

			private int? fixedDelayDuration;

			private float? volumeRate;

			private string validChannel;

			public int? FixedDelayDuration
			{
				get
				{
					return fixedDelayDuration;
				}
				set	
				{
					fixedDelayDuration = value;
				}
			}

			public float? VolumeRate
			{
				get
				{
					return volumeRate;
				}
				set	
				{
					volumeRate = value;
				}
			}

			public string ValidChannel
			{
				get
				{
					return validChannel;
				}
				set	
				{
					validChannel = value;
				}
			}
		}

		public class VideoLayer
		{

			private string fillMode;

			private float? widthNormalized;

			private int? fixedDelayDuration;

			private string positionRefer;

			private List<float?> positionNormalizeds;

			private float? heightNormalized;

			public string FillMode
			{
				get
				{
					return fillMode;
				}
				set	
				{
					fillMode = value;
				}
			}

			public float? WidthNormalized
			{
				get
				{
					return widthNormalized;
				}
				set	
				{
					widthNormalized = value;
				}
			}

			public int? FixedDelayDuration
			{
				get
				{
					return fixedDelayDuration;
				}
				set	
				{
					fixedDelayDuration = value;
				}
			}

			public string PositionRefer
			{
				get
				{
					return positionRefer;
				}
				set	
				{
					positionRefer = value;
				}
			}

			public List<float?> PositionNormalizeds
			{
				get
				{
					return positionNormalizeds;
				}
				set	
				{
					positionNormalizeds = value;
				}
			}

			public float? HeightNormalized
			{
				get
				{
					return heightNormalized;
				}
				set	
				{
					heightNormalized = value;
				}
			}
		}

        public override ModifyCasterLayoutResponse GetResponse(UnmarshallerContext unmarshallerContext)
        {
            return ModifyCasterLayoutResponseUnmarshaller.Unmarshall(unmarshallerContext);
        }
    }
}
