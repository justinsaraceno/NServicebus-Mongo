﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NServiceBus.Saga;

namespace NServiceBus.SagaPersisters.Mongo.Tests
{
    public class TestSaga : IContainSagaData
    {
        public virtual Guid Id { get; set; }

        public virtual string Originator { get; set; }

        public virtual string OriginalMessageId { get; set; }

        public virtual RelatedClass RelatedClass { get; set; }

        public virtual IList<OrderLine> OrderLines { get; set; }

        public virtual StatusEnum Status { get; set; }

        public virtual DateTime DateTimeProperty { get; set; }

        public virtual TestComponent TestComponent { get; set; }

        public virtual PolymorpicPropertyBase PolymorpicRelatedProperty { get; set; }

        public override bool Equals(object obj)
        {
            return this.EqualTo(obj, (x, y) => x.Id == y.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    
    public class PolymorpicProperty : PolymorpicPropertyBase
    {
        public virtual int SomeInt { get; set; }

        public override bool Equals(object obj)
        {
            return this.EqualTo(obj, (x, y) => x.Id == y.Id && x.SomeInt == y.SomeInt);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class PolymorpicPropertyBase
    {
        public virtual Guid Id { get; set; }
    }

    public enum StatusEnum
    {
        SomeStatus, AnotherStatus
    }

    public class TestComponent
    {
        public string Property { get; set; }
        public string AnotherProperty { get; set; }

        public override bool Equals(object obj)
        {
            return this.EqualTo(obj, (x, y) =>
                x.Property == y.Property &&
                x.AnotherProperty == y.AnotherProperty);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class OrderLine
    {
        public virtual Guid Id { get; set; }

        public virtual Guid ProductId { get; set; }

    }

    public class RelatedClass
    {
        public virtual Guid Id { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class SagaWithUniqueProperty : IContainSagaData
    {
        public virtual Guid Id { get; set; }

        public virtual string Originator { get; set; }

        public virtual string OriginalMessageId { get; set; }

        [Unique]
        public virtual string UniqueString { get; set; }

        public string NonUniqueString { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class SagaWithoutUniqueProperties : IContainSagaData
    {
        public virtual Guid Id { get; set; }

        public virtual string Originator { get; set; }

        public virtual string OriginalMessageId { get; set; }

        public virtual string UniqueString { get; set; }

        public string NonUniqueString { get; set; }
    }
}