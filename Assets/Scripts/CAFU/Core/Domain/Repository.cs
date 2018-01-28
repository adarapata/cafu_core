﻿using System;
// ReSharper disable UnusedMember.Global

namespace CAFU.Core.Domain {

    public interface IRepository {
    }

    public interface IRepositoryFactory<out TRepository> where TRepository : IRepository {

        TRepository Factory();

    }

    public class DefaultRepositoryFactory<TRepository> : IRepositoryFactory<TRepository> where TRepository : IRepository, new() {

        public TRepository Factory() {
            return new TRepository();
        }

    }

    [Obsolete("Please use IRepositoryFactory<TUseCase> instead of this interface.")]
    public interface IRepositoryBuilder {

        void Build();

    }

    [Obsolete("Please use DefaultRepositoryFactory instead of this class.")]
    public static class RepositoryFactory {

        public static T CreateInstance<T>() where T : IRepository, new() {
            T instance = new T();
            // ReSharper disable once SuspiciousTypeConversion.Global
            IRepositoryBuilder builder = instance as IRepositoryBuilder;
            if (builder != default(IRepositoryBuilder)) {
                builder.Build();
            }
            return instance;
        }

    }

}
