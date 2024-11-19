#include "Export.h.h"

using namespace LocalizationFilesManager;

LocalizationFilesManager::Data::Data()
{
	m_files = new std::map<std::string, std::string>[(unsigned short)Langage::COUNT];
m_files[(unsigned short)Langage::EN]["Leaderboards"] = "Leaderboards";
m_files[(unsigned short)Langage::EN]["Options"] = "Options";
m_files[(unsigned short)Langage::EN]["Quit"] = "Quit";
m_files[(unsigned short)Langage::FR]["Leaderboards"] = "Classements";
m_files[(unsigned short)Langage::FR]["Options"] = "Options";
m_files[(unsigned short)Langage::FR]["Quit"] = "Quitter";
m_files[(unsigned short)Langage::JA]["Leaderboards"] = "リーダーボード”";
m_files[(unsigned short)Langage::JA]["Options"] = "オプション";
m_files[(unsigned short)Langage::JA]["Quit"] = "よす";
}