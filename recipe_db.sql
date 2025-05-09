PGDMP  ;    $                }         	   recipe_db    17.4    17.4 8               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false                       1262    24603 	   recipe_db    DATABASE     o   CREATE DATABASE recipe_db WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en-US';
    DROP DATABASE recipe_db;
                     postgres    false            �            1259    24778    Accounts    TABLE     |  CREATE TABLE public."Accounts" (
    "Id" uuid NOT NULL,
    "Username" character varying(150) NOT NULL,
    "FullName" text NOT NULL,
    "Email" character varying(150),
    "Password" character varying(150) NOT NULL,
    "RoleId" uuid NOT NULL,
    "Created" timestamp with time zone NOT NULL,
    "Updated" timestamp with time zone,
    "DeletedAt" timestamp with time zone
);
    DROP TABLE public."Accounts";
       public         heap r       postgres    false            �            1259    24636 	   DataTypes    TABLE       CREATE TABLE public."DataTypes" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "ParseType" text NOT NULL,
    "CustomRegex" text,
    "Created" timestamp with time zone NOT NULL,
    "Updated" timestamp with time zone,
    "DeletedAt" timestamp with time zone
);
    DROP TABLE public."DataTypes";
       public         heap r       postgres    false            �            1259    24766    PermissionMethods    TABLE       CREATE TABLE public."PermissionMethods" (
    "Id" uuid NOT NULL,
    "Method" text NOT NULL,
    "PermissionId" uuid NOT NULL,
    "Created" timestamp with time zone NOT NULL,
    "Updated" timestamp with time zone,
    "DeletedAt" timestamp with time zone
);
 '   DROP TABLE public."PermissionMethods";
       public         heap r       postgres    false            �            1259    24754    Permissions    TABLE     ?  CREATE TABLE public."Permissions" (
    "Id" uuid NOT NULL,
    "Name" character varying(64) NOT NULL,
    "ControllerName" character varying(64) NOT NULL,
    "Order" integer NOT NULL,
    "Created" timestamp with time zone NOT NULL,
    "Updated" timestamp with time zone,
    "DeletedAt" timestamp with time zone
);
 !   DROP TABLE public."Permissions";
       public         heap r       postgres    false            �            1259    24609    Recipes    TABLE     �   CREATE TABLE public."Recipes" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Created" timestamp with time zone NOT NULL,
    "Updated" timestamp with time zone,
    "DeletedAt" timestamp with time zone
);
    DROP TABLE public."Recipes";
       public         heap r       postgres    false            �            1259    24790    RolePermissionMethods    TABLE       CREATE TABLE public."RolePermissionMethods" (
    "Id" uuid NOT NULL,
    "RoleId" uuid NOT NULL,
    "PermissionMethodId" uuid NOT NULL,
    "Created" timestamp with time zone NOT NULL,
    "Updated" timestamp with time zone,
    "DeletedAt" timestamp with time zone
);
 +   DROP TABLE public."RolePermissionMethods";
       public         heap r       postgres    false            �            1259    24759    Roles    TABLE       CREATE TABLE public."Roles" (
    "Id" uuid NOT NULL,
    "RoleName" character varying(64) NOT NULL,
    "Description" text NOT NULL,
    "Created" timestamp with time zone NOT NULL,
    "Updated" timestamp with time zone,
    "DeletedAt" timestamp with time zone
);
    DROP TABLE public."Roles";
       public         heap r       postgres    false            �            1259    24643    StepParameterTemplates    TABLE       CREATE TABLE public."StepParameterTemplates" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "DataTypeId" uuid NOT NULL,
    "Description" text,
    "Created" timestamp with time zone NOT NULL,
    "Updated" timestamp with time zone,
    "DeletedAt" timestamp with time zone
);
 ,   DROP TABLE public."StepParameterTemplates";
       public         heap r       postgres    false            �            1259    24656    StepParameters    TABLE     0  CREATE TABLE public."StepParameters" (
    "Id" uuid NOT NULL,
    "StepId" uuid NOT NULL,
    "StepParameterTemplateId" uuid NOT NULL,
    "Value" text,
    "Note" text,
    "Created" timestamp with time zone NOT NULL,
    "Updated" timestamp with time zone,
    "DeletedAt" timestamp with time zone
);
 $   DROP TABLE public."StepParameters";
       public         heap r       postgres    false            �            1259    24616    Steps    TABLE     X  CREATE TABLE public."Steps" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "RecipeId" uuid NOT NULL,
    "ParentId" uuid,
    "Created" timestamp with time zone NOT NULL,
    "Updated" timestamp with time zone,
    "DeletedAt" timestamp with time zone,
    "Depth" integer DEFAULT 1 NOT NULL,
    "Order" integer DEFAULT 0 NOT NULL
);
    DROP TABLE public."Steps";
       public         heap r       postgres    false            �            1259    24604    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap r       postgres    false                      0    24778    Accounts 
   TABLE DATA           �   COPY public."Accounts" ("Id", "Username", "FullName", "Email", "Password", "RoleId", "Created", "Updated", "DeletedAt") FROM stdin;
    public               postgres    false    226   �N                 0    24636 	   DataTypes 
   TABLE DATA           r   COPY public."DataTypes" ("Id", "Name", "ParseType", "CustomRegex", "Created", "Updated", "DeletedAt") FROM stdin;
    public               postgres    false    220   -P                 0    24766    PermissionMethods 
   TABLE DATA           p   COPY public."PermissionMethods" ("Id", "Method", "PermissionId", "Created", "Updated", "DeletedAt") FROM stdin;
    public               postgres    false    225   R       
          0    24754    Permissions 
   TABLE DATA           s   COPY public."Permissions" ("Id", "Name", "ControllerName", "Order", "Created", "Updated", "DeletedAt") FROM stdin;
    public               postgres    false    223   ?U                 0    24609    Recipes 
   TABLE DATA           T   COPY public."Recipes" ("Id", "Name", "Created", "Updated", "DeletedAt") FROM stdin;
    public               postgres    false    218   zV                 0    24790    RolePermissionMethods 
   TABLE DATA           z   COPY public."RolePermissionMethods" ("Id", "RoleId", "PermissionMethodId", "Created", "Updated", "DeletedAt") FROM stdin;
    public               postgres    false    227   OW                 0    24759    Roles 
   TABLE DATA           e   COPY public."Roles" ("Id", "RoleName", "Description", "Created", "Updated", "DeletedAt") FROM stdin;
    public               postgres    false    224   �[                 0    24643    StepParameterTemplates 
   TABLE DATA           �   COPY public."StepParameterTemplates" ("Id", "Name", "DataTypeId", "Description", "Created", "Updated", "DeletedAt") FROM stdin;
    public               postgres    false    221   �\       	          0    24656    StepParameters 
   TABLE DATA           �   COPY public."StepParameters" ("Id", "StepId", "StepParameterTemplateId", "Value", "Note", "Created", "Updated", "DeletedAt") FROM stdin;
    public               postgres    false    222   0^                 0    24616    Steps 
   TABLE DATA           |   COPY public."Steps" ("Id", "Name", "RecipeId", "ParentId", "Created", "Updated", "DeletedAt", "Depth", "Order") FROM stdin;
    public               postgres    false    219   ?`                 0    24604    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public               postgres    false    217   b       e           2606    24784    Accounts PK_Accounts 
   CONSTRAINT     X   ALTER TABLE ONLY public."Accounts"
    ADD CONSTRAINT "PK_Accounts" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Accounts" DROP CONSTRAINT "PK_Accounts";
       public                 postgres    false    226            S           2606    24642    DataTypes PK_DataTypes 
   CONSTRAINT     Z   ALTER TABLE ONLY public."DataTypes"
    ADD CONSTRAINT "PK_DataTypes" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."DataTypes" DROP CONSTRAINT "PK_DataTypes";
       public                 postgres    false    220            a           2606    24772 &   PermissionMethods PK_PermissionMethods 
   CONSTRAINT     j   ALTER TABLE ONLY public."PermissionMethods"
    ADD CONSTRAINT "PK_PermissionMethods" PRIMARY KEY ("Id");
 T   ALTER TABLE ONLY public."PermissionMethods" DROP CONSTRAINT "PK_PermissionMethods";
       public                 postgres    false    225            \           2606    24758    Permissions PK_Permissions 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Permissions"
    ADD CONSTRAINT "PK_Permissions" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."Permissions" DROP CONSTRAINT "PK_Permissions";
       public                 postgres    false    223            M           2606    24615    Recipes PK_Recipes 
   CONSTRAINT     V   ALTER TABLE ONLY public."Recipes"
    ADD CONSTRAINT "PK_Recipes" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Recipes" DROP CONSTRAINT "PK_Recipes";
       public                 postgres    false    218            i           2606    24794 .   RolePermissionMethods PK_RolePermissionMethods 
   CONSTRAINT     r   ALTER TABLE ONLY public."RolePermissionMethods"
    ADD CONSTRAINT "PK_RolePermissionMethods" PRIMARY KEY ("Id");
 \   ALTER TABLE ONLY public."RolePermissionMethods" DROP CONSTRAINT "PK_RolePermissionMethods";
       public                 postgres    false    227            ^           2606    24765    Roles PK_Roles 
   CONSTRAINT     R   ALTER TABLE ONLY public."Roles"
    ADD CONSTRAINT "PK_Roles" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Roles" DROP CONSTRAINT "PK_Roles";
       public                 postgres    false    224            V           2606    24649 0   StepParameterTemplates PK_StepParameterTemplates 
   CONSTRAINT     t   ALTER TABLE ONLY public."StepParameterTemplates"
    ADD CONSTRAINT "PK_StepParameterTemplates" PRIMARY KEY ("Id");
 ^   ALTER TABLE ONLY public."StepParameterTemplates" DROP CONSTRAINT "PK_StepParameterTemplates";
       public                 postgres    false    221            Z           2606    24662     StepParameters PK_StepParameters 
   CONSTRAINT     d   ALTER TABLE ONLY public."StepParameters"
    ADD CONSTRAINT "PK_StepParameters" PRIMARY KEY ("Id");
 N   ALTER TABLE ONLY public."StepParameters" DROP CONSTRAINT "PK_StepParameters";
       public                 postgres    false    222            Q           2606    24622    Steps PK_Steps 
   CONSTRAINT     R   ALTER TABLE ONLY public."Steps"
    ADD CONSTRAINT "PK_Steps" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Steps" DROP CONSTRAINT "PK_Steps";
       public                 postgres    false    219            K           2606    24608 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public                 postgres    false    217            b           1259    24805    IX_Accounts_RoleId    INDEX     O   CREATE INDEX "IX_Accounts_RoleId" ON public."Accounts" USING btree ("RoleId");
 (   DROP INDEX public."IX_Accounts_RoleId";
       public                 postgres    false    226            c           1259    24809    IX_Accounts_Username    INDEX     Z   CREATE UNIQUE INDEX "IX_Accounts_Username" ON public."Accounts" USING btree ("Username");
 *   DROP INDEX public."IX_Accounts_Username";
       public                 postgres    false    226            _           1259    24806 !   IX_PermissionMethods_PermissionId    INDEX     m   CREATE INDEX "IX_PermissionMethods_PermissionId" ON public."PermissionMethods" USING btree ("PermissionId");
 7   DROP INDEX public."IX_PermissionMethods_PermissionId";
       public                 postgres    false    225            f           1259    24807 +   IX_RolePermissionMethods_PermissionMethodId    INDEX     �   CREATE INDEX "IX_RolePermissionMethods_PermissionMethodId" ON public."RolePermissionMethods" USING btree ("PermissionMethodId");
 A   DROP INDEX public."IX_RolePermissionMethods_PermissionMethodId";
       public                 postgres    false    227            g           1259    24808    IX_RolePermissionMethods_RoleId    INDEX     i   CREATE INDEX "IX_RolePermissionMethods_RoleId" ON public."RolePermissionMethods" USING btree ("RoleId");
 5   DROP INDEX public."IX_RolePermissionMethods_RoleId";
       public                 postgres    false    227            T           1259    24655 $   IX_StepParameterTemplates_DataTypeId    INDEX     s   CREATE INDEX "IX_StepParameterTemplates_DataTypeId" ON public."StepParameterTemplates" USING btree ("DataTypeId");
 :   DROP INDEX public."IX_StepParameterTemplates_DataTypeId";
       public                 postgres    false    221            W           1259    24673    IX_StepParameters_StepId    INDEX     [   CREATE INDEX "IX_StepParameters_StepId" ON public."StepParameters" USING btree ("StepId");
 .   DROP INDEX public."IX_StepParameters_StepId";
       public                 postgres    false    222            X           1259    24674 )   IX_StepParameters_StepParameterTemplateId    INDEX     }   CREATE INDEX "IX_StepParameters_StepParameterTemplateId" ON public."StepParameters" USING btree ("StepParameterTemplateId");
 ?   DROP INDEX public."IX_StepParameters_StepParameterTemplateId";
       public                 postgres    false    222            N           1259    24633    IX_Steps_ParentId    INDEX     M   CREATE INDEX "IX_Steps_ParentId" ON public."Steps" USING btree ("ParentId");
 '   DROP INDEX public."IX_Steps_ParentId";
       public                 postgres    false    219            O           1259    24634    IX_Steps_RecipeId    INDEX     M   CREATE INDEX "IX_Steps_RecipeId" ON public."Steps" USING btree ("RecipeId");
 '   DROP INDEX public."IX_Steps_RecipeId";
       public                 postgres    false    219            p           2606    24785 !   Accounts FK_Accounts_Roles_RoleId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Accounts"
    ADD CONSTRAINT "FK_Accounts_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."Roles"("Id") ON DELETE CASCADE;
 O   ALTER TABLE ONLY public."Accounts" DROP CONSTRAINT "FK_Accounts_Roles_RoleId";
       public               postgres    false    4702    224    226            o           2606    24773 ?   PermissionMethods FK_PermissionMethods_Permissions_PermissionId    FK CONSTRAINT     �   ALTER TABLE ONLY public."PermissionMethods"
    ADD CONSTRAINT "FK_PermissionMethods_Permissions_PermissionId" FOREIGN KEY ("PermissionId") REFERENCES public."Permissions"("Id") ON DELETE CASCADE;
 m   ALTER TABLE ONLY public."PermissionMethods" DROP CONSTRAINT "FK_PermissionMethods_Permissions_PermissionId";
       public               postgres    false    223    4700    225            q           2606    24795 S   RolePermissionMethods FK_RolePermissionMethods_PermissionMethods_PermissionMethodId    FK CONSTRAINT     �   ALTER TABLE ONLY public."RolePermissionMethods"
    ADD CONSTRAINT "FK_RolePermissionMethods_PermissionMethods_PermissionMethodId" FOREIGN KEY ("PermissionMethodId") REFERENCES public."PermissionMethods"("Id") ON DELETE CASCADE;
 �   ALTER TABLE ONLY public."RolePermissionMethods" DROP CONSTRAINT "FK_RolePermissionMethods_PermissionMethods_PermissionMethodId";
       public               postgres    false    4705    225    227            r           2606    24800 ;   RolePermissionMethods FK_RolePermissionMethods_Roles_RoleId    FK CONSTRAINT     �   ALTER TABLE ONLY public."RolePermissionMethods"
    ADD CONSTRAINT "FK_RolePermissionMethods_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."Roles"("Id") ON DELETE CASCADE;
 i   ALTER TABLE ONLY public."RolePermissionMethods" DROP CONSTRAINT "FK_RolePermissionMethods_Roles_RoleId";
       public               postgres    false    227    4702    224            l           2606    24650 E   StepParameterTemplates FK_StepParameterTemplates_DataTypes_DataTypeId    FK CONSTRAINT     �   ALTER TABLE ONLY public."StepParameterTemplates"
    ADD CONSTRAINT "FK_StepParameterTemplates_DataTypes_DataTypeId" FOREIGN KEY ("DataTypeId") REFERENCES public."DataTypes"("Id") ON DELETE CASCADE;
 s   ALTER TABLE ONLY public."StepParameterTemplates" DROP CONSTRAINT "FK_StepParameterTemplates_DataTypes_DataTypeId";
       public               postgres    false    4691    220    221            m           2606    24675 N   StepParameters FK_StepParameters_StepParameterTemplates_StepParameterTemplate~    FK CONSTRAINT     �   ALTER TABLE ONLY public."StepParameters"
    ADD CONSTRAINT "FK_StepParameters_StepParameterTemplates_StepParameterTemplate~" FOREIGN KEY ("StepParameterTemplateId") REFERENCES public."StepParameterTemplates"("Id") ON DELETE CASCADE;
 |   ALTER TABLE ONLY public."StepParameters" DROP CONSTRAINT "FK_StepParameters_StepParameterTemplates_StepParameterTemplate~";
       public               postgres    false    4694    222    221            n           2606    24668 -   StepParameters FK_StepParameters_Steps_StepId    FK CONSTRAINT     �   ALTER TABLE ONLY public."StepParameters"
    ADD CONSTRAINT "FK_StepParameters_Steps_StepId" FOREIGN KEY ("StepId") REFERENCES public."Steps"("Id") ON DELETE CASCADE;
 [   ALTER TABLE ONLY public."StepParameters" DROP CONSTRAINT "FK_StepParameters_Steps_StepId";
       public               postgres    false    4689    219    222            j           2606    24623    Steps FK_Steps_Recipes_RecipeId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Steps"
    ADD CONSTRAINT "FK_Steps_Recipes_RecipeId" FOREIGN KEY ("RecipeId") REFERENCES public."Recipes"("Id") ON DELETE CASCADE;
 M   ALTER TABLE ONLY public."Steps" DROP CONSTRAINT "FK_Steps_Recipes_RecipeId";
       public               postgres    false    4685    219    218            k           2606    24628    Steps FK_Steps_Steps_ParentId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Steps"
    ADD CONSTRAINT "FK_Steps_Steps_ParentId" FOREIGN KEY ("ParentId") REFERENCES public."Steps"("Id") ON DELETE RESTRICT;
 K   ALTER TABLE ONLY public."Steps" DROP CONSTRAINT "FK_Steps_Steps_ParentId";
       public               postgres    false    219    219    4689               J  x���;O�@�k�W�H��t��vE�$�)�#�fm�!C��_O
�3���������`
��&��@ V��
��ү��W��vg������}O��y��q��at.�o��nFU[����z�<�\�d�6�@��@�Y6?���ȃ5%xF\��HԞ O�uB�BE�V:a<�"��Jn5W�Dӫ�b�|�-bL�)�&9S�k�Q��T��W\l>q�D�ߥd��I���ė�����9V�Tޫ��p�/=�E�x�p�9YdTd��i;~8�x2����z�����Uw��k�oT�S0)*� v��6��:	���#�)�����,         �  x�mRMoS1<���8�B�ص�_�$�RI��Z@��*�Aj�ā_?(*M�V>x����j�O���X�m��|�@^�L!q(Z�w?ʫe���f�>_�WBH�p�����"F���^�ꌣ�[(��J	��vF�;g�r�=���|=�Pݠ]����*��"�#�@�VM���g�}ٔ��	!����>���.����I;�u��}�¶�~qz�L40�d�����i�=�R�QV�u(�!�d�-8�4�&�Y���v�M��>�����x7GS��K/�s�q�����Y''u�ϡ�u	t���4�����X��\�X~�Ÿ�<0��64�H�c�G[\-l�X'��\�1iT�k�8[��׋�B�'%[,����v(+X�nj5C*�h6�Req����mf%��63�	Z�^6�X>����V�������A�Z�z�Z��d�u�u�����         '  x��V��9<����/
�%�V>b� ٖa!�����5��������V�J��Y�\y�Cڵ�'b�u�E�����=��^�,$�WR�b頔���f+�Q�1����E�j��e�br|�χEk�V�L��$Ŝ�B��<�V�c��������"�3YH#բ�eJ;��O��??v�	z�z� �z
i�o+�LdF;}��X?�VЪ>d���& u��2�s���\�`����w���)����,���7=Wa���9Lc�-ϳ׋i��}S�H̽�$��^��[�j���g0��qdP��;*���.����FR6���AȩT��y����d[�{
��d���iԥ�v>��!ߊ���c�֍l`/[Y���@[�!�Ik��4���i!Ư���ۘ6x�
\X�����)=�Wӌ�~�{�.ɖ�,Z�u��8��j��f�6�j�(MґfŌ��hv����M\�ݽnŰc�.���8s�"u�������nj3�6Z��H���*���Z��_Lo�i��@@Y�ݝ�;��M����@g����1*@p���}�=vʧwo5F?^��wuV�Z8`�#c^�p��f�P������cА{�T���mL�;��]� n�A�p��OS{[m���ftO��	5W$��!�w�ޤX/-�%�}G�(�����ğm->}�rZ��3��������ɏ9��|��1�݌֨QcS��2�� TZ�ew&�װ��K��0HTSI�z��y1[iu�R�.�S��J���C Ś��K]0�s�6�o_>>>��Ƨ�      
   +  x����JCA��ӧ�^"�I�;��"�e7�Ɍ�^�u��;X�Z.�M!�9�D[�*�c
 �4rAU���c�/S[��A�۾fs�v�5�
k�K�lS��
�������z@V�D���)��S�⋹�Y��Ͽ&��4n�[-Q!���$5�$Z�v�4���>f��g,.+��ށc��}���(��D�N��(�6��z��ӫ��	��
�?+��H��Ī:R�ђS������)��^�l����� �F �3x�<ggnj}�8��09Y&,��W���2�2         �   x�mλj1��z�)�#F�s��%��k7�jd܄��/)lH�t?|!O�+��)��J�!m.�zj�|:�Ϳ��V��u"$<�`.��p@D����~�<�V3��,�}4H^	jn�uZ=�>�o�(QA+2��CMqsޒ�&��*Gh:�;��:�����e�~��.��q��0�D�%'���1p��?�9����?I�         �  x��Wˍ%9;OG����%4Als�d+��������.�L�$�n^��N�8�TO��+���>4{5�u�^�_&K�"���a��^�s��US�3�;�!m'�-��	��r�_�� �g���O�?:k۳�y���>?���F��a����_k��i��ջҽ�	gâ Tn����$L���A!�M��KR*�Z���kkR�i�LTjJֲ�ջrL�q�'H5�\�ECzG���:�es����Ab9{sO��E�@'�9z��&?A�gbk��p��J{�	����x����>_g�2�]��2��㸎�ƥ�)z��-�f�]�fZ��p�A����6��z;�](�xnl6�~�@�hL�p`� �G��K:���&��RW��<�C��\hX��בy���]%��?�]�~�?�Ɲ����Y֏�N
�L��ٌ���Mz�$��}:S�Ap�m��-�:�%�K3/���(B9s�]W�A�֢Ҩ���M
��Z�������>J@�.-4}7v���f��7HЛ�Z�sO�����Bz�4[�����a���}���>�f��v_ )���R����d���Ӵ�7V��\v�Ol��ɅP�2�%k��8x�Ҁܢ.P�n��pNO��&n��*�������mW���Gڭ�ܟ �^7O@gSE�+���I7��T�Gŝ3a"M���7�\�|�4W̷��N۰\9|EР!S�kώ;���	6�[ҿ�M4H0_���O*��'H��4�4���ui��D���9k��GH��_�d��:��0�e¯\:�|���<q�H|7YFViK�l������n��o��qa�d�Jċs��;�W,H�d���P��	��&cG���`q��I��yU����E91C�vo�t��Xq�߷��:���V���]Zg��uA��%��Lq@-�Ll~=��o������0�Ғ�e���q�F��3�;��k����!#��s.��R�7v�DIð��]�#��B��w?���!r�����҇�Y%�Y1@e��'p� ^�pM��Aw��}��]H�r������y���..��O�782.�&߸���y���	i�/�Va����]���H��$ ���KG]��d@{��w��9J"t�D��oсC!|ohb��U������?md�         �   x����j�0D��W�^�X�-+{�补��H�\
m)	��M���f.��q��P[VȆ	�nK�z\Z�����Sgmͷ-P���WL�̗��X�b��ɲuaJP���+�� ��`�d1�m���?u����j'��<�ҴBVvPQ�1��!�u��u>ǟ^�{�~���AJ�         k  x���=��@���W�G�<�WjJ�N��ό�v��n���� 8D�dٍ���Yפ�N�H�\�CNΐ���������vR��!p�1��������ZBct����6����=M��V9�� �5�� .�fK���s?������P�z��r��=5.ٴ҆O��|4�
P��u��1 GOjj�����Q��؏�*����P��q��Q��L68o~P��D;� �Ȝ��r����,we46�J�]sI�F�s�]�X>�W�^dݏ��խݝ��$Z�fd&���dZ��g4�MjݙTD����g�_���e���t�*�\d�����d��s��~c=��8~���      	   �  x���M��!��_N�}�Ȁ�Ϸ��V=�ll0j��h��{�=Y�U�YE�_���P80��D&Z˅�%'�j�>,�.Pc�@*�sY���h���%�3h��unX�_�.G9�q����z��ؿ��z���x���v29������n�Ǘe��6�1��v)`������F�*Kд;Ƙ*��s*s���\A�bZ��*�v���i.K�����liMy�kI��l����Յ�
��՚d3�Q���'�jӔ`P��%T�r��5�>�����o��x崫򝬍�'ڠ6����~�̐ej�gUS�]؈�0��6Ob`_���q�&+k��s��������O�14O�I�޽�).U���B��I#7	&�>��s}��������79]/��>�0oWlkh��3Ӄs�XE;����	�NG�&��Z\����A�l�dw��X ���¡�縿��pڻ���U���)�쿥���u��l���Z         �  x���Mk�0��+|/c����[�{)4�\F_mH��4����-M �@@��yG��X�*��:pl,` �I�� �����X�$�bk�@[P`���A,M2֘kh�O��Z�(QHF���X(��	
��Z7/c�E�'����E����U���'A�n�:+�{��?T�V����Ժ�q4+���}�&eP	�V*ԣ?��t���QZE�D����Sj\|$(����Z S	���"a�f�}g�������vB�/��>hόKU��&aU�I��'?����e(]*0Js��K/���i��k����D|h�����~!���;�8W�X��"y	�D���=c���s�N���=���j����{�~]��J|S���w�������ٺӷ�/#�1���t�1��5�߱�1uL��!(�q+D�c*.8a~���#�x��f�pI��u��?l�O<         �   x����j�0����[���R=��6c�A��;8�ao��i�h3�����	(1��Po�ek��~E�6��I�"�f�Λ���U���=�@c6k��T��/�e�h�T�-RZ)Ts��D�S����EE��Y��,�Z��=���3��έ/��6d$�E�RƆ�$-��B��.w��c8{�}���ھ��n�t}��h���dߜ	|1w��cp�QD��wm�[�2��G�$�d��t     