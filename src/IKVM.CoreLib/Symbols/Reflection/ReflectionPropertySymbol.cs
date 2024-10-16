﻿using System;
using System.Reflection;

namespace IKVM.CoreLib.Symbols.Reflection
{

    class ReflectionPropertySymbol : ReflectionMemberSymbol, IPropertySymbol
    {

        readonly PropertyInfo _property;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="type"></param>
        /// <param name="property"></param>
        public ReflectionPropertySymbol(ReflectionSymbolContext context, ReflectionTypeSymbol type, PropertyInfo property) :
            base(context, type.ContainingModule, type, property)
        {
            _property = property ?? throw new ArgumentNullException(nameof(property));
        }

        /// <summary>
        /// Gets the underlying <see cref="PropertyInfo"/> wrapped by this symbol.
        /// </summary>
        internal new PropertyInfo ReflectionObject => _property;

        /// <inheritdoc />
        public PropertyAttributes Attributes => _property.Attributes;

        /// <inheritdoc />
        public bool CanRead => _property.CanRead;

        /// <inheritdoc />
        public bool CanWrite => _property.CanWrite;

        /// <inheritdoc />
        public bool IsSpecialName => _property.IsSpecialName;

        /// <inheritdoc />
        public ITypeSymbol PropertyType => ResolveTypeSymbol(_property.PropertyType);

        /// <inheritdoc />
        public IMethodSymbol? GetMethod => _property.GetMethod is { } m ? ResolveMethodSymbol(m) : null;

        /// <inheritdoc />
        public IMethodSymbol? SetMethod => _property.SetMethod is { } m ? ResolveMethodSymbol(m) : null;

        /// <inheritdoc />
        public object? GetRawConstantValue()
        {
            return _property.GetRawConstantValue();
        }

        /// <inheritdoc />
        public IMethodSymbol[] GetAccessors()
        {
            return ResolveMethodSymbols(_property.GetAccessors());
        }

        /// <inheritdoc />
        public IMethodSymbol[] GetAccessors(bool nonPublic)
        {
            return ResolveMethodSymbols(_property.GetAccessors(nonPublic));
        }

        /// <inheritdoc />
        public IParameterSymbol[] GetIndexParameters()
        {
            return ResolveParameterSymbols(_property.GetIndexParameters());
        }

        /// <inheritdoc />
        public IMethodSymbol? GetGetMethod()
        {
            return _property.GetGetMethod() is MethodInfo m ? ResolveMethodSymbol(m) : null;
        }

        /// <inheritdoc />
        public IMethodSymbol? GetGetMethod(bool nonPublic)
        {
            return _property.GetGetMethod(nonPublic) is MethodInfo m ? ResolveMethodSymbol(m) : null;
        }

        /// <inheritdoc />
        public IMethodSymbol? GetSetMethod()
        {
            return _property.GetSetMethod() is MethodInfo m ? ResolveMethodSymbol(m) : null;
        }

        /// <inheritdoc />
        public IMethodSymbol? GetSetMethod(bool nonPublic)
        {
            return _property.GetSetMethod(nonPublic) is MethodInfo m ? ResolveMethodSymbol(m) : null;
        }

        /// <inheritdoc />
        public ITypeSymbol GetModifiedPropertyType()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ITypeSymbol[] GetOptionalCustomModifiers()
        {
            return ResolveTypeSymbols(_property.GetOptionalCustomModifiers());
        }

        /// <inheritdoc />
        public ITypeSymbol[] GetRequiredCustomModifiers()
        {
            return ResolveTypeSymbols(_property.GetRequiredCustomModifiers());
        }
    }

}