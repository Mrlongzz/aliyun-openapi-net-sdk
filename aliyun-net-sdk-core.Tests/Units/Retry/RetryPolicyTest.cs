﻿/*
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

using Aliyun.Acs.Core.Retry;
using Aliyun.Acs.Core.Retry.BackoffStrategy;
using Aliyun.Acs.Core.Retry.Condition;

using Xunit;

namespace Aliyun.Acs.Core.Tests.Units.Retry
{
    public class RetryPolicyTest
    {
        [Fact]
        public void TestRetryPolicyWithNoRetry()
        {
            var retryPolicyContext = new RetryPolicyContext(null, "200", 3, "ecs", "2019-06-01",
                "DescribeInstance", RetryCondition.BlankStatus);

            var retryPolicy = new RetryPolicy();

            var shouldRetry = retryPolicy.ShouldRetry(retryPolicyContext);
            var delay = retryPolicy.GetDelayTimeBeforeNextRetry(retryPolicyContext);

            Assert.Equal(RetryCondition.NoRetry, shouldRetry);
            Assert.Equal(0, delay);
        }

        [Fact]
        public void TestRetryPolicyWithPreDefinedTrue()
        {
            var retryPolicyContext = new RetryPolicyContext(null, "200", 0, "ecs", "2019-06-01",
                "DescribeInstance", RetryCondition.BlankStatus);

            var retryPolicy = new RetryPolicy(3, true);

            var shouldRetry = retryPolicy.ShouldRetry(retryPolicyContext);
            var delay = retryPolicy.GetDelayTimeBeforeNextRetry(retryPolicyContext);

            Assert.Equal(RetryCondition.NoRetry | RetryCondition.ShouldRetry, shouldRetry);
            Assert.True(500 <= delay);
        }

        [Fact]
        public void TestRetryPolicyWithPreDefinedFalse()
        {
            var retryPolicyContext = new RetryPolicyContext(null, "200", 0, "ecs", "2019-06-01",
                "DescribeInstance", RetryCondition.BlankStatus);

            var retryPolicy = new RetryPolicy(3, false);

            var shouldRetry = retryPolicy.ShouldRetry(retryPolicyContext);
            var delay = retryPolicy.GetDelayTimeBeforeNextRetry(retryPolicyContext);

            Assert.Equal(RetryCondition.NoRetry | RetryCondition.ShouldRetry, shouldRetry);
            Assert.True(500 <= delay);
        }

        [Fact]
        public void TestRetryPolicyWithCustomDefine()
        {
            var retryCondition = new ConditionRetryHandler();
            var backoffStrategy = new BackoffStrategyHandler();

            var retryPolicy = new RetryPolicy(retryCondition, backoffStrategy);

            Assert.NotNull(retryPolicy);
        }
    }
}
