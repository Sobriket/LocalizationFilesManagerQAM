#ifndef LOCALIZATION_FILES_MANAGER_H

#define LOCALIZATION_FILES_MANAGER_H
#include <map>
#include <string>

namespace LocalizationFilesManager
{
    enum class Langage
    {
EN,
FR,
JA,
COUNT
    };

    class Data
    {
    public:
        Data();
        std::map<std::string, std::string>* m_files;
    };
	
}

#endif // !LOCALIZATION_FILES_MANAGER_H