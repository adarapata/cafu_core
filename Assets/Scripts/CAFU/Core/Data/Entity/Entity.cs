﻿using System.Collections.Generic;
using CAFU.Core.Utility;

// ReSharper disable UnusedMember.Global

namespace CAFU.Core.Data.Entity {

    /// <summary>
    /// Entity インタフェース
    /// </summary>
    public interface IEntity {

    }

    public interface ISingletonEntity : IEntity, ISingleton {

    }

    /// <summary>
    /// ListEntity インタフェース
    /// </summary>
    /// <inheritdoc cref="IEntity" />
    public interface IListEntity<TEntity> : IEntity, IList<TEntity> {

    }

    public interface ISingletonListEntity<TEntity> : IListEntity<TEntity>, ISingleton {

    }

    public interface IEntityFactory<out TEntity> where TEntity : IEntity {

        TEntity Create();

    }

    public class DefaultEntityFactory<TEntity> : DefaultFactory<TEntity>, IEntityFactory<TEntity>
        where TEntity : IEntity, new() {

    }

}